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
        for (int i = 0; i < m_fullDic.Count; i++)
            m_actionChoiceList.Add(new NPCActionChoice(m_fullDic[i]));

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
                    default:
                        Debug.Log("NPCActionChoice Factory Error = " + content.Name);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }
    
}
