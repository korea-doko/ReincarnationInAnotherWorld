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
        // 정보 읽어오기

        MakeList();
        // 읽어온 정보로 리스트 생성

        FillList(_choiceFactory);
        // Action에 Choice 집어넣기
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

    void MakeList()
    {
        int numOfAction = Enum.GetNames(typeof(NPCActionName)).Length;

        for (int i = 0; i < numOfAction; i++)
        {
            string name = "NPCAction" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            NPCAction action = (NPCAction)obj;
            m_actionList.Add(action);
        }

        for (int i = 0; i < m_actionList.Count; i++)
        {
            for (int k = 0; k < m_fullDic.Count; k++)
            {
                Dictionary<string, string> data = m_fullDic[k];
                int id = int.Parse(data["NPCActionName"]);
                int givenID = NPCManager.GetInst.m_model.GetActionGivenID(id);

                //Debug.Log(id.ToString() + " / " + givenID.ToString());
                if (i != givenID)
                    continue;

                m_actionList[i].Init(data);
                break;
            }
        }
    }

    void FillList(NPCActionChoiceFactory _choiceFactory)
    {
        for(int i = 0; i < _choiceFactory.m_actionChoiceList.Count;i++)
        {
            NPCActionChoice cho = _choiceFactory.m_actionChoiceList[i];

            int index = (int)cho.m_parentNPCActionName;

            NPCAction parentAction = m_actionList[index];
            parentAction.AddChoice(cho);
        }
    }
}
