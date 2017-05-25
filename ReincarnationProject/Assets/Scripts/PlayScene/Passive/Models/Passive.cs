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
    TrollMeet,
    Terror,
    BroadSword,
    Chainmail,
    KoboldBlood,
    FreshWater,
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

    public int m_maxCount;
    public int m_curCount;


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
        m_maxCount = int.Parse(_data["Count"]);
        m_curCount = m_maxCount;
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
        if (m_curCount <= 0)
        {
            Clear();
            return true;
        }
        return false;
    }

    public void Clear()
    {
        m_curCount = m_maxCount;
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
}



