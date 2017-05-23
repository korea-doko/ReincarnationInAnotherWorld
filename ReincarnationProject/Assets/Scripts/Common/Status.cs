﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Status
{
    public int m_hp;
    public int m_damage;
    public int m_def;
    public int m_gold;

    public Status()
    {
        m_hp = 0;
        m_damage = 0;
        m_def = 0;
        m_gold = 0;
    }
    public Status(int _hp, int _damage, int _def, int _gold)
    {
        m_hp = _hp;
        m_damage = _damage;
        m_def = _def;
        m_gold = _gold;
    }

    public static Status operator+(Status _s1,Status _s2)
    {
        Status temp = new Status();

        temp.m_hp = _s1.m_hp + _s2.m_hp;
        temp.m_damage = _s1.m_damage + _s2.m_damage;
        temp.m_def = _s1.m_def + _s2.m_def;
        temp.m_gold = _s1.m_gold + _s2.m_gold;

        return temp;
    }
}
