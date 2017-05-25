using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumptionPassive : Passive
{

    public override void AttachPassive()
    {
        if (!PlayerManager.GetInst.IsPlayerHavingPassive(this))
            PlayerManager.GetInst.AttachPassive(this);
        else
            m_curCount++;

    }
}
public class ConsumptionPassive0 : ConsumptionPassive
{
    // 힐링포션

    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(
            NPCActionChoiceName.JeromeSelling1C1))
            return true;

        return false;
    }
    public override bool CheckDetach()
    {
        if (PlayerManager.GetInst.m_model.m_status.m_hp <= 5)
        {
            PlayerManager.GetInst.m_model.m_status += m_deltaStatus;
            m_curCount--;
        }

        return base.CheckDetach();
    }
}
public class ConsumptionPassive1 : ConsumptionPassive 
{
    // 빵

    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(
            NPCActionChoiceName.DaisySelling1C1))
            return true;

        return base.CheckAttach();
    } 
    public override bool CheckDetach()
    {
        if (PlayerManager.GetInst.m_model.m_status.m_hunger >= 20)
        {
            m_curCount--;

            PlayerManager.GetInst.m_model.m_status += m_deltaStatus;
        }

        return base.CheckDetach();
    }
}
public class ConsumptionPassive2 : ConsumptionPassive
{
    // 신선한 물

    public override bool CheckAttach()
    {
        if( FlowManager.GetInst.CompareCurNPCName(
            NPCName.Forest,
            NPCName.DeepForest))
        {
            int random = UnityEngine.Random.Range(0, 100);

            if (random < 20)
                return true;

        }
        return base.CheckAttach();
    }
    public override bool CheckDetach()
    {
        if (PlayerManager.GetInst.m_model.m_status.m_hunger >= 20)
        {
            m_curCount--;

            PlayerManager.GetInst.m_model.m_status += m_deltaStatus;
        }
        return base.CheckDetach();
    }
}