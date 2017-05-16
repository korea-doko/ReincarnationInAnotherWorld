using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;


public struct NPCNameSt
{
    public int m_id;
    public int m_givenID;
    public NPCName m_npcName;
    public NPCNameSt(Dictionary<string,string> _data)
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

public class NPCFactory
{

    public List<NPC> m_npcList;
    public List<NPCNameSt> m_npcStList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCFactory(NPCActionFactory _actionFactory)
    {
        m_npcList = new List<NPC>();
        m_npcStList = new List<NPCNameSt>();

        ReadNameDataFromXml();
        // NameTable 읽어오기

        for (int i = 0; i < m_fullDic.Count; i++)
            m_npcStList.Add(new NPCNameSt(m_fullDic[i]));
        // 데이터 저장

        m_fullDic.Clear();
        // 재사용 위해서 클리어

        for(int i = 0; i < _actionFactory.m_actionWithParentList.Count;i++)
        {
            NPCActionWithParentID actionWithParent = _actionFactory.m_actionWithParentList[i];

            NPCAction action = actionWithParent.m_npcAction;
            int parentID = actionWithParent.m_parentNPCID;
            // parentID = DB에서 프라이머리 키, 자동할당 따라서 내 임의대로 안됨. 그래서 따로 바꿔줘야 함

            int givenID = -1;

            for (int k = 0; k < m_npcStList.Count; k++)
            {
                if (m_npcStList[k].GetGivenID(parentID) == -1)
                    continue;

                givenID = m_npcStList[k].m_givenID;
                break;
            }

            action.m_parentNPCName = (NPCName)givenID;
        }
        // 이전 단계에서 마저 초기화 하지 못했던 부모 초기화

        ReadDataFromXml();
        //NPC 데이터 읽어오기

        int numOfNPC = Enum.GetNames(typeof(NPCName)).Length;

        for (int i = 0; i < numOfNPC; i++)
        {
            string name = "NPC" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            NPC npc = (NPC)obj;
            m_npcList.Add(npc);
        }

        for(int i = 0; i < m_fullDic.Count;i++)
        {
            Dictionary<string, string> data = m_fullDic[i];

            int id = int.Parse(data["ID"]);
            int givenID = -1;

            for(int k = 0; k < m_npcStList.Count ;k++)
            {
                if (m_npcStList[k].GetGivenID(id) == -1)
                    continue;

                givenID = m_npcStList[k].m_givenID;
                break;
            }
           
            NPC properNPC = m_npcList[givenID];
            properNPC.Init(data);
            // 몇 개의 데이터만 초기화. 들어가서 확인하면 된다.
            properNPC.m_npcName = (NPCName)givenID; 
        }
        // NPC 초기화 완료

        // Action을 이제 NPC에 넣는다.

        for(int i = 0; i < _actionFactory.m_actionList.Count;i++)
        {
            NPCAction action = _actionFactory.m_actionList[i];

            for(int k = 0; k < m_npcList.Count; k++)
            {
                NPC npc = m_npcList[k];

                if (npc.m_npcName != action.m_parentNPCName)
                    continue;

                npc.AddNPCAction(action);
                break;
            }
        }       
    }
    public List<NPC> GetInitailizedNPCList()
    {
        return m_npcList;
    }

    void ReadNameDataFromXml()
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

    void ReadDataFromXml()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("TextAssets/NPCTable");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName("NPCTable");


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
                    case "NPCName":
                        partialDic.Add("NPCName", content.InnerText);
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
