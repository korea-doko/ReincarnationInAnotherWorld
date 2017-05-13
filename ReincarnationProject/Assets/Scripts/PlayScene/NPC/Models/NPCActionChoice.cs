using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCActionChoiceName
{
    None,

    T1A1C1,

    T1A2C1,
    T1A2C2,

    T2A1C1,
    T2A1C2,
    T2A1C3,

    T2A2C1,
    T2A2C2,
    T2A2C3,
    T2A2C4,

    T2A3C1,
    T2A3C2,
    T2A3C3,
    T2A3C4,
    T2A3C5,
}
[System.Serializable]
public class NPCActionChoice
{
    public int m_id;
    public NPCActionChoiceName m_npcActionChoiceName;
    public NPCActionName m_parentNPCActionName;
    
    public NPCActionChoice(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_npcActionChoiceName = (NPCActionChoiceName)System.Enum.Parse(typeof(NPCActionChoiceName), _data["NPCActionChoiceName"]);
        m_parentNPCActionName = (NPCActionName)System.Enum.Parse(typeof(NPCActionName), _data["ParentActionName"]);
    }    
}
