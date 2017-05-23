using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PassiveType
{
    None,           
    Buff,           // 스테이터스 변화, 일정기간 가능 
    Equipment,      // 장비 스테이터스 변화, 일정 기간 가능( 턴이 내구도로 사용 )
    Consumption,    // 소비 자동으로 조건에서 사용 됨( 턴 표시가 갯수로 사용 )
    Stack           // 소비 자동으로 판매 가능.
}

public enum PassiveName
{
    None,
    Blessing,
    Injury,
    Sword,
    Armor,
    HealingPotion,
    KoboldMeet
}
public interface IPassive
{
    bool CheckCondition();
}
[System.Serializable]
public class Passive : IPassive
{
    public PassiveName m_name;
    public string m_desc;
    public PassiveType m_type;
    public Status m_deltaStatus;
    public int m_duration;
    public bool m_isAccepted;

    public Passive()
    {

        m_isAccepted = false;
        m_type = PassiveType.None;

        m_duration = 0;
    }
    public Passive(Dictionary<string, string> _data)
    {

        m_type = PassiveType.None;
        m_isAccepted = false;
        m_duration = 0;
    }
  
    
    
    // 패시브 얻는 조건을 만족했냐
    public virtual bool CheckCondition()
    {
        return m_isAccepted;
    }
 
}

public class Passive0 : Passive
{

}
public class Passive1 : Passive
{
    public Passive1()
    {
        m_name = PassiveName.Blessing;
        m_deltaStatus = new Status(1, 1, 1, 0);
        m_desc = m_name.ToString() + "desc";
    }
    // 축복
    public override bool CheckCondition()
    {
        if (FlowManager.GetInst.m_model.m_curNPC.m_npcName
            == NPCName.Jerome)
            m_isAccepted = true;

        return base.CheckCondition();
    }
    
}
public class Passive2 : Passive
{
    public Passive2()
    {
        m_name = PassiveName.Injury;
        m_deltaStatus = new Status(-1, -1, -1, 0);
        m_desc = m_name.ToString() + "desc";
    }
    // 상처
    public override bool CheckCondition()
    {
        if (FlowManager.GetInst.m_model.m_curNPC.m_npcName
            == NPCName.Kobold)
            m_isAccepted = true;
        if (FlowManager.GetInst.m_model.m_curNPC.m_npcName
            == NPCName.Troll)
            m_isAccepted = true;

        return base.CheckCondition();
    }
}
public class Passive3 : Passive
{
    public Passive3()
    {
        m_name = PassiveName.Sword;
        m_deltaStatus = new Status(0, 3, 0, 0);
        m_desc = m_name.ToString() + "desc";
    }
    // 검
    public override bool CheckCondition()
    {
        if (FlowManager.GetInst.m_model.m_curChoice.m_npcActionChoiceName
            == NPCActionChoiceName.PeytonSellingSword1C1)
            m_isAccepted = true;

        return base.CheckCondition();
    }
}
public class Passive4 : Passive
{
    public Passive4()
    {
        m_name = PassiveName.Armor;
        m_deltaStatus = new Status(0, 0, 3, 0);
        m_desc = m_name.ToString() + "desc";
    }
    // 방패
    public override bool CheckCondition()
    {
        if (FlowManager.GetInst.m_model.m_curChoice.m_npcActionChoiceName
            == NPCActionChoiceName.PeytonSellingArmor1C1)
            m_isAccepted = true;


        return base.CheckCondition();
    }
}
public class Passive5 : Passive
{
    public Passive5()
    {
        m_name = PassiveName.HealingPotion;
        m_deltaStatus = new Status();
        m_desc = m_name.ToString() + "desc";
    }
    // 힐링포션
    public override bool CheckCondition()
    {
        if (FlowManager.GetInst.m_model.m_curChoice.m_npcActionChoiceName
            == NPCActionChoiceName.JeromeSelling1C1)
            m_isAccepted = true;

        return base.CheckCondition();
    }
}
public class Passive6 : Passive
{
    public Passive6()
    {
        m_name = PassiveName.KoboldMeet;
        m_deltaStatus = new Status(0, 0, 0, 0);
        m_desc = m_name.ToString() + "desc";
    }
    // 코볼트 고기
    public override bool CheckCondition()
    {
        if (FlowManager.GetInst.m_model.m_curAction.m_npcActionName
            == NPCActionName.TrollDie1)
            m_isAccepted = true;
        if (FlowManager.GetInst.m_model.m_curAction.m_npcActionName
                == NPCActionName.KoboldDie1)
            m_isAccepted = true;

        return base.CheckCondition();
    }
}
