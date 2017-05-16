using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

public struct NPCActionChoiceWithParentID
{
    public NPCActionChoice m_npcActionChoice;
    public int m_parentActionID;

    public NPCActionChoiceWithParentID(NPCActionChoice _choice, int _parentID)
    {
        m_npcActionChoice = _choice;
        m_parentActionID = _parentID;
    }
}

public struct NPCActionChoiceNameSt
{
    public int m_id;
    public int m_givenID;               // 내가 임의로 집어넣은 값.
    public NPCActionChoiceName m_name;

    public NPCActionChoiceNameSt(Dictionary<string,string> _data)
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
public class NPCActionChoiceFactory
{
    public List<NPCActionChoiceWithParentID> m_choiceWithParentList;
    public List<NPCActionChoiceNameSt> m_choiceStList;
    public List<NPCActionChoice> m_actionChoiceList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCActionChoiceFactory()
    {
        m_choiceWithParentList = new List<NPCActionChoiceWithParentID>();
        m_actionChoiceList = new List<NPCActionChoice>();
        m_choiceStList = new List<NPCActionChoiceNameSt>();

        ReadNameDataFromXML();

        for (int i = 0; i < m_fullDic.Count; i++)
            m_choiceStList.Add(new NPCActionChoiceNameSt(m_fullDic[i]));
        // NameTable XML에서 가져와서 저장

        m_fullDic.Clear();
        // 재활용하기 위해서 비워주기
        

        ReadDataFromXml();
        //  데이터 읽어오기

        for (int i = 0; i < m_fullDic.Count; i++)
        {
            int parentID = int.Parse(m_fullDic[i]["ParentActionName"]);
            NPCActionChoice choice = new NPCActionChoice(m_fullDic[i]);

            m_actionChoiceList.Add(choice);

            NPCActionChoiceWithParentID choiceWithParent = new NPCActionChoiceWithParentID(choice, parentID);
        }
        // 데이터 저장 및 다음 Factory에게 부모가 누군지 알려주기 위해서 리스트 따로 만듬.

        for(int i = 0; i < m_actionChoiceList.Count;i++)
        {
            NPCActionChoice choice = m_actionChoiceList[i];

            for(int j = 0; j < m_choiceStList.Count;j++)
            {
                if( m_choiceStList[j].GetGivenID(choice.m_id) != -1)
                {
                    choice.m_npcActionChoiceName = (NPCActionChoiceName)m_choiceStList[j].m_givenID;
                    break;
                }
            }
        }
        // 자기 자신에 대해서 초기화
        m_fullDic = null;
    }
   
    void ReadNameDataFromXML()
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

    void ReadDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/NPCActionChoiceTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("NPCActionChoiceTable");

        
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
                    case "NPCActionChoiceName":
                        partialDic.Add("NPCActionChoiceName", content.InnerText);
                        break;
                    case "ParentActionName":
                        partialDic.Add("ParentActionName", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                    default:
                        Debug.Log("NPCActionChoice Factory Error = " + content.Name);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }   
}
