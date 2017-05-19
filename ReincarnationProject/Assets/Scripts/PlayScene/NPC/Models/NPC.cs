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
    Mark,
    Ellena,
    Daisy,
    Peyton,
    Darion,
    Jerome,
    Allan,
    Cristobal,
    Garrett,
    Kobold,
    Troll,
    DeepForest,
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
        m_desc = "none";
        m_npcName = NPCName.None;
        m_actionList = new List<NPCAction>();
    }
    public void Init(Dictionary<string,string> _data)
    {
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
public class NPC9 : NPC
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
public class NPC10 : NPC
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
public class NPC11 : NPC
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
public class NPC12 : NPC
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
public class NPC13 : NPC
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
public class NPC14 : NPC
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
public class NPC15 : NPC
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
public class NPC16 : NPC
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
public class NPC17 : NPC
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
public class NPC18 : NPC
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
public class NPC19 : NPC
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
public class NPC20 : NPC
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
