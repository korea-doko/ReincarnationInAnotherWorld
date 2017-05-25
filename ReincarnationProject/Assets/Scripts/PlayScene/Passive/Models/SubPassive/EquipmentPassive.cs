using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPassive : Passive
{

    public override void AttachPassive()
    {
        if (!PlayerManager.GetInst.IsPlayerHavingPassive(this))
            PlayerManager.GetInst.AttachPassive(this);
    }
}
public class EquipmentPassive0 : EquipmentPassive
{
    // 검

    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(NPCActionChoiceName.PeytonSellingSword1C1))
            return true;

        return base.CheckAttach();
    }  
    public override bool CheckDetach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(
            NPCActionChoiceName.TrollIntro1C1,
            NPCActionChoiceName.TrollIntro1C2,
            NPCActionChoiceName.TrollNormal1C1,
            NPCActionChoiceName.TrollNormal1C2,
            NPCActionChoiceName.KoboldIntro1C1,
            NPCActionChoiceName.KoboldIntro1C2,
            NPCActionChoiceName.KoboldNormal1C1,
            NPCActionChoiceName.KoboldNormal1C2))
        {
            int random = UnityEngine.Random.Range(0, 100);

            if (random < 20)
                m_curCount--;
        }

        return base.CheckDetach();
    }
}
public class EquipmentPassive1 : EquipmentPassive
{
    // 갑옷
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(NPCActionChoiceName.PeytonSellingArmor1C1))
            return true;

        return base.CheckAttach();
    }
    public override bool CheckDetach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(
            NPCActionChoiceName.TrollIntro1C1,
            NPCActionChoiceName.TrollIntro1C2,
            NPCActionChoiceName.TrollNormal1C1,
            NPCActionChoiceName.TrollNormal1C2,
            NPCActionChoiceName.KoboldIntro1C1,
            NPCActionChoiceName.KoboldIntro1C2,
            NPCActionChoiceName.KoboldNormal1C1,
            NPCActionChoiceName.KoboldNormal1C2))
        {
            int random = UnityEngine.Random.Range(0, 100);

            if (random < 20)
                m_curCount--;
        }

        return base.CheckDetach();
    }
}