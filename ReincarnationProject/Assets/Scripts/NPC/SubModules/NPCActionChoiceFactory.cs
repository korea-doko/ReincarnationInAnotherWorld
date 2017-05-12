using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

//[System.Serializable]
//public class ChoiceName
//{
//    public int m_id;
//    public NPCActionChoiceName m_name;

//    public ChoiceName(Dictionary<string,string> _data)
//    {
//        m_id = int.Parse(_data["ID"]);
//        m_name = (NPCActionChoiceName)Enum.Parse(typeof(NPCActionChoiceName), _data["NPCActionChoiceName"]);

//    }
//}
[System.Serializable]
public class NPCActionChoiceFactory
{
   
    public List<NPCActionChoice> m_actionChoiceList;
    //public List<ChoiceName> m_nameList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCActionChoiceFactory()
    {
        m_actionChoiceList = new List<NPCActionChoice>();
        //m_nameList = new List<ChoiceName>();

        //ReadNameDataFromXml();
        //for (int i = 0; i < m_fullDic.Count; i++)
        //    m_nameList.Add(new ChoiceName(m_fullDic[i]));

        //m_fullDic.Clear();

        ReadDataFromXml();
        for (int i = 0; i < m_fullDic.Count; i++)
            m_actionChoiceList.Add(new NPCActionChoice(m_fullDic[i]));

        m_fullDic = null;
    }

    

    void ReadNameDataFromXml()
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
                    case "NPCActionChoiceName":
                        partialDic.Add("NPCActionChoiceName", content.InnerText);
                        break;                   
                    default:
                        Debug.Log("Error = " + content.Name);
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
                    default:
                        Debug.Log("NPCActionChoice Factory Error = " + content.Name);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }
    
}
