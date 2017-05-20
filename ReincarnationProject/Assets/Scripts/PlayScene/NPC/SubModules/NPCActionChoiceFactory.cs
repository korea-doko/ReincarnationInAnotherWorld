﻿using System.Collections;
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



[System.Serializable]
public class NPCActionChoiceFactory
{
    public List<NPCActionChoiceWithParentID> m_choiceWithParentList;
    public List<NPCActionChoice> m_actionChoiceList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCActionChoiceFactory()
    {
        m_choiceWithParentList = new List<NPCActionChoiceWithParentID>();
        m_actionChoiceList = new List<NPCActionChoice>();
       
        ReadDataFromXml();
        //  데이터 읽어오기

        int numOfChoice = System.Enum.GetNames(typeof(NPCActionChoiceName)).Length;

        for (int i = 0; i < numOfChoice; i++)
        {
            string name = "NPCActionChoice" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            NPCActionChoice choice = (NPCActionChoice)obj;
            m_actionChoiceList.Add(choice);
        }



        for (int i = 0; i < m_fullDic.Count; i++)
        {
            Dictionary<string, string> data = m_fullDic[i];

            int id = int.Parse(data["ID"]);
            int givenID = -1;

            for(int k = 0; k < m_choiceStList.Count;k++)
            {
                if (m_choiceStList[k].GetGivenID(id) == -1)
                    continue;

                givenID = m_choiceStList[k].m_givenID;
                break;
            }

            NPCActionChoice choice = m_actionChoiceList[givenID];
            choice.Init(data);
            choice.m_npcActionChoiceName = (NPCActionChoiceName)givenID;
            
            int parentNPCActionID = int.Parse(data["ParentActionName"]);
            NPCActionChoiceWithParentID choiceWithParent = new NPCActionChoiceWithParentID(choice, parentNPCActionID);
            m_choiceWithParentList.Add(choiceWithParent);
        }
        // 데이터 저장 및 다음 Factory에게 부모가 누군지 알려주기 위해서 리스트 따로 만듬.

        for (int i = 0; i < m_actionChoiceList.Count;i++)
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
                    case "NextNPC":
                        partialDic.Add("NextNPC", content.InnerText);
                        break;
                    case "NextNPCAction":
                        partialDic.Add("NextNPCAction", content.InnerText);
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
