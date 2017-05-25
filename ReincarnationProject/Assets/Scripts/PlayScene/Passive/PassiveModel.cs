using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

[System.Serializable]
public struct PassiveNameSt
{
    public int m_id;
    public int m_givenID;
    public PassiveName m_name;

    public PassiveNameSt(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_givenID = int.Parse(_data["GivenID"]);
        m_name = (PassiveName)m_givenID;
    }
    public int GetGivenID(int _id)
    {
        if (_id == m_id)
            return m_givenID;

        return -1;
    }
}
public struct PassiveTypeSt
{
    public int m_id;
    public int m_givenID;
    public PassiveType m_type;
    
    public PassiveTypeSt(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_givenID = int.Parse(_data["GivenID"]);
        m_type = (PassiveType)m_givenID;
    }
    public int GetGivenID(int _id)
    {
        if (_id == m_id)
            return m_givenID;

        return -1;
    }
}



public class PassiveModel : MonoBehaviour
{

    public int[] m_numOfPassiveType;

    public List<Passive> m_passiveList;
    public List<PassiveNameSt> m_nameStList;
    public List<PassiveTypeSt> m_typeStList;
    
    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB


    public void Init()
    {
        int numOfType = System.Enum.GetNames(typeof(PassiveType)).Length;

        m_numOfPassiveType = new int[numOfType];
        for (int i = 0; i < numOfType; i++)
            m_numOfPassiveType[i] = 0;


        ReadPassiveNameFromXML();
        MakePassiveNameList();
        // PassiveName 데이터 읽어오기

        ReadPassiveTypeFromXML();
        MakePassiveTypeList();
        // PassiveType 데이터 읽어오기

        ReadPassiveFromXML();
        MakePassiveList();

        // 위에서 읽어온 데이터를 이용하여 Passive 생성한다.
    }

    public int GetPassiveTypeGivenID(int _id)
    {
        for (int i = 0; i < m_typeStList.Count; i++)
        {
            if (m_typeStList[i].GetGivenID(_id) != -1)
                return m_typeStList[i].GetGivenID(_id);
        }

        Debug.Log("Passive Type Table Error, inputID =" + _id.ToString());
        return -1;
    }
    public int GetPassiveNameGivenID(int _id)
    {
        for (int i = 0; i < m_nameStList.Count; i++)
        {
            if (m_nameStList[i].GetGivenID(_id) != -1)
                return m_nameStList[i].GetGivenID(_id);
        }


        Debug.Log("Passive Name Table Error, inputID =" + _id.ToString());
        return -1;
    }

    void ReadPassiveNameFromXML()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/PassiveNameTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("PassiveNameTable");


        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            Dictionary<string, string> partialDic = new Dictionary<string, string>(); // ItemName is TestItem;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        partialDic.Add("ID", content.InnerText);
                        break;
                    case "GivenID":
                        partialDic.Add("GivenID", content.InnerText);
                        break;
                    case "PassiveName":
                        partialDic.Add("PassiveName", content.InnerText);
                        break;
                    default:
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }
    void MakePassiveNameList()
    {
        m_nameStList = new List<PassiveNameSt>();

        for (int i = 0; i < m_fullDic.Count; i++)
            m_nameStList.Add(new PassiveNameSt(m_fullDic[i]));

        m_fullDic.Clear();
    }

    void ReadPassiveTypeFromXML()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/PassiveTypeTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("PassiveTypeTable");


        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            Dictionary<string, string> partialDic = new Dictionary<string, string>(); // ItemName is TestItem;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        partialDic.Add("ID", content.InnerText);
                        break;
                    case "GivenID":
                        partialDic.Add("GivenID", content.InnerText);
                        break;
                    case "PassiveType":
                        partialDic.Add("PassiveType", content.InnerText);
                        break;
                    default:
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }
    void MakePassiveTypeList()
    {
        m_typeStList = new List<PassiveTypeSt>();

        for (int i = 0; i < m_fullDic.Count; i++)
            m_typeStList.Add(new PassiveTypeSt(m_fullDic[i]));

        m_fullDic.Clear();
    }

    void ReadPassiveFromXML()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/PassiveTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("PassiveTable");

       
        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            Dictionary<string, string> partialDic = new Dictionary<string, string>(); // ItemName is TestItem;

            foreach (XmlNode content in itemContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        partialDic.Add("ID", content.InnerText);
                        break;
                    case "PassiveName":
                        partialDic.Add("PassiveName", content.InnerText);
                        break;
                    case "PassiveType":
                        partialDic.Add("PassiveType", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                    case "DeltaHP":
                        partialDic.Add("DeltaHP", content.InnerText);
                        break;
                    case "DeltaDamage":
                        partialDic.Add("DeltaDamage", content.InnerText);
                        break;
                    case "DeltaDef":
                        partialDic.Add("DeltaDef", content.InnerText);
                        break;
                    case "DeltaGold":
                        partialDic.Add("DeltaGold", content.InnerText);
                        break;
                    case "DeltaHunger":
                        partialDic.Add("DeltaHunger", content.InnerText);
                        break;
                    case "Count":
                        partialDic.Add("Count", content.InnerText);
                        break;
                    default:
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }
    void MakePassiveList()
    {
        m_passiveList = new List<Passive>();

        int numOfPassive = Enum.GetNames(typeof(PassiveName)).Length;


        for (int i = 0; i < m_fullDic.Count; i++)
        {
            Dictionary<string, string> data = m_fullDic[i];

            int passiveTypeID = int.Parse(data["PassiveType"]);
            int passiveTypeGivenID = PassiveManager.GetInst.m_model.GetPassiveTypeGivenID(passiveTypeID);
            PassiveType type = (PassiveType)passiveTypeGivenID;
            string passiveName = "";
            
            switch (type)
            {
                case PassiveType.Buff:
                    passiveName = "BuffPassive" + m_numOfPassiveType[(int)PassiveType.Buff].ToString();
                    m_numOfPassiveType[(int)PassiveType.Buff]++;
                    
                    break;
                case PassiveType.Equipment:
                    passiveName = "EquipmentPassive" + m_numOfPassiveType[(int)PassiveType.Equipment].ToString();
                    m_numOfPassiveType[(int)PassiveType.Equipment]++;

                    break;
                case PassiveType.Consumption:
                    passiveName = "ConsumptionPassive" + m_numOfPassiveType[(int)PassiveType.Consumption].ToString();
                    m_numOfPassiveType[(int)PassiveType.Consumption]++;

                    break;
                case PassiveType.Stack:
                    passiveName = "StackPassive" + m_numOfPassiveType[(int)PassiveType.Stack].ToString();
                    m_numOfPassiveType[(int)PassiveType.Stack]++;

                    break;
                case PassiveType.None:
                default:
                    Debug.Log("Error");
                    break;
            }

            object obj = Activator.CreateInstance(Type.GetType(passiveName));
            Passive p = (Passive)obj;
            p.Init(data);
            m_passiveList.Add(p);
        }
    }
}
