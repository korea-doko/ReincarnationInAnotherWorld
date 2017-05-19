using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCActionName
{

     None
    
    ,PlayerIntro1
    ,CityIntro1
    ,CityIntro2
    ,ForestIntro1
    ,ForestNormal1
    ,ForestNormal2
    ,ForestNormal3
    ,ForestNormal4
    ,ForestNormal5
    ,ForestNormal6
    ,ForestNormal7
    ,ForestToGuard1
    ,ForestToHunter1
    ,GuildIntro1
    ,SmithyIntro1
    ,SmithyIntro2
    ,CathedralIntro1
    ,CathedralIntro2
    ,GroceryStoreIntro1
    ,GroceryStoreIntro2
    ,MagicStoreIntro1
    ,MagicStoreIntro2
    ,MarkIntro1
    ,MarkNormal1
    ,EllenaIntro1
    ,EllenaIntro2
    ,EllenaNormal1
    ,EllenaNormal2
    ,EllenaQuest1
    ,EllenaQuest2
    ,EllenaQuestAccept1
    ,EllenaQuestComplete1
    ,EllenaQuestComplete2
    ,DaisyIntro1
    ,DaisyNormal1
    ,DaisyNormal2
    ,DaisySelling1
    ,PeytonIntro1
    ,PeytonNormal1
    ,PeytonNormal2
    ,PeytonSellingSword1
    ,PeytonSellingArmor1
    ,DarionIntro1
    ,DarionNormal1
    ,DarionSellingSword1
    ,DarionSellingArmor1
    ,JeromeIntro1
    ,JeromeNormal1
    ,JeromeHealing1
    ,JeromeSelling1
    ,AllanStealing1
    ,AllanCaptured1
    ,CristobalIntro1
    ,CristobalGone1
    ,GarrettIntro1
    ,GarrettGone1
    ,DeepForestIntro1
    ,DeepForestIntro2
    ,DeepForestNormal1
    ,DeepForestNormal2
    ,DeepForestNormal3
    ,DeepForestNormal4
    ,DeepForestMeetKobold1
    ,DeepForestMeetKobold2
    ,DeepForestMeetTroll1
    ,DeepForestMeetTroll2
    ,KoboldIntro1
    ,KoboldNormal1
    ,KoboldDie1
    ,TrollIntro1
    ,TrollNormal1
    ,TrollDie1
    ,DeepForestRunaway1
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
public class NPCAction9 : NPCAction
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
public class NPCAction10 : NPCAction
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



public class NPCAction11 : NPCAction
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
public class NPCAction12: NPCAction
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
public class NPCAction13: NPCAction
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
public class NPCAction14: NPCAction
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
public class NPCAction15: NPCAction
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
public class NPCAction16: NPCAction
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
public class NPCAction17 : NPCAction
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
public class NPCAction18: NPCAction
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
public class NPCAction19: NPCAction
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
public class NPCAction20 : NPCAction
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



public class NPCAction21: NPCAction
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
public class NPCAction22: NPCAction
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
public class NPCAction23: NPCAction
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
public class NPCAction24: NPCAction
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
public class NPCAction25: NPCAction
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
public class NPCAction26: NPCAction
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
public class NPCAction27: NPCAction
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
public class NPCAction28: NPCAction
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
public class NPCAction29: NPCAction
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
public class NPCAction30: NPCAction
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




public class NPCAction31 : NPCAction
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
public class NPCAction32: NPCAction
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
public class NPCAction33: NPCAction
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
public class NPCAction34: NPCAction
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
public class NPCAction35: NPCAction
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
public class NPCAction36: NPCAction
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
public class NPCAction37: NPCAction
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
public class NPCAction38: NPCAction
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
public class NPCAction39: NPCAction
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
public class NPCAction40: NPCAction
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




public class NPCAction41: NPCAction
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
public class NPCAction42 : NPCAction
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
public class NPCAction43: NPCAction
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
public class NPCAction44: NPCAction
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
public class NPCAction45: NPCAction
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
public class NPCAction46: NPCAction
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
public class NPCAction47: NPCAction
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
public class NPCAction48: NPCAction
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
public class NPCAction49: NPCAction
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
public class NPCAction50: NPCAction
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




public class NPCAction51: NPCAction
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
public class NPCAction52: NPCAction
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
public class NPCAction53 : NPCAction
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
public class NPCAction54: NPCAction
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
public class NPCAction55: NPCAction
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
public class NPCAction56: NPCAction
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
public class NPCAction57: NPCAction
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
public class NPCAction58: NPCAction
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
public class NPCAction59: NPCAction
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
public class NPCAction60: NPCAction
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




public class NPCAction61: NPCAction
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
public class NPCAction62: NPCAction
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
public class NPCAction63: NPCAction
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
public class NPCAction64: NPCAction
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
public class NPCAction65: NPCAction
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
public class NPCAction66: NPCAction
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
public class NPCAction67: NPCAction
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
public class NPCAction68: NPCAction
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
public class NPCAction69: NPCAction
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
public class NPCAction70 : NPCAction
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



public class NPCAction71 : NPCAction
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
public class NPCAction72 : NPCAction
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
public class NPCAction73 : NPCAction
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



