using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FlowState
{
    GetNPC,
    // NPC 가져와야 한다.
    NPCEffect,
    // NPC의 효과가 있다면 여기서 보여줘야 한다.
    GetActionInNPC,
    // NPC에 있는 Action을 가져와야 한다.
    ActionEffect,
    // Action의 효과가 있다면 여기서 보여준다.
    GetChoice,
    // Action에서 적절한 선택지를 고른다.
    AwaitPlayer,
    // 플레이어의 결정을 기다린다.
    DoChoice,
    // 플레이어의 결정을 수행한다.
    NotifyOthers
    // 다른 친구들에게 알린다.
}
public class FlowManager : MonoBehaviour,IManager
{      
    public FlowModel m_model;
    public FlowView m_view;

    private static FlowManager m_inst;
    public static FlowManager GetInst
    {
        get { return m_inst; }
    }
    public FlowManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {


        m_model = Utils.MakeObjectWithComponent<FlowModel>("FlowModel", this.gameObject);
        m_model.Init(this);

        m_view = Utils.MakeObjectWithComponent<FlowView>("FlowView", this.gameObject);
        m_view.Init(this);
    }

    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {
        switch (GetCurState())
        {
            case FlowState.GetNPC:
                GetNPC();
                break;
            case FlowState.NPCEffect:
                NPCEffect();
                break;
            case FlowState.GetActionInNPC:
                GetActionInNPC();
                break;
            case FlowState.ActionEffect:
                ActionEffect();
                break;
            case FlowState.GetChoice:
                GetChoice();
                break;
            case FlowState.AwaitPlayer:
                AwaitPlayer();
                break;
            case FlowState.DoChoice:
                DoChoice();
                break;
            case FlowState.NotifyOthers:
                NotifyOhters();
                break;
        }
    }


    public void TestBtnClicked(int _id)
    {
        m_model.m_choiceID = _id;
        ChangeStateTo(FlowState.DoChoice);
    }



    void GetNPC()
    {
        NPC npc = NPCManager.GetInst.GetNPC(m_model.m_nextNPC);

        m_model.SetNPC(npc);

        ChangeStateTo(FlowState.NPCEffect);
    }
    void NPCEffect()
    {
        m_model.m_curNPC.Effect();

        ChangeStateTo(FlowState.GetActionInNPC);
    }
    void GetActionInNPC()
    {
        NPCAction action = m_model.m_curNPC.GetAction();

        m_model.SetNPCAction(action);

        m_view.ChangeTestActionTest(m_model);

        ChangeStateTo(FlowState.ActionEffect);
    }
    void ActionEffect()
    {
        m_model.m_curAction.EffectNPCACtion();

        ChangeStateTo(FlowState.GetChoice);
    }
    void GetChoice()
    {
        List<NPCActionChoice> choiceList = m_model.m_curAction.GetNPCActionChoiceList();

        m_model.SetChoiceList(choiceList);
        m_view.ChangeTestChoice(m_model);


        ChangeStateTo(FlowState.AwaitPlayer);
    }
    void AwaitPlayer()
    {

    }
    void DoChoice()
    {
        // m_model.m_choiceID에 따라서
        // 정해진 Choice를 수행한다.

        ChangeStateTo(FlowState.NotifyOthers);
    }
    void NotifyOhters()
    {

        ChangeStateTo(FlowState.GetNPC);
    }

    FlowState GetCurState()
    {
        return m_model.m_curState;
    }
    void ChangeStateTo(FlowState _state)
    {
        m_model.m_curState = _state;
    }
}