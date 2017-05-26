using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using System.Reflection;


[System.Serializable]
public class NPCActionChoiceFactory
{
    public List<NPCActionChoice> m_actionChoiceList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCActionChoiceFactory()
    {
       
        ReadDataFromXml();
        //  데이터 읽어오기

        MakeList();
        // 읽어온 데이터로 리스트 생성

        SetDelegate();
        // 만약에 다음으로 와야하는 NPC가 None이면 적절한 Delegate를 만들어줘야만 한다. 따라서 
        // 그것을 작업하는 곳.
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
        m_actionChoiceList = new List<NPCActionChoice>();

        int numOfChoice = System.Enum.GetNames(typeof(NPCActionChoiceName)).Length;

        
        for(int i = 0; i < numOfChoice;i++)
        {
            NPCActionChoice choice = new NPCActionChoice();

            for (int k = 0; k < m_fullDic.Count; k++)
            {
                Dictionary<string, string> data = m_fullDic[k];

                int id = int.Parse(data["NPCActionChoiceName"]);
                int givenID = NPCManager.GetInst.m_model.GetChoiceGivenID(id);

                if (i != givenID)
                    continue;

                choice.Init(data);
            }

            m_actionChoiceList.Add(choice);
        }       
    }
    void SetDelegate()
    {
        Type delContainerType = Type.GetType("ConditionalChoice");
        ConstructorInfo conInfo = delContainerType.GetConstructor(Type.EmptyTypes);
        object containerObj = conInfo.Invoke(new object[] { });
        
        for (int i = 0; i < m_actionChoiceList.Count;i++)
        {
            NPCActionChoice choice = m_actionChoiceList[i];

            if (choice.m_nextNPCName != NPCName.None)
                continue;
            if (choice.m_npcActionChoiceName == NPCActionChoiceName.None)
                continue;

            // 여기에 도달을 한다면, 조건부
            // 따라서 적절한 대리자를 연결시켜준다.           

            string name = "Del" + choice.m_npcActionChoiceName.ToString();
            Debug.Log(name);
            MethodInfo methodInfo = delContainerType.GetMethod(name);
            DelCheckNextNPC delCheck = (DelCheckNextNPC)Delegate.CreateDelegate(typeof(DelCheckNextNPC), methodInfo);
            choice.m_delCheckNextNPC = delCheck;                
        }
    }
   
}
