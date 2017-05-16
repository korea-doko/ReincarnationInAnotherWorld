using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCName
{
    None,
    Player,
    City,
    Forest,
    Guild,
    Smithy,
    Cathedral,
    GroceryStore,
    MagicStore,
}

public interface INPC
{
    void Effect();
    NPCAction GetAction();
}

[System.Serializable]
public class NPC : INPC
{
    public List<NPCAction> m_actionList;
    public NPCName m_npcName;
    public string m_desc;
    
    public NPC()
    {
        m_actionList = new List<NPCAction>();
    }
    public void Init(Dictionary<string,string> _data)
    {
        Debug.Log(_data["Desc"]);
        m_desc = _data["Desc"];
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
        int randomIndex = UnityEngine.Random.Range(0, m_actionList.Count);

        return m_actionList[randomIndex];
    }
}
public class NPC2 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_actionList.Count);

        return m_actionList[randomIndex];
    }
}
public class NPC3 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_actionList.Count);

        return m_actionList[randomIndex];
    }
}
public class NPC4 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_actionList.Count);

        return m_actionList[randomIndex];
    }
}
public class NPC5 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_actionList.Count);

        return m_actionList[randomIndex];
    }
}
public class NPC6 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_actionList.Count);

        return m_actionList[randomIndex];
    }
}
public class NPC7 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_actionList.Count);

        return m_actionList[randomIndex];
    }
}
public class NPC8 : NPC
{
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        int randomIndex = UnityEngine.Random.Range(0, m_actionList.Count);

        return m_actionList[randomIndex];
    }
}
