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


[System.Serializable]
public class NPC 
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
}

public class NPC0 : NPC
{
    
}

public class NPC1 : NPC
{
}
public class NPC2: NPC
{

}
