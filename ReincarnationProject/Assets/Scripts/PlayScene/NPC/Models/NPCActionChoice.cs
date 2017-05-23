using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public virtual void CheckNextNPC()
    {
        Debug.Log("pARENT");
    }
}
public class NPCActionChoice0 : NPCActionChoice
{

}
public class NPCActionChoice1 : NPCActionChoice
{
     
}
public class NPCActionChoice2 : NPCActionChoice
{

}
public class NPCActionChoice3 : NPCActionChoice
{

}
public class NPCActionChoice4 : NPCActionChoice
{

}
public class NPCActionChoice5 : NPCActionChoice
{

}
public class NPCActionChoice6 : NPCActionChoice
{

}
public class NPCActionChoice7 : NPCActionChoice
{

}
public class NPCActionChoice8 : NPCActionChoice
{

}
public class NPCActionChoice9 : NPCActionChoice
{

}
public class NPCActionChoice10 : NPCActionChoice
{

}



public class NPCActionChoice11: NPCActionChoice
{

}
public class NPCActionChoice12: NPCActionChoice
{

}
public class NPCActionChoice13: NPCActionChoice
{

}
public class NPCActionChoice14 : NPCActionChoice
{

}
public class NPCActionChoice15: NPCActionChoice
{

}
public class NPCActionChoice16: NPCActionChoice
{

}
public class NPCActionChoice17: NPCActionChoice
{

}
public class NPCActionChoice18: NPCActionChoice
{

}
public class NPCActionChoice19 : NPCActionChoice
{

}
public class NPCActionChoice20 : NPCActionChoice
{

}



public class NPCActionChoice21 : NPCActionChoice
{

}
public class NPCActionChoice22 : NPCActionChoice
{

}
public class NPCActionChoice23 : NPCActionChoice
{

}
public class NPCActionChoice24 : NPCActionChoice
{

}
public class NPCActionChoice25 : NPCActionChoice
{

}
public class NPCActionChoice26 : NPCActionChoice
{

}
public class NPCActionChoice27 : NPCActionChoice
{

}
public class NPCActionChoice28 : NPCActionChoice
{

}
public class NPCActionChoice29 : NPCActionChoice
{

}
public class NPCActionChoice30 : NPCActionChoice
{

}



public class NPCActionChoice31 : NPCActionChoice
{

}
public class NPCActionChoice32 : NPCActionChoice
{

}
public class NPCActionChoice33 : NPCActionChoice
{

}
public class NPCActionChoice34 : NPCActionChoice
{

}
public class NPCActionChoice35 : NPCActionChoice
{

}
public class NPCActionChoice36 : NPCActionChoice
{

}
public class NPCActionChoice37 : NPCActionChoice
{

}
public class NPCActionChoice38 : NPCActionChoice
{

}
public class NPCActionChoice39 : NPCActionChoice
{

}
public class NPCActionChoice40 : NPCActionChoice
{

}



public class NPCActionChoice41 : NPCActionChoice
{

}
public class NPCActionChoice42: NPCActionChoice
{

}
public class NPCActionChoice43 : NPCActionChoice
{

}
public class NPCActionChoice44 : NPCActionChoice
{

}
public class NPCActionChoice45 : NPCActionChoice
{

}
public class NPCActionChoice46 : NPCActionChoice
{

}
public class NPCActionChoice47 : NPCActionChoice
{

}
public class NPCActionChoice48 : NPCActionChoice
{

}
public class NPCActionChoice49 : NPCActionChoice
{

}
public class NPCActionChoice50 : NPCActionChoice
{

}



public class NPCActionChoice51 : NPCActionChoice
{

}
public class NPCActionChoice52 : NPCActionChoice
{

}
public class NPCActionChoice53 : NPCActionChoice
{

}
public class NPCActionChoice54 : NPCActionChoice
{

}
public class NPCActionChoice55 : NPCActionChoice
{

}
public class NPCActionChoice56 : NPCActionChoice
{

}
public class NPCActionChoice57 : NPCActionChoice
{

}
public class NPCActionChoice58 : NPCActionChoice
{

}
public class NPCActionChoice59 : NPCActionChoice
{

}
public class NPCActionChoice60 : NPCActionChoice
{

}



public class NPCActionChoice61 : NPCActionChoice
{

}
public class NPCActionChoice62 : NPCActionChoice
{

}
public class NPCActionChoice63 : NPCActionChoice
{

}
public class NPCActionChoice64 : NPCActionChoice
{

}
public class NPCActionChoice65 : NPCActionChoice
{

}
public class NPCActionChoice66 : NPCActionChoice
{

}
public class NPCActionChoice67 : NPCActionChoice
{

}
public class NPCActionChoice68 : NPCActionChoice
{

}
public class NPCActionChoice69 : NPCActionChoice
{

}
public class NPCActionChoice70 : NPCActionChoice
{

}



public class NPCActionChoice71 : NPCActionChoice
{

}
public class NPCActionChoice72 : NPCActionChoice
{

}
public class NPCActionChoice73 : NPCActionChoice
{

}
public class NPCActionChoice74 : NPCActionChoice
{

}
public class NPCActionChoice75 : NPCActionChoice
{

}
public class NPCActionChoice76 : NPCActionChoice
{

}
public class NPCActionChoice77 : NPCActionChoice
{

}
public class NPCActionChoice78 : NPCActionChoice
{

}
public class NPCActionChoice79 : NPCActionChoice
{

}
public class NPCActionChoice80 : NPCActionChoice
{

}



public class NPCActionChoice81 : NPCActionChoice
{

}
public class NPCActionChoice82 : NPCActionChoice
{

}
public class NPCActionChoice83 : NPCActionChoice
{

}
public class NPCActionChoice84 : NPCActionChoice
{

}
public class NPCActionChoice85 : NPCActionChoice
{

}
public class NPCActionChoice86 : NPCActionChoice
{

}
public class NPCActionChoice87 : NPCActionChoice
{

}
public class NPCActionChoice88 : NPCActionChoice
{

}
public class NPCActionChoice89 : NPCActionChoice
{

}
public class NPCActionChoice90 : NPCActionChoice
{

}



public class NPCActionChoice91 : NPCActionChoice
{

}
public class NPCActionChoice92 : NPCActionChoice
{

}
public class NPCActionChoice93 : NPCActionChoice
{

}
public class NPCActionChoice94 : NPCActionChoice
{

}
public class NPCActionChoice95 : NPCActionChoice
{

}
public class NPCActionChoice96 : NPCActionChoice
{

}
public class NPCActionChoice97 : NPCActionChoice
{

}
public class NPCActionChoice98 : NPCActionChoice
{

}
public class NPCActionChoice99 : NPCActionChoice
{

}
public class NPCActionChoice100 : NPCActionChoice
{

}



public class NPCActionChoice101 : NPCActionChoice
{

}
public class NPCActionChoice102 : NPCActionChoice
{

}
public class NPCActionChoice103 : NPCActionChoice
{

}
public class NPCActionChoice104 : NPCActionChoice
{

}
public class NPCActionChoice105 : NPCActionChoice
{

}
public class NPCActionChoice106 : NPCActionChoice
{

}
public class NPCActionChoice107 : NPCActionChoice
{

}
public class NPCActionChoice108 : NPCActionChoice
{

}
public class NPCActionChoice109 : NPCActionChoice
{

}
public class NPCActionChoice110 : NPCActionChoice
{

}



public class NPCActionChoice111 : NPCActionChoice
{

}
public class NPCActionChoice112 : NPCActionChoice
{

}
public class NPCActionChoice113 : NPCActionChoice
{

}
public class NPCActionChoice114 : NPCActionChoice
{

}
public class NPCActionChoice115 : NPCActionChoice
{

}
public class NPCActionChoice116 : NPCActionChoice
{

}
public class NPCActionChoice117 : NPCActionChoice
{

}
public class NPCActionChoice118 : NPCActionChoice
{

}
public class NPCActionChoice119 : NPCActionChoice
{

}
public class NPCActionChoice120 : NPCActionChoice
{

}



public class NPCActionChoice121 : NPCActionChoice
{

}
public class NPCActionChoice122 : NPCActionChoice
{

}
public class NPCActionChoice123 : NPCActionChoice
{

}
public class NPCActionChoice124 : NPCActionChoice
{

}
public class NPCActionChoice125 : NPCActionChoice
{

}
public class NPCActionChoice126 : NPCActionChoice
{

}
public class NPCActionChoice127 : NPCActionChoice
{

}
public class NPCActionChoice128 : NPCActionChoice
{

}
public class NPCActionChoice129 : NPCActionChoice
{

}
public class NPCActionChoice130 : NPCActionChoice
{

}



public class NPCActionChoice131 : NPCActionChoice
{

}
public class NPCActionChoice132 : NPCActionChoice
{

}
public class NPCActionChoice133 : NPCActionChoice
{
    // 코볼트를 만났는데, 도주 하냐고 물어보는 것.
    public override void CheckNextNPC()
    {
        int random = UnityEngine.Random.Range(0, 100);

        // 25% 로 전투 75% 로 도주
        if (random < 25)
            m_nextNPCName = NPCName.Kobold;
        else
            m_nextNPCName = NPCName.DeepForest;
    }
}
public class NPCActionChoice134 : NPCActionChoice
{

}
public class NPCActionChoice135 : NPCActionChoice
{
    public override void CheckNextNPC()
    {
        int random = UnityEngine.Random.Range(0, 100);

        // 25% 로 전투 75% 로 도주
        if (random < 25)
            m_nextNPCName = NPCName.Troll;
        else
            m_nextNPCName = NPCName.DeepForest;
    }
}
public class NPCActionChoice136 : NPCActionChoice
{

}
public class NPCActionChoice137 : NPCActionChoice
{
    public override void CheckNextNPC()
    {
        int random =UnityEngine.Random.Range(0, 100);

        // 25% 로 전투 75% 로 도주
        if (random < 25)
            m_nextNPCName = NPCName.Troll;
        else
            m_nextNPCName = NPCName.DeepForest;
    }
}
public class NPCActionChoice138 : NPCActionChoice
{

}
public class NPCActionChoice139 : NPCActionChoice
{

}
public class NPCActionChoice140 : NPCActionChoice
{

}



public class NPCActionChoice141 : NPCActionChoice
{

}
public class NPCActionChoice142 : NPCActionChoice
{

}
public class NPCActionChoice143 : NPCActionChoice
{
    public override void CheckNextNPC()
    {
        int random = UnityEngine.Random.Range(0, 100);
        // 25% 로 전투 75% 로 도주
        if (random < 25)
            m_nextNPCName = NPCName.DeepForest;
        else
            m_nextNPCName = NPCName.Kobold;
    }
}
public class NPCActionChoice144 : NPCActionChoice
{

}
public class NPCActionChoice145 : NPCActionChoice
{

}
public class NPCActionChoice146 : NPCActionChoice
{
    public override void CheckNextNPC()
    {
        int random = UnityEngine.Random.Range(0, 100);
        // 25% 로 전투 75% 로 도주
        if (random < 25)
            m_nextNPCName = NPCName.DeepForest;
        else
            m_nextNPCName = NPCName.Kobold;
    }
}
public class NPCActionChoice147 : NPCActionChoice
{

}
public class NPCActionChoice148 : NPCActionChoice
{

}
public class NPCActionChoice149 : NPCActionChoice
{

}
public class NPCActionChoice150 : NPCActionChoice
{

}




public class NPCActionChoice151 : NPCActionChoice
{
    public override void CheckNextNPC()
    {
        int random = UnityEngine.Random.Range(0, 100);
        // 25% 로 전투 75% 로 도주
        if (random < 20)
            m_nextNPCName = NPCName.DeepForest;
        else
            m_nextNPCName = NPCName.Troll;
    }
}
public class NPCActionChoice152 : NPCActionChoice
{

}
public class NPCActionChoice153 : NPCActionChoice
{

}
public class NPCActionChoice154 : NPCActionChoice
{
    public override void CheckNextNPC()
    {
        int random = UnityEngine.Random.Range(0, 100);
        // 25% 로 전투 75% 로 도주
        if (random < 20)
            m_nextNPCName = NPCName.DeepForest;
        else
            m_nextNPCName = NPCName.Troll;
    }
}
public class NPCActionChoice155 : NPCActionChoice
{

}
public class NPCActionChoice156 : NPCActionChoice
{

}
public class NPCActionChoice157 : NPCActionChoice
{
    public override void CheckNextNPC()
    {
        int random = UnityEngine.Random.Range(0, 100);
        
        if (random < 50)
            m_nextNPCName = NPCName.DeepForest;
        else
            m_nextNPCName = NPCName.Troll;
    }
}
public class NPCActionChoice158 : NPCActionChoice
{

}


