using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum QuestName
{
    None,
    CatchAllan, // 소매치기 잡기 퀘스트, NPC A
    KillKobold, // 코볼트 잡기           NPC A
    KillTroll   // 트롤 잡기             NPC B
}

public interface IQuest
{
    bool CheckAccept();
    // 퀘스트 받는거 확인

    void QuestUpdate();
    // 퀘스트 업데이트, 완료가 되는 중인지 확인

    bool CheckComplete();
    // 퀘스트 깼나 확인
}

[System.Serializable]
public class Quest : IQuest
{
    public NPCName m_parentNPC;

    
    public virtual bool CheckAccept()
    {
        return false;
    }

    public virtual bool CheckComplete()
    {
        return false;
    }

    public virtual void QuestUpdate()
    {

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
    public override void QuestUpdate()
    {
        
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
            return true;

        return false;
    }
    public override void QuestUpdate()
    {

        Debug.Log("1");
    }
    public override bool CheckComplete()
    {
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
        Debug.Log(FlowManager.GetInst.m_model.m_curChoice.m_npcActionChoiceName);
        if (FlowManager.GetInst.m_model.m_curChoice.m_npcActionChoiceName
            == NPCActionChoiceName.EllenaQuest2C1)
            return true;

        return false;
    }
    public override void QuestUpdate()
    {

        Debug.Log("2");
    }
    public override bool CheckComplete()
    {
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
    public override void QuestUpdate()
    {

        Debug.Log("3");
    }
    public override bool CheckComplete()
    {
        return base.CheckComplete();
    }
}
 