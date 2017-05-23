using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IManager {

    public PlayerModel m_model;
    public PlayerView m_view;
    public static PlayerManager m_inst;
    public static PlayerManager GetInst
    {
        get { return m_inst; }
    }
    public PlayerManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<PlayerModel>("PlayerModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<PlayerView>("PlayerView", this.gameObject);
        m_view.Init();
    }

    public void StartMgr()
    {

    }

    public void UpdateMgr()
    {

    }

    public void AddQuest(Quest _quest)
    {
        m_model.AddQuest(_quest);
    }
    
    public List<Quest> GetPlayerQuestList()
    {
        return m_model.m_questList;
    }
    public bool IsQuestClear(QuestName _name)
    {
        for (int i = 0; i < m_model.m_questList.Count; i++)
        {
            if (m_model.m_questList[i].m_questName == _name)
                if (m_model.m_questList[i].m_isClear)
                    return true;
        }
        return false;
    }
    public void Notified()
    {
        for (int i = m_model.m_questList.Count -1 ; i >= 0; i--)
        {
            Quest q = m_model.m_questList[i];

            Debug.Log(q.m_questName.ToString());

            if (q.CheckComplete())
                m_model.m_questList.RemoveAt(i);
            
        }
    }
}
