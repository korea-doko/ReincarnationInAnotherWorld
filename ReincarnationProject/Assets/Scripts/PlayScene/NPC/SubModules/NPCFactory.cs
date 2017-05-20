using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;




public class NPCFactory
{

    public List<NPC> m_npcList;
   
    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB

    public NPCFactory(NPCActionFactory _actionFactory)
    {
        m_npcList = new List<NPC>();
      

        
        ReadDataFromXml();
        ////NPC 데이터 읽어오기

        MakeList();
        // 읽어온 데이터로 NPC 리스트 만들기

        FillList(_actionFactory);
        
    }
    public List<NPC> GetInitailizedNPCList()
    {
        return m_npcList;
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
    void MakeList()
    {
        int numOfNPC = Enum.GetNames(typeof(NPCName)).Length;

        for (int i = 0; i < numOfNPC; i++)
        {
            string name = "NPC" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            NPC npc = (NPC)obj;
            m_npcList.Add(npc);
        }

        for (int i = 0; i < m_npcList.Count; i++)
        {
            for (int k = 0; k < m_fullDic.Count; k++)
            {
                Dictionary<string, string> data = m_fullDic[k];
                int id = int.Parse(data["NPCName"]);
                int givenID = NPCManager.GetInst.m_model.GetNPCGivenID(id);

                if (i != givenID)
                    continue;

                m_npcList[i].Init(data);
                break;
            }
        }
    }
    void FillList(NPCActionFactory _actionFactory)
    {
        for(int i = 0; i < _actionFactory.m_actionList.Count;i++)
        {
            NPCAction action = _actionFactory.m_actionList[i];

            int index = (int)action.m_parentNPCName;

            NPC parentNPC = m_npcList[index];
            parentNPC.AddNPCAction(action);            
        }
    }
}
