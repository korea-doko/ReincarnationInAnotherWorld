using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCActionName
{
    None,
    
    //City
    CityAction1,
    CityAction2,
    //Forest
    ForestAction1,
    //Guild
    GuildAction1,
    //Cathedral
    CathedralAction1,
    //GroceryStore
    GroceryStoreAction1,
    //MagicStore
    MagicStoreAction1,
    //Smithy
    SmithyAction1
}

public interface INPCAction
{
    void EffectNPCACtion();
    List<NPCActionChoice> GetNPCActionChoiceList();
}

[System.Serializable]
public class NPCAction : INPCAction {

    public List<NPCActionChoice> m_choiceList;

    public int m_id;
    public NPCActionName m_npcActionName;
    public string m_desc;
    public NPCName m_parentNPCName;     // 나중에 NPC 이름 확인가능 할 때 따로 초기화 해준다.    


    public NPCAction()
    {
        m_choiceList = new List<NPCActionChoice>();
        m_id = -1;
        m_npcActionName = NPCActionName.None;
        m_desc = "none";
        m_parentNPCName = NPCName.None;
    }

    // 스크립트 만들 때마다 생성자 다 써주기 싫어서.. 
    public void Init(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_desc = _data["Desc"];
    }


    public void AddChoice(NPCActionChoice _choice)
    {
        m_choiceList.Add(_choice);
    }

    public virtual void EffectNPCACtion()
    {

    }
    public virtual List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return m_choiceList;
    }
}

public class NPCAction0 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
public class NPCAction1 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
public class NPCAction2 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
public class NPCAction3 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
public class NPCAction4 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
public class NPCAction5 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
public class NPCAction6 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
public class NPCAction7 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
public class NPCAction8 : NPCAction
{
    public override void EffectNPCACtion()
    {
        base.EffectNPCACtion();
    }
    public override List<NPCActionChoice> GetNPCActionChoiceList()
    {
        return base.GetNPCActionChoiceList();
    }
}
