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

    public void AttachPassive(Passive _passive)
    {
        m_model.AttachPassive(_passive);
    }
    public void DetachPassive(Passive _passive)
    {
        List<Passive> passiveList = m_model.m_passiveList;

        for (int i = 0; i < passiveList.Count; i++)
        {
            if (passiveList[i].m_name == _passive.m_name)
            {
                m_model.DetachPassive(_passive);
                break;
            }
        }
    }

    public bool IsPlayerHavingPassive(PassiveName _name)
    {
        for(int i = 0; i < m_model.m_passiveList.Count;i++)
        {
            if (m_model.m_passiveList[i].m_name == _name)
                return true;
        }

        return false;
    }
    public bool IsPlayerHavingPassive(Passive _passive)
    {
        return IsPlayerHavingPassive(_passive.m_name);
    }

    public bool IsPlayerHavingQuest(QuestName _name)
    {
        for (int i = 0; i < m_model.m_questList.Count; i++)
        {
            if (m_model.m_questList[i].m_questName == _name)
                return true;
        }

        return false;
    }

    public List<Quest> GetPlayerQuestList()
    {
        return m_model.m_questList;
    }
    public List<Passive> GetPlayerPassiveList()
    {
        return m_model.m_passiveList;
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
        CheckQuestComplete();
        CheckDetachPassive();
    }

    

    void CheckDetachPassive()
    {
        for(int i = m_model.m_passiveList.Count -1; i >= 0;i--)
        {
            Passive p = m_model.m_passiveList[i];

            if (p.CheckDetach())
                DetachPassive(p);
        }
    }
    void CheckQuestComplete()
    {
        for (int i = m_model.m_questList.Count - 1; i >= 0; i--)
        {
            Quest q = m_model.m_questList[i];

            q.CheckComplete();
            //if (q.CheckComplete())
            //    m_model.m_questList.RemoveAt(i);            
        }
    }
  
}
