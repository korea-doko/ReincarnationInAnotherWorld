using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour,IManager
{
    public enum FlowState
    {
        CheckCondition,         
        // 다음에 NPC가 꼭 와야하는지, Action이 꼭 와야하는지, 게임이 종료가 됐는지 등..
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
    private FlowState m_curState;

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
        m_curState = FlowState.CheckCondition;

        m_model = Utils.MakeObjectWithComponent<FlowModel>("FlowModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<FlowView>("FlowView", this.gameObject);
        m_view.Init();
    }

    public void StartMgr()
    {

    }

    public void UpdateMgr()
    {
        switch (m_curState)
        {
            case FlowState.CheckCondition:
                CheckCondition();
                break;
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

    void CheckCondition()
    {

    }
    void GetNPC()
    {

    }
    void NPCEffect()
    {

    }
    void GetActionInNPC()
    {

    }
    void ActionEffect()
    {

    }
    void GetChoice()
    {

    }
    void AwaitPlayer()
    {

    }
    void DoChoice()
    {

    }
    void NotifyOhters()
    {

    }
}