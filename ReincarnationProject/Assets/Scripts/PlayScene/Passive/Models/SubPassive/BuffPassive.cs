using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuffPassive : Passive
{
    public override void AttachPassive()
    {
        if (PlayerManager.GetInst.IsPlayerHavingPassive(m_name))
            PlayerManager.GetInst.DetachPassive(this);

        PlayerManager.GetInst.AttachPassive(this);
    }
    public override bool CheckDetach()
    {
        m_curCount--;
        return base.CheckDetach();
    }
}
public class BuffPassive0 : BuffPassive
{
    // 축복

    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurNPCName(NPCName.Jerome))
            return true;

        return base.CheckAttach();
    }
}
public class BuffPassive1 : BuffPassive
{
    // 상처
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurNPCName(NPCName.Kobold, NPCName.Troll))
            return true;

        return base.CheckAttach();
    }  
}