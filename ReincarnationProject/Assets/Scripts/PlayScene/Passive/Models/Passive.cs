using System;
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
    Bread,
    KoboldMeet,
    TrollMeet
}
public interface IPassive
{
    bool CheckAttach();     // 붙이는 것 확인
    void AttachPassive();   // 붙일 때 조건 검사.
    bool CheckDetach();     // 떼는 것 검사.
}
[System.Serializable]
public class Passive : IPassive
{
    public PassiveName m_name;
    public PassiveType m_type;
    public string m_desc;

    public Status m_deltaStatus;
    public int m_count;

    public void Init(Dictionary<string, string> _data)
    {
        int nameID = int.Parse(_data["PassiveName"]);
        m_name = (PassiveName)PassiveManager.GetInst.m_model.GetPassiveNameGivenID(nameID);

        int typeID = int.Parse(_data["PassiveType"]);
        m_type = (PassiveType)PassiveManager.GetInst.m_model.GetPassiveTypeGivenID(typeID);

        m_desc = _data["Desc"];

        //int deltaHP = int.Parse(_data["DeltaHP"]);
        //int deltaDamage = int.Parse(_data["DeltaDamage"]);
        //int deltaDef = int.Parse(_data["DeltaDef"]);
        //int deltaGold = int.Parse(_data["DeltaGold"]);
        //int deltaHunger = int.Parse(_data["DeltaHunger"]);

        m_deltaStatus = new Status(_data);
        m_count = int.Parse(_data["Count"]);
    }

    public virtual bool CheckAttach()
    {
        return false;
    }
    public virtual void AttachPassive()
    {

    }
    public virtual bool CheckDetach()
    {
        if (m_count <= 0)
            return true;

        return false;
    }  
}


public class Passive0 : Passive
{
    public override bool CheckAttach()
    {
        return base.CheckAttach();
    }
    public override void AttachPassive()
    {
        base.AttachPassive();
    }
    public override bool CheckDetach()
    {
        return base.CheckDetach();
    }
}
public class Passive1 : Passive
{
    // 축복
    
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurNPCName(NPCName.Jerome))
            return true;

        return base.CheckAttach();
    }
    public override void AttachPassive()
    {
        if (PlayerManager.GetInst.IsPlayerHavingPassive(m_name))
            PlayerManager.GetInst.DetachPassive(this);

        PlayerManager.GetInst.AttachPassive(this);        
    }
    public override bool CheckDetach()
    {
        m_count--;
        return base.CheckDetach();
    }

}
public class Passive2 : Passive
{
    // 상처
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurNPCName(NPCName.Kobold, NPCName.Troll))
            return true;

        return base.CheckAttach();
    }
    public override void AttachPassive()
    {
        if (PlayerManager.GetInst.IsPlayerHavingPassive(this))
            PlayerManager.GetInst.DetachPassive(this);

        PlayerManager.GetInst.AttachPassive(this);
    }
    public override bool CheckDetach()
    {
        m_count--;

        return base.CheckDetach();
    }  
}
public class Passive3 : Passive
{
    // 검
     
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(NPCActionChoiceName.PeytonSellingSword1C1))
            return true;

        return base.CheckAttach();
    }
    public override void AttachPassive()
    {
        if (!PlayerManager.GetInst.IsPlayerHavingPassive(this))
            PlayerManager.GetInst.AttachPassive(this);
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
                m_count--;
        }
        
        return base.CheckDetach();
    }
}
public class Passive4 : Passive
{
    // 갑옷

    
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(NPCActionChoiceName.PeytonSellingArmor1C1))
            return true;

        return base.CheckAttach();
    }
    public override void AttachPassive()
    {
        if (!PlayerManager.GetInst.IsPlayerHavingPassive(this))
            PlayerManager.GetInst.AttachPassive(this);
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
                m_count--;
        }

        return base.CheckDetach();
    }
}
public class Passive5 : Passive
{
    // 힐링포션
   
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(
            NPCActionChoiceName.JeromeSelling1C1))
            return true;

        return false;
    }
    public override void AttachPassive()
    {
        if (!PlayerManager.GetInst.IsPlayerHavingPassive(this))
            PlayerManager.GetInst.AttachPassive(this);

        m_count++;

    }
    public override bool CheckDetach()
    {
        if( PlayerManager.GetInst.m_model.m_status.m_hp <= 5)
        {
            PlayerManager.GetInst.m_model.m_status += new Status(5, 0, 0, 0,0);
            m_count--;
        }

        return base.CheckDetach();
    }

}
public class Passive6 : Passive
{
    // 빵
    
    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurChoiceName(
            NPCActionChoiceName.DaisySelling1C1))
            return true;

        return base.CheckAttach();
    }
    public override void AttachPassive()
    {
        if (!PlayerManager.GetInst.IsPlayerHavingPassive(this))
            PlayerManager.GetInst.AttachPassive(this);

        m_count++;
                
     }
    public override bool CheckDetach()
    {
        if( PlayerManager.GetInst.m_model.m_status.m_hunger >= 20)
        {
            m_count--;
            PlayerManager.GetInst.m_model.m_status += new Status(0, 0, 0, 0, -10);
        }

        return base.CheckDetach();
    }    
}
public class Passive7 :Passive
{
    //코볼트 고기
   

    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurActionName(
            NPCActionName.KoboldDie1))
            return true;

        return base.CheckAttach();
    }
    public override void AttachPassive()
    {
        if (PlayerManager.GetInst.IsPlayerHavingPassive(this))
            m_count++;

        PlayerManager.GetInst.AttachPassive(this);
    }
    public override bool CheckDetach()
    {
        if( FlowManager.GetInst.CompareCurNPCName(
            NPCName.Ellena))
        {
            PlayerManager.GetInst.m_model.m_status += new Status(0, 0, 0, m_count * 20, 0);
            m_count = 0;
        }

        return base.CheckDetach();
    }
}
public class Passive8 : Passive
{
   //트롤고기   

    public override bool CheckAttach()
    {
        if (FlowManager.GetInst.CompareCurActionName(
            NPCActionName.TrollDie1))
            return true;

        return base.CheckAttach();
    }
    public override void AttachPassive()
    {
        if (PlayerManager.GetInst.IsPlayerHavingPassive(this))
            m_count++;

        PlayerManager.GetInst.AttachPassive(this);
    }
    public override bool CheckDetach()
    {
        if (FlowManager.GetInst.CompareCurNPCName(
            NPCName.Ellena))
        {
            PlayerManager.GetInst.m_model.m_status += new Status(0, 0, 0, m_count * 100, 0);
            m_count = 0;
        }

        return base.CheckDetach();
    }
}
