using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;



[System.Serializable]
public class NPCActionChoiceFactory
{
    public List<NPCActionChoice> m_actionChoiceList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCActionChoiceFactory()
    {
        m_actionChoiceList = new List<NPCActionChoice>();
       
        ReadDataFromXml();
        //  데이터 읽어오기

        MakeList();
        // 읽어온 데이터로 리스트 생성

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

    void MakeList()
    {
        int numOfChoice = System.Enum.GetNames(typeof(NPCActionChoiceName)).Length;

        for (int i = 0; i < numOfChoice; i++)
        {
            string name = "NPCActionChoice" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            NPCActionChoice choice = (NPCActionChoice)obj;
            m_actionChoiceList.Add(choice);
        }

        for (int i = 0; i < m_actionChoiceList.Count; i++)
        {
            for (int k = 0; k < m_fullDic.Count; k++)
            {
                Dictionary<string, string> data = m_fullDic[k];
                int id = int.Parse(data["NPCActionChoiceName"]);
                int givenID = NPCManager.GetInst.m_model.GetChoiceGivenID(id);

                if (i != givenID)
                    continue;

                m_actionChoiceList[i].Init(data);
                break;
            }
        }
    }
}
