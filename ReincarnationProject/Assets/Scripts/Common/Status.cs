using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Status
{
    public int m_hp;                // 체력
    public int m_damage;            // 데미지
    public int m_def;               // 방어력
    public int m_gold;              // 골드
    public int m_hunger;            // 배고픔

    public Status()
    {
        m_hp = 0;
        m_damage = 0;
        m_def = 0;
        m_gold = 0;
        m_hunger= 0;
    }
    public Status(int _hp, int _damage, int _def, int _gold,int _hunger)
    {
        m_hp = _hp;
        m_damage = _damage;
        m_def = _def;
        m_gold = _gold;
        m_hunger = _hunger;
    }
    public Status(Dictionary<string,string> _data)
    {
        m_hp = int.Parse(_data["DeltaHP"]);
        m_damage = int.Parse(_data["DeltaDamage"]);
        m_def = int.Parse(_data["DeltaDef"]);
        m_gold = int.Parse(_data["DeltaGold"]);
        m_hunger= int.Parse(_data["DeltaHunger"]);
    }

    public static Status operator +(Status _s1, Status _s2)
    {
        Status temp = new Status();

        temp.m_hp = _s1.m_hp + _s2.m_hp;
        temp.m_damage = _s1.m_damage + _s2.m_damage;
        temp.m_def = _s1.m_def + _s2.m_def;
        temp.m_gold = _s1.m_gold + _s2.m_gold;
        temp.m_hunger = _s1.m_hunger + _s2.m_hunger;

        return temp;
    }
    public static Status operator -(Status _s1, Status _s2)
    {
        Status temp = new Status();

        temp.m_hp = _s1.m_hp - _s2.m_hp;
        temp.m_damage = _s1.m_damage - _s2.m_damage;
        temp.m_def = _s1.m_def - _s2.m_def;
        temp.m_gold = _s1.m_gold - _s2.m_gold;
        temp.m_hunger = _s1.m_hunger - _s2.m_hunger;

        return temp;
    }
    public static Status operator *(int _multiflier, Status _s)
    {
        Status temp = new Status();

        temp.m_hp = _multiflier * _s.m_hp;
        temp.m_damage = _multiflier * _s.m_damage;
        temp.m_def = _multiflier * _s.m_def;
        temp.m_gold  = _multiflier * _s.m_gold;
        temp.m_hunger = _multiflier * _s.m_hunger;

        return temp;
    }
}
