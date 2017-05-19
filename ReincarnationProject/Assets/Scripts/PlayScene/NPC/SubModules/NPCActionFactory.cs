using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;


public struct NPCActionWithParentID
{
    public NPCAction m_npcAction;
    public int m_parentNPCID;

    public NPCActionWithParentID(NPCAction _action, int _parentID)
    {
        m_npcAction = _action;
        m_parentNPCID = _parentID;
    }
}

public struct NPCActionNameSt
{
    public int m_id;
    public int m_givenID;               
    public NPCActionName m_npcActionName;

    public NPCActionNameSt(Dictionary<string,string> _data)
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
public class NPCActionFactory
{
    public List<NPCAction> m_actionList;
    public List<NPCActionNameSt> m_actionStList;
    public List<NPCActionWithParentID> m_actionWithParentList;


    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCActionFactory(NPCActionChoiceFactory _choiceFactory)
    {
        m_actionList = new List<NPCAction>();
        m_actionStList = new List<NPCActionNameSt>();
        m_actionWithParentList = new List<NPCActionWithParentID>();

        ReadNameDataFromXml();
        // Name Table 읽어오기
        for (int i = 0; i < m_fullDic.Count; i++)
            m_actionStList.Add(new NPCActionNameSt(m_fullDic[i]));
        // Name Table 저장

        for(int i = 0; i <  _choiceFactory.m_choiceWithParentList.Count;i++)
        {
            NPCActionChoiceWithParentID parentWithID = _choiceFactory.m_choiceWithParentList[i];

            NPCActionChoice choice = parentWithID.m_npcActionChoice;
            int parentID = parentWithID.m_parentActionID;
            // parentID = DB에서 프라이머리 키, 자동할당 따라서 내 임의대로 안됨. 그래서 따로 바꿔줘야 함

            for (int k = 0; k < m_actionStList.Count;k++)
            {
                NPCActionNameSt nameST = m_actionStList[k];
                int givenID = -1;

                if (nameST.GetGivenID(parentID) == -1)
                    continue;

                givenID = nameST.m_givenID;
                
                choice.m_parentNPCActionName = (NPCActionName)givenID;
                break;
            }
        }
        // 이전 단계에서 Parent에 대해서 ID와 GivenID 알 수 없었기 때문에 여기에서 초기화 해준다.


        m_fullDic.Clear();
        // 재활용을 위해서 

        ReadDataFromXml();
        // 정보 읽어오기


        int numOfAction = Enum.GetNames(typeof(NPCActionName)).Length;

        for (int i = 0; i < numOfAction; i++)
        {
            string name = "NPCAction" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            NPCAction action = (NPCAction)obj;
            m_actionList.Add(action);            
        }
        // 스크립트가 다 따로 있기 때문에 현재 이런 방식으로 하고 있음.
        // 스크립트 이름이 다르기 때문에 만들었음.
        // 순서는 givenID를 Enum Casting한 것과 똑같다.
        

        for (int i = 0; i < m_fullDic.Count; i++)
        {
            Dictionary<string, string> data = m_fullDic[i];

            int id = int.Parse(data["NPCActionName"]);
           
            int givenID = -1;

            for (int k = 0; k < m_actionStList.Count; k++)
            {
                if (m_actionStList[k].GetGivenID(id) == -1)
                    continue;

                givenID = m_actionStList[k].m_givenID;
                break;
            }
            

            NPCAction properAction = m_actionList[givenID];
            
            properAction.Init(data);
            // 몇 개의 데이터만 초기화 된다. F12들어가서 보면 확인가능
            properAction.m_npcActionName = (NPCActionName)givenID;
            // ID는 GivenID로 형변환 해야한다.

            int parentNPCID = int.Parse(data["ParentNPC"]);

            NPCActionWithParentID actionWithParent = new NPCActionWithParentID(properAction, parentNPCID);
            m_actionWithParentList.Add(actionWithParent);
        }

        for (int i = 0; i < _choiceFactory.m_actionChoiceList.Count;i++)
        {
            NPCActionChoice choice = _choiceFactory.m_actionChoiceList[i];
           
            for(int k = 0; k < m_actionList.Count;k++)
            {
                NPCAction action = m_actionList[k];

                if (action.m_npcActionName != choice.m_parentNPCActionName || action.m_npcActionName == NPCActionName.None)
                    continue;
                
                action.AddChoice(choice);
                break;                                
            }
        }       
        m_fullDic = null;
    }
    void ReadNameDataFromXml()
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
    void ReadDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/NPCActionTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("NPCActionTable");


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
                    case "NPCActionName":
                        partialDic.Add("NPCActionName", content.InnerText);
                        break;
                    case "ParentNPC":
                        partialDic.Add("ParentNPC", content.InnerText);
                        break;
                    case "Desc":
                        partialDic.Add("Desc", content.InnerText);
                        break;
                    default:
                        Debug.Log("NPCActionFactory Error = " + content.Name);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }
}
