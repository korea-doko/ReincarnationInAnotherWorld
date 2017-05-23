using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour, IManager
{
    public QuestModel m_model;
    public QuestView m_view;

    private static QuestManager m_inst;
    public static QuestManager GetInst
    {
        get { return m_inst; }
    }
    public QuestManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<QuestModel>("QuestModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<QuestView>("QuestView", this.gameObject);
        m_view.Init();
    }
    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {

    }


    public void Notified()
    {
        AddQuestToPlayer(FlowManager.GetInst.m_model.m_curNPC.m_npcName);
    }

    /// <summary>
    /// 현재 선택된 NPC에 따라서 적절하게 퀘스트가 추가 되어야 한다.
    /// </summary>
    /// <param name="_name"></param>
    void AddQuestToPlayer(NPCName _name)
    {        
        for(int i = 0; i < m_model.m_questList.Count;i++)
        {
            Quest que = m_model.m_questList[i];

            if (que.m_parentNPC != _name)
                continue;
            
            if (!que.CheckAccept())
                continue;

            
            PlayerManager.GetInst.AddQuest(que);
        }        
    }
}