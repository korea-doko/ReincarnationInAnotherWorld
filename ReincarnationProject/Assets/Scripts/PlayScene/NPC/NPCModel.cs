using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;


public struct NPCActionChoiceNameSt
{
    public int m_id;
    public int m_givenID;               // 내가 임의로 집어넣은 값.
    public NPCActionChoiceName m_name;

    public NPCActionChoiceNameSt(Dictionary<string, string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_givenID = int.Parse(_data["GivenID"]);
        m_name = (NPCActionChoiceName)m_givenID;
    }

    public int GetGivenID(int _id)
    {
        if (m_id == _id)
            return m_givenID;

        return -1;
    }
    public int GetID(int _givenID)
    {
        if (m_givenID == _givenID)
            return m_id;

        return -1;
    }
}
public class NPCModel : MonoBehaviour
{
    public List<NPC> m_npcList;

    // 나중에 없애야함

    public List<NPCActionChoiceNameSt> m_choiceStList;

    private List<Dictionary<string, string>> m_fullDic = new List<Dictionary<string, string>>();  // every item info from DB


    public void Init()
    {
        InitChoiceNameList();
        // 초기화.


        // 

        NPCActionChoiceFactory NPCChoiceFactory = new NPCActionChoiceFactory();
        NPCActionFactory NPCActionFactory = new NPCActionFactory(NPCChoiceFactory);
        NPCFactory NPCFactory = new NPCFactory(NPCActionFactory);

        m_npcList = NPCFactory.GetInitailizedNPCList();
    }

    public NPC GetNPC(NPCName _name)
    {
        return m_npcList[(int)_name];
    }

    void InitChoiceNameList()
    {
        m_choiceStList = new List<NPCActionChoiceNameSt>();

        ReadChoiceNameDataFromXML();

        for (int i = 0; i < m_fullDic.Count; i++)
            m_choiceStList.Add(new NPCActionChoiceNameSt(m_fullDic[i]));
        // NameTable XML에서 가져와서 저장

        m_fullDic.Clear();
        // 재활용하기 위해서 비워주기
    }
    void ReadChoiceNameDataFromXML()
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
                    case "GivenID":
                        partialDic.Add("GivenID", content.InnerText);
                        break;
                    case "NPCActionChoiceName":
                        // partialDic.Add("NPCActionChoiceName", content.InnerText);
                        break;
                    default:
                        Debug.Log("NPCActionChoice Factory Error = " + content.Name);
                        break;
                }
            }
            m_fullDic.Add(partialDic);
        }
    }

    void InitActionNameList()
    {

    }

}
