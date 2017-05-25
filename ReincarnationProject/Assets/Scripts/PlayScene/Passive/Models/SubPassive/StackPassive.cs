using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackPassive : Passive
{
    protected bool m_isDetach;
    
    public override void AttachPassive()
    {
        if (PlayerManager.GetInst.IsPlayerHavingPassive(this))
            m_curCount++;
        else
            PlayerManager.GetInst.AttachPassive(this);
    }
    public override bool CheckDetach()
    {
        if(m_isDetach)
        {
            m_isDetach = false;

            PlayerManager.GetInst.m_model.m_status += m_curCount * m_deltaStatus;
            m_curCount = 0;            
        }

        return base.CheckDetach();
    }
}

public class StackPassive0 : StackPassive
{
    //코볼트 고기


    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurActionName(
            NPCActionName.KoboldDie1))
            return true;

        return base.CheckAttach();
    }  
    public override bool CheckDetach()
    {
        if (FlowManager.GetInst.CompareCurNPCName(
            NPCName.Ellena))
            m_isDetach = true;

        return base.CheckDetach();
    }
}
public class StackPassive1 : StackPassive
{
    //트롤고기   

    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurActionName(
            NPCActionName.TrollDie1))
            return true;

        return base.CheckAttach();
    }
    public override bool CheckDetach()
    {
        if (FlowManager.GetInst.CompareCurNPCName(
            NPCName.Ellena))
            m_isDetach = true;

        return base.CheckDetach();
    }
}
public class StackPassive2 : StackPassive
{
    // 코볼트 피
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurActionName(
            NPCActionName.KoboldDie1))
        {
            int random = UnityEngine.Random.Range(0, 100);

            if (random < 10)
                return true;
                 
        }
            
        return base.CheckAttach();
    }
    public override bool CheckDetach()
    {
        if (FlowManager.GetInst.CompareCurNPCName(
            NPCName.Ellena))
            m_isDetach = true;

        return base.CheckDetach();
    }
}