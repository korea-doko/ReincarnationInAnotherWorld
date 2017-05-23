using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum QuestName
{
    None,
    CatchAllan, // 소매치기 잡기 퀘스트
    KillKobold, // 코볼트 잡기         
    KillTroll   // 트롤 잡기           
}

public interface IQuest
{
    
    bool CheckAccept();
    // 퀘스트 받는거 확인

    
    bool CheckComplete();
    // 퀘스트 깼나 확인
}

[System.Serializable]
public class Quest : IQuest
{
    public QuestName m_questName;
    public NPCName m_parentNPC;
    public bool m_isClear;
    public bool m_isAccepted;

    public void Init(int _id)
    {
        m_questName = (QuestName)_id;
        m_isClear = false;
        m_isAccepted = false;
    }
    
    public virtual bool CheckAccept()
    {
        return m_isAccepted;
    }
    public virtual bool CheckComplete()
    {
        return false;
    } 
}

public class Quest0 : Quest
{
    public Quest0()
    {
        m_parentNPC = NPCName.None;
    }
    public override bool CheckAccept()
    {
        return false;
    }
    public override bool CheckComplete()
    {
        return false;
    }
}
public class Quest1 : Quest
{
    public Quest1()
    {
        m_parentNPC = NPCName.Ellena;
    }
    public override bool CheckAccept()
    {
        if (FlowManager.GetInst.m_model.m_curChoice.m_npcActionChoiceName
            == NPCActionChoiceName.EllenaQuest1C1)
            m_isAccepted = true;


        return base.CheckAccept();

    }
    public override bool CheckComplete()
    {
        if (FlowManager.GetInst.m_model.m_curAction.m_npcActionName
            == NPCActionName.AllanCaptured1)
            m_isClear = true;


        return base.CheckComplete();
    }
}
public class Quest2 : Quest
{
    public Quest2()
    {
        m_parentNPC = NPCName.Ellena;
    }
    public override bool CheckAccept()
    {
        if (FlowManager.GetInst.m_model.m_curChoice.m_npcActionChoiceName
            == NPCActionChoiceName.EllenaQuest2C1)
            m_isAccepted = true;

        return base.CheckAccept();
    }

    public override bool CheckComplete()
    {

        // 코볼트 만나면 퀘스트 깬 걸로
        if (FlowManager.GetInst.m_model.m_curAction.m_npcActionName
            == NPCActionName.KoboldDie1)
            m_isClear = true;

        return base.CheckComplete();
    }
}
public class Quest3 : Quest
{
    public Quest3()
    {

        m_parentNPC = NPCName.Ellena;
    }
    public override bool CheckAccept()
    {
        return base.CheckAccept();
    }

    public override bool CheckComplete()
    {
        return base.CheckComplete();
    }
}
 