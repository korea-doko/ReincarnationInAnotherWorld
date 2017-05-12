using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCActionName
{
    None,

    T1A1,
    T1A2,
    T2A1,
    T2A2,
    T2A3
}
[System.Serializable]
public class NPCAction  {

    public List<NPCActionChoice> m_choiceList;

    public int m_id;
    public NPCActionName m_npcActionName;
    public NPCName m_parentNPCName;
    public string m_desc;

    public NPCAction()
    {
        m_choiceList = new List<NPCActionChoice>();
    }

    public void Init(int _enumOfNPCActionName)
    {
        m_npcActionName = (NPCActionName)_enumOfNPCActionName;
    }
    public bool SetData(Dictionary<string,string> _data)
    {
        NPCActionName inputName = (NPCActionName)System.Enum.Parse(typeof(NPCActionName), _data["NPCActionName"]);

        if ((int)inputName != (int)m_npcActionName)
            return false;

        m_id = int.Parse(_data["ID"]);
        m_parentNPCName = (NPCName)System.Enum.Parse(typeof(NPCName), _data["ParentNPC"]);
        m_desc = _data["Desc"];

        return true;
    }
    public void AddChoice(NPCActionChoice _choice)
    {
        m_choiceList.Add(_choice);
    }
}

public class NPCAction0 : NPCAction
{
   

}
public class NPCAction1 : NPCAction
{
  
}
public class NPCAction2 : NPCAction
{

}
public class NPCAction3 : NPCAction
{
}
public class NPCAction4 : NPCAction
{
}
public class NPCAction5 : NPCAction
{
}
