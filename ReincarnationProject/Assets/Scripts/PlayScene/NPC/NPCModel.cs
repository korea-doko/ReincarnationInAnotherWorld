using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

[System.Serializable]
public struct NPCActionChoiceNameSt
{
    public int m_id;
    public int m_givenID;               // 내가 임의로 집어넣은 값.
    public NPCActionChoiceName m_name;

    public NPCActionChoiceNameSt(Dictionary<string, string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_givenID = int.Parse(_data["GivenID"]);
        m_name = (NPCActionChoiceName)m_givenID;
    }

    public int GetGivenID(int _id)
    {
        if (m_id == _id)
            return m_givenID;

        return -1;
    }
    public int GetID(int _givenID)
    {
        if (m_givenID == _givenID)
            return m_id;

        return -1;
    }
}
[System.Serializable]
public struct NPCActionNameSt
{
    public int m_id;
    public int m_givenID;
    public NPCActionName m_npcActionName;

    public NPCActionNameSt(Dictionary<string, string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_givenID = int.Parse(_data["GivenID"]);
        m_npcActionName = (NPCActionName)m_givenID;
    }
    public int GetGivenID(int _id)
    {
        if (_id == m_id)
            return m_givenID;

        return -1;
    }
    public int GetID(int _givenID)
    {
        if (_givenID == m_givenID)
            return m_id;

        return -1;
    }
}
[System.Serializable]
public struct NPCNameSt
{
    public int m_id;
    public int m_givenID;
    public NPCName m_npcName;
    public NPCNameSt(Dictionary<string, string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_givenID = int.Parse(_data["GivenID"]);
        m_npcName = (NPCName)m_givenID;
    }
    public int GetGivenID(int _id)
    {
        if (m_id == _id)
            return m_givenID;

        return -1;
    }
    public int GetID(int _givenID)
    {
        if (_givenID == m_givenID)
            return m_id;

        return -1;
    }
}

public class NPCModel : MonoBehaviour
{
    public List<NPC> m_npcList;

    // 나중에 없애야함..?

    public List<NPCActionChoiceNameSt> m_choiceStList;
    public List<NPCActionNameSt> m_actionStList;
    public List<NPCNameSt> m_npcStList;


    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB


    public void Init()
    {
        InitChoiceNameList();
        // Choice Name Table초기화.
        InitActionNameList();
        // Action Name Table 초기화.
        InitNPCNameList();
        // NPC Name Table 초기화
   


        
        NPCActionChoiceFactory NPCChoiceFactory = new NPCActionChoiceFactory();
        NPCActionFactory NPCActionFactory = new NPCActionFactory(NPCChoiceFactory);
        NPCFactory NPCFactory = new NPCFactory(NPCActionFactory);

        m_npcList = NPCFactory.GetInitailizedNPCList();
    }

    public NPC GetNPC(NPCName _name)
    {
        return m_npcList[(int)_name];
    }










    void InitChoiceNameList()
    {
        m_choiceStList = new List<NPCActionChoiceNameSt>();

        ReadChoiceNameDataFromXML();

        for (int i = 0; i < m_fullDic.Count; i++)
            m_choiceStList.Add(new NPCActionChoiceNameSt(m_fullDic[i]));
        // NameTable XML에서 가져와서 저장

        m_fullDic.Clear();
        // 재활용하기 위해서 비워주기
    }
    void ReadChoiceNameDataFromXML()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/NPCActionChoiceNameTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("NPCActionChoiceNameTable");


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
                    case "NPCActionChoiceName":
                        // partialDic.Add("NPCActionChoiceName", content.InnerText);
                        break;
                    default:
                        Debug.Log("NPCActionChoice Factory Error = " + content.Name);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }

    void InitActionNameList()
    {
        m_actionStList = new List<NPCActionNameSt>();

        ReadActionNameDataFromXml();

        for (int i = 0; i < m_fullDic.Count; i++)
            m_actionStList.Add(new NPCActionNameSt(m_fullDic[i]));

        m_fullDic.Clear();
    }
    void ReadActionNameDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/NPCActionNameTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("NPCActionNameTable");


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
                    case "NPCActionName":
                        partialDic.Add("NPCActionName", content.InnerText);
                        break;
                    default:
                        Debug.Log("NPCActionFactory Error = " + content.Name);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }

    void InitNPCNameList()
    {
        m_npcStList = new List<NPCNameSt>();

        ReadNPCNameDataFromXml();
        // NameTable 읽어오기

        for (int i = 0; i < m_fullDic.Count; i++)
            m_npcStList.Add(new NPCNameSt(m_fullDic[i]));
        // 데이터 저장

        m_fullDic.Clear();
        // 재사용 위해서 클리어
    }
    void ReadNPCNameDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/NPCNameTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("NPCNameTable");


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
                    case "NPCName":
                        partialDic.Add("NPCName", content.InnerText);
                        break;
                    default:
                        Debug.Log("NPCActionFactory Error = " + content.Name);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }

    public int GetNPCGivenID(int _id)
    {
        for(int i = 0; i < m_npcStList.Count;i++)
        {
            if (m_npcStList[i].GetGivenID(_id) != -1)
                return m_npcStList[i].GetGivenID(_id);
        }


        Debug.Log("NPC Name Table Error");
        return -1;
    }
    public int GetActionGivenID(int _id)
    {
        for(int i = 0; i < m_actionStList.Count;i++)
        {
            if (m_actionStList[i].GetGivenID(_id) != -1)
                return m_actionStList[i].GetGivenID(_id);
        }

        Debug.Log("NPC Action Name Table Error");
        return -1;
    }
    public int GetChoiceGivenID(int _id)
    {
        for(int i = 0; i < m_choiceStList.Count;i++)
        {
            if (m_choiceStList[i].GetGivenID(_id) != -1)
                return m_choiceStList[i].GetGivenID(_id);
        }
        
        Debug.Log("Choice Name Table Error");
        return -1;
    }
}
