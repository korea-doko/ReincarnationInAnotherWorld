using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public enum NPCActionChoiceName
{
     None
    
    ,PlayerIntro1C1 
    ,PlayerIntro1C2 
    ,PlayerIntro1C3 
    ,CityIntro1C1
    ,CityIntro1C2
    ,CityIntro1C3
    ,CityIntro1C4
    ,CityIntro1C5
    ,CityIntro1C6
    ,CityIntro1C7
    ,CityIntro2C1
    ,CityIntro2C2
    ,CityIntro2C3
    ,CityIntro2C4
    ,CityIntro2C5
    ,CityIntro2C6
    ,CityIntro2C7
    ,ForestIntro1C1
    ,ForestIntro1C2
    ,ForestIntro1C3
    ,ForestNormal1C1
    ,ForestNormal1C2
    ,ForestNormal1C3
    ,ForestNormal2C1
    ,ForestNormal2C2
    ,ForestNormal2C3
    ,ForestNormal3C1
    ,ForestNormal3C2
    ,ForestNormal3C3
    ,ForestNormal4C1
    ,ForestNormal4C2
    ,ForestNormal4C3
    ,ForestNormal5C1
    ,ForestNormal5C2
    ,ForestNormal5C3
    ,ForestNormal6C1
    ,ForestNormal6C2
    ,ForestNormal6C3
    ,ForestNormal7C1
    ,ForestNormal7C2
    ,ForestNormal7C3
    ,ForestToGuard1C1
    ,ForestToGuard1C2
    ,ForestToHunter1C1
    ,ForestToHunter1C2
    ,GuildIntro1C1
    ,GuildIntro1C2
    ,SmithyIntro1C1
    ,SmithyIntro1C2
    ,SmithyIntro2C1
    ,SmithyIntro2C2
    ,CathedralIntro1C1
    ,CathedralIntro1C2
    ,CathedralIntro2C1
    ,CathedralIntro2C2
    ,GroceryStoreIntro1C1
    ,GroceryStoreIntro1C2
    ,GroceryStoreIntro2C1
    ,GroceryStoreIntro2C2
    ,MagicStoreIntro1C1
    ,MagicStoreIntro1C2
    ,MagicStoreIntro2C1
    ,MagicStoreIntro2C2
    ,MarkIntro1C1
    ,MarkNormal1C1
    ,EllenaIntro1C1
    ,EllenaIntro1C2
    ,EllenaIntro2C1
    ,EllenaIntro2C2
    ,EllenaNormal1C1
    ,EllenaNormal1C2
    ,EllenaNormal2C1
    ,EllenaNormal2C2
    ,EllenaQuest1C1
    ,EllenaQuest1C2
    ,EllenaQuest2C1
    ,EllenaQuest2C2
    ,EllenaQuestAccept1C1
    ,EllenaQuestAccept1C2
    ,EllenaQuestComplete1C1
    ,EllenaQuestComplete2C1
    ,DaisyIntro1C1
    ,DaisyIntro1C2
    ,DaisyNormal1C1
    ,DaisyNormal1C2
    ,DaisyNormal2C1
    ,DaisyNormal2C2
    ,DaisySelling1C1
    ,DaisySelling1C2
    ,PeytonIntro1C1
    ,PeytonIntro1C2
    ,PeytonNormal1C1
    ,PeytonNormal1C2
    ,PeytonNormal2C1
    ,PeytonNormal2C2
    ,PeytonSellingSword1C1
    ,PeytonSellingSword1C2
    ,PeytonSellingArmor1C1
    ,PeytonSellingArmor1C2
    ,DarionIntro1C1
    ,DarionNormal1C1
    ,DarionNormal1C2
    ,DarionSellingSword1C1
    ,DarionSellingSword1C2
    ,DarionSellingArmor1C1
    ,DarionSellingArmor1C2
    ,JeromeIntro1C1
    ,JeromeIntro1C2
    ,JeromeNormal1C1
    ,JeromeNormal1C2
    ,JeromeNormal1C3
    ,JeromeHealing1C1
    ,JeromeSelling1C1
    ,JeromeSelling1C2
    ,AllanStealing1C1
    ,AllanCaptured1C1
    ,CristobalIntro1C1
    ,CristobalGone1C1
    ,GarrettIntro1C1
    ,GarretGone1C1
    ,DeepForestIntro1C1
    ,DeepForestIntro1C2
    ,DeepForestIntro2C1
    ,DeepForestIntro2C2
    ,DeepForestNormal1C1
    ,DeepForestNormal1C2
    ,DeepForestNormal2C1
    ,DeepForestNormal2C2
    ,DeepForestNormal3C1
    ,DeepForestNormal3C2
    ,DeepForestNormal4C1
    , DeepForestNormal4C2
    , DeepForestMeetKobold1C1
    , DeepForestMeetKobold1C2
    , DeepForestMeetTroll1C1
    ,DeepForestMeetTroll1C2
    ,DeepForestMeetTroll2C1
    ,DeepForestMeetTroll2C2
    ,DeepForestRunaway1C1
    ,DeepForestRunaway1C2
    ,KoboldIntro1C1
    ,KoboldIntro1C2
    ,KoboldIntro1C3
    ,KoboldNormal1C1
    ,KoboldNormal1C2
    ,KoboldNormal1C3
    ,KoboldDie1C1
    ,KoboldDie1C2
    ,TrollIntro1C1
    ,TrollIntro1C2
    ,TrollIntro1C3
    ,TrollNormal1C1
    ,TrollNormal1C2
    ,TrollNormal1C3
    ,TrollDie1C1
    ,TrollDie1C2
    ,DeepForestMeetKobold2C1
    ,DeepForestMeetKobold2C2
}
public interface INPCActionChoice
{
    void CheckNextNPC();
}


[System.Serializable]
public class NPCActionChoice : INPCActionChoice
{
    public NPCActionChoiceName m_npcActionChoiceName;
    public NPCActionName m_parentNPCActionName;

    public string m_desc;
      
    public NPCName m_nextNPCName;
    public NPCActionName m_nextNPCAction;

    public DelCheckNextNPC m_delCheckNextNPC;


    public NPCActionChoice()
    {
        m_desc = "None";
        m_npcActionChoiceName = NPCActionChoiceName.None;
        m_parentNPCActionName = NPCActionName.None;
        m_nextNPCName = NPCName.None;
        m_nextNPCAction = NPCActionName.None;
    }
    public void Init(Dictionary<string,string> _data)
    {
        int id = int.Parse(_data["NPCActionChoiceName"]);
        m_npcActionChoiceName = (NPCActionChoiceName)NPCManager.GetInst.m_model.GetChoiceGivenID(id);

        int parentId = int.Parse(_data["ParentActionName"]);
        m_parentNPCActionName = (NPCActionName)NPCManager.GetInst.m_model.GetActionGivenID(parentId);

        m_desc = _data["Desc"];

        int nextNPCid = int.Parse(_data["NextNPC"]);
        
        m_nextNPCName = (NPCName)NPCManager.GetInst.m_model.GetNPCGivenID(nextNPCid);

        int nextActionid = int.Parse(_data["NextNPCAction"]);
        m_nextNPCAction = (NPCActionName)NPCManager.GetInst.m_model.GetActionGivenID(nextActionid);
    }
    public void CheckNextNPC()
    {
        if (m_nextNPCName != NPCName.None)
            return;

        if (m_delCheckNextNPC == null)
            Debug.Log("무조건 할당 되어 있어야 함");

        m_nextNPCName = m_delCheckNextNPC();
    }
}


