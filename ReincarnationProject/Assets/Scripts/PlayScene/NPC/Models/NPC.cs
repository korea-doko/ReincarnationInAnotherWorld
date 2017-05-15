using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCName
{
    None,
    T1,
    T2
}

public interface INPC
{
    void Effect();
    NPCAction GetAction();
}

[System.Serializable]
public class NPC : INPC
{
    public NPCName m_name;
    public List<NPCAction> m_actionList;

    public NPC()
    {
        m_actionList = new List<NPCAction>();
    }
    public void Init(int _enumOfNPCNameIndex)
    {
        m_name = (NPCName)_enumOfNPCNameIndex;
    }
    public void AddNPCAction(NPCAction _ac)
    {
        m_actionList.Add(_ac);
    }

    public virtual void Effect()
    {

    }
    public virtual NPCAction GetAction()
    {
        return m_actionList[0];
    }
}

public class NPC0 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        return base.GetAction();
    }
}
public class NPC1 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        return base.GetAction();
    }
}
public class NPC2: NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        return base.GetAction();
    }
}
