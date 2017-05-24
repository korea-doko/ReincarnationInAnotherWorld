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

/// <summary>
/// 이름은 조금 있다.
/// </summary>
public struct NPCActionNameToIntSt
{
    public int m_index;
    public NPCActionName m_actionName;

    public NPCActionNameToIntSt(int _index, NPCActionName _name)
    {
        m_index = _index;
        m_actionName = _name;
    }
   
}

[System.Serializable]
public class NPC : INPC
{
    public List<NPCAction> m_actionList;
    public NPCName m_npcName;
    public string m_desc;
    
    // 위에는 DB에서 가져오는 데이터

        

    public int m_numOfEncount;
    public List<NPCActionNameToIntSt> m_convertList;

    // 필요에 의해서 만듬


    public NPC()
    {
        m_desc = "none";
        m_npcName = NPCName.None;
        m_actionList = new List<NPCAction>();
        m_convertList = new List<NPCActionNameToIntSt>();
    }
    public void Init(Dictionary<string,string> _data)
    {
        int id = int.Parse(_data["NPCName"]);
        m_npcName = (NPCName)NPCManager.GetInst.m_model.GetNPCGivenID(id);

        m_desc = _data["Desc"];

        m_numOfEncount = 0;

    }
    public void AddNPCAction(NPCAction _ac)
    {
        NPCActionNameToIntSt st = new NPCActionNameToIntSt(m_actionList.Count, _ac.m_npcActionName);

        m_convertList.Add(st);
        m_actionList.Add(_ac);
    }
    public NPCAction GetNPCUsingActionName(NPCActionName _name)
    {
        int index = GetIndexUsingActionName(_name);

        return m_actionList[index];
    }

    public NPCAction GetAction(NPCActionName _name)
    {
        for (int i = 0; i < m_actionList.Count; i++)
        {
            if (_name == m_actionList[i].m_npcActionName)
                return m_actionList[i];
        }

        Debug.Log("여기가 발생해서는 안된다.");
        return null;
    }
    public virtual NPCAction GetAction()
    {
        return m_actionList[0];
    }
    public virtual void Effect()
    {
        
    }
    int GetIndexUsingActionName(NPCActionName _name)
    {
        for (int i = 0; i < m_convertList.Count; i++)
        {
            if (m_convertList[i].m_actionName != _name)
                continue;

            return m_convertList[i].m_index;
        }

        return -1;
    }
}

public class NPC0 : NPC
{
    // 없음
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
    // 플레이어
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
    // 도시
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        /*
         *  도시 
         *  1. 계속 위치가 도시일 때 호출하는 것
         *  2. 다른 곳에서 도시로 올 때 호출 하는 액션이 다름.
         *  
         */
        LocationName prev = EnviManager.GetInst.GetPrevLocation();
        LocationName cur = EnviManager.GetInst.GetCurLocation();

        if (prev != cur)
            return GetNPCUsingActionName(NPCActionName.CityIntro1);
        else
            return GetNPCUsingActionName(NPCActionName.CityIntro2);
    }
}
public class NPC3 : NPC
{
    // 숲
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.ForestIntro1);

        while (true)
        {
            int random = UnityEngine.Random.Range(0, m_actionList.Count - 1);

            if (m_actionList[random].m_npcActionName != NPCActionName.ForestIntro1)
                return m_actionList[random];
        }
    }
}
public class NPC4 : NPC
{
    // 모험가 길드
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
    //대장간
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.SmithyIntro1);
        else
            return GetNPCUsingActionName(NPCActionName.SmithyIntro2);

    }
}
public class NPC6 : NPC
{
    // 성당
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.CathedralIntro1);
        else
            return GetNPCUsingActionName(NPCActionName.CathedralIntro2);

    }
}
public class NPC7 : NPC
{
    // 식료품점
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.GroceryStoreIntro1);
        else
            return GetNPCUsingActionName(NPCActionName.GroceryStoreIntro2);
    }
}
public class NPC8 : NPC
{
    //마법도구점
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.MagicStoreIntro1);
        else
            return GetNPCUsingActionName(NPCActionName.MagicStoreIntro2);       
    }
}
public class NPC9 : NPC
{
    // 마크
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.MarkIntro1);
        else
            return GetNPCUsingActionName(NPCActionName.MarkNormal1);
    }
}
public class NPC10 : NPC
{
    // 모험가 길드 접수원 엘레나
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if( FlowManager.GetInst.m_model.m_prevNPC != NPCName.Ellena)
        {
            if (m_numOfEncount == 1)
                return GetNPCUsingActionName(NPCActionName.EllenaIntro1);
            else
                return GetNPCUsingActionName(NPCActionName.EllenaIntro2);
        }
        // 처음 엘레나한테 왔을 때

        if (PlayerManager.GetInst.IsQuestClear(QuestName.KillKobold))
            return GetNPCUsingActionName(NPCActionName.EllenaQuestComplete2);

        if (PlayerManager.GetInst.IsQuestClear(QuestName.CatchAllan))
            return GetNPCUsingActionName(NPCActionName.EllenaQuestComplete1);

        if (FlowManager.GetInst.m_model.m_prevNPCActionChoice == NPCActionChoiceName.EllenaNormal1C1)
            return GetNPCUsingActionName(NPCActionName.EllenaQuest1);

        if (FlowManager.GetInst.m_model.m_prevNPCActionChoice == NPCActionChoiceName.EllenaNormal2C1)
            return GetNPCUsingActionName(NPCActionName.EllenaQuest2);

        int random = UnityEngine.Random.Range(0, 2);
        // 0이면 Normal1 , 1이면 Normal2

        if (random == 0)
            return GetNPCUsingActionName(NPCActionName.EllenaNormal1);
        else
            return GetNPCUsingActionName(NPCActionName.EllenaNormal2);


        Debug.Log("여기까지 오면 안됨");
        return GetNPCUsingActionName(NPCActionName.EllenaIntro2);
    }
}
public class NPC11 : NPC
{
    // 식료품점 주인 데이지
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.DaisyIntro1);

        int random = UnityEngine.Random.Range(0, 3);

        if (random == 0)
            return GetNPCUsingActionName(NPCActionName.DaisyNormal1);
        else if (random == 1)
            return GetNPCUsingActionName(NPCActionName.DaisyNormal2);
        else 
            return GetNPCUsingActionName(NPCActionName.DaisySelling1);
    }
}
public class NPC12 : NPC
{
    // 대장장이 페이튼
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {

        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.PeytonIntro1);

        int random = UnityEngine.Random.Range(0, 2);

        if (FlowManager.GetInst.m_model.m_prevNPCActionChoice == NPCActionChoiceName.PeytonNormal1C1)
        {
            
            if (random == 0)
                return GetNPCUsingActionName(NPCActionName.PeytonSellingArmor1);
            else
                return GetNPCUsingActionName(NPCActionName.PeytonSellingSword1);
        }
        if (FlowManager.GetInst.m_model.m_prevNPCActionChoice == NPCActionChoiceName.PeytonNormal2C1)
        {
            if (random == 0)
                return GetNPCUsingActionName(NPCActionName.PeytonSellingArmor1);
            else
               return  GetNPCUsingActionName(NPCActionName.PeytonSellingSword1);
        }
        // 물건을 산다고 했으면 랜덤하게 판다.

        if (random == 0)
            return GetNPCUsingActionName(NPCActionName.PeytonNormal1);
        else
            return GetNPCUsingActionName(NPCActionName.PeytonNormal2);
    }
}
public class NPC13 : NPC
{
    // 마법사 다리온
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.DarionIntro1);
        int random = UnityEngine.Random.Range(0, 2);

        if( FlowManager.GetInst.m_model.m_prevNPCActionChoice == NPCActionChoiceName.DarionNormal1C1)
        {
            if (random == 0)
                return GetNPCUsingActionName(NPCActionName.DarionSellingArmor1);
            else
                return GetNPCUsingActionName(NPCActionName.DarionSellingSword1);
        }

        return GetNPCUsingActionName(NPCActionName.DarionNormal1);
    }
}
public class NPC14 : NPC
{
    //사제 제롬
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.JeromeIntro1);

        return GetNPCUsingActionName(NPCActionName.JeromeNormal1);
    }
}
public class NPC15 : NPC
{
    // 소매치기 앨런
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        /*
         *  NPC 앨런 , 소매치기
         *  Action 총 2개
         *  
         *  1. 소매치기 하는 것
         *  2. 소매치기 하다가 잡히는 것
         *  
         */
        List<Quest> questList = PlayerManager.GetInst.GetPlayerQuestList();
        
        for(int i = 0; i < questList.Count;i++)
        {
            Quest q = questList[i];

            if (q.m_questName == QuestName.CatchAllan)
                return GetNPCUsingActionName(NPCActionName.AllanStealing1);            
        }

        return GetNPCUsingActionName(NPCActionName.AllanCaptured1);
    }
}
public class NPC16 : NPC
{
    // 사냥꾼 크리스토발
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        NPCName prev = FlowManager.GetInst.m_model.m_prevNPC;

        if (prev == NPCName.Cristobal)
            return GetNPCUsingActionName(NPCActionName.CristobalGone1);

        return GetNPCUsingActionName(NPCActionName.CristobalIntro1);
    }
}
public class NPC17 : NPC
{
    // 경비 대장 개럿
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        NPCName prev = FlowManager.GetInst.m_model.m_prevNPC;

        if (prev == NPCName.Garrett)
            return GetNPCUsingActionName(NPCActionName.GarrettGone1);

        return GetNPCUsingActionName(NPCActionName.GarrettIntro1);
    }
}
public class NPC18 : NPC
{
    // 코볼트
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.KoboldIntro1);

        if (m_numOfEncount == 3)
            return GetNPCUsingActionName(NPCActionName.KoboldDie1);

        return GetNPCUsingActionName(NPCActionName.KoboldNormal1);
    }
}
public class NPC19 : NPC
{
    //트롤
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        if (m_numOfEncount == 1)
            return GetNPCUsingActionName(NPCActionName.TrollIntro1);

        if (m_numOfEncount == 4)
            return GetNPCUsingActionName(NPCActionName.TrollDie1);

        return GetNPCUsingActionName(NPCActionName.TrollNormal1);
    }
}
public class NPC20 : NPC
{
    //깊은 숲
    public override void Effect()
    {

    }
    public override NPCAction GetAction()
    {
        NPCName prevNPC = FlowManager.GetInst.m_model.m_prevNPC;
        NPCName curNPC = FlowManager.GetInst.m_model.m_curNPC.m_npcName;

        if( prevNPC != curNPC)
        {
            if (m_numOfEncount == 1)
                return GetNPCUsingActionName(NPCActionName.DeepForestIntro1);

            return GetNPCUsingActionName(NPCActionName.DeepForestIntro2);
        }

        while(true)
        {
            int random = UnityEngine.Random.Range(0, m_actionList.Count);

            
            NPCActionName acName = m_convertList[random].m_actionName;
            

            if (acName == NPCActionName.DeepForestIntro1)
                continue;
            if (acName == NPCActionName.DeepForestIntro2)
                continue;
            //if (acName == NPCActionName.DeepForestMeetKobold1)
            //    continue;
            //if (acName == NPCActionName.DeepForestMeetKobold2)
            //    continue;
            //if (acName == NPCActionName.DeepForestMeetTroll1)
            //    continue;
            //if (acName == NPCActionName.DeepForestMeetTroll2)
            //    continue;
            if (acName == NPCActionName.DeepForestRunaway1)
                continue;

            return GetNPCUsingActionName(acName);           
        }
    }
}
