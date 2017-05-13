using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

[System.Serializable]
public class NPCActionFactory
{
    public List<NPCAction> m_actionList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCActionFactory(NPCActionChoiceFactory _choiceFactory)
    {
        m_actionList = new List<NPCAction>();

        ReadDataFromXml();

        int numOfAction = Enum.GetNames(typeof(NPCActionName)).Length;

        for (int i = 0; i < numOfAction;i++)
        {
            string name = "NPCAction" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            NPCAction action = (NPCAction)obj;
            action.Init(i);
            m_actionList.Add(action);
        }

        for (int i = 0; i < m_fullDic.Count; i++)
        {
            for(int j = 0; j < m_actionList.Count;j++)
            {
                NPCAction ac = m_actionList[j];

                if (ac.SetData(m_fullDic[i]))
                    break;

                continue;
            }
        }

        for(int i = 0; i < _choiceFactory.m_actionChoiceList.Count;i++)
        {
            NPCActionChoice choice = _choiceFactory.m_actionChoiceList[i];

            NPCAction ac = m_actionList[(int)choice.m_parentNPCActionName];

            ac.AddChoice(choice);
        }
        

        m_fullDic = null;
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
