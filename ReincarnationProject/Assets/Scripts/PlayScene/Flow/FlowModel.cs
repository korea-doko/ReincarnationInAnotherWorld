using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowModel : MonoBehaviour
{
    public FlowManager m_mgr;

    public NPC m_curNPC;
    public NPCAction m_curAction;
    public List<NPCActionChoice> m_curChoiceList;

    public NPCActionChoice m_curChoice;

    public FlowState m_curState;

    public NPCName m_prevNPC;
    public NPCActionName m_prevNPCAction;
    public NPCActionChoiceName m_prevNPCActionChoice;

    public NPCName m_nextNPC;
    public NPCActionName m_nextNPCAction;


    public void Init(FlowManager _mgr)
    {
        m_mgr = _mgr;

        m_curNPC = null;
        m_curAction = null;
        m_curChoiceList = null;
        m_curState = FlowState.GetNPC;

        m_curChoice = null;

        m_prevNPC = NPCName.None;
        m_prevNPCAction = NPCActionName.None;
        m_prevNPCActionChoice = NPCActionChoiceName.None;

        m_nextNPC = NPCName.Player;
        m_nextNPCAction = NPCActionName.PlayerIntro1;
    }

    public void SetNPC(NPC _curNPC)
    {
        if ( m_curNPC != null)
            m_prevNPC = m_curNPC.m_npcName;

        m_curNPC = _curNPC;

        m_nextNPC = NPCName.None;
        m_nextNPCAction = NPCActionName.None;
    }
    public void SetNPCAction(NPCAction _curNPCAction)
    {
        if (m_curAction != null)
            m_prevNPCAction = m_curAction.m_npcActionName;

        m_curAction = _curNPCAction;
    }
    public void SetChoiceList(List<NPCActionChoice> _choiceList)
    {
        m_curChoiceList = _choiceList;
    }
    public void SetCurChoice(int _curChoiceIndex)
    {
        if (m_curChoice != null)
            m_prevNPCActionChoice = m_curChoice.m_npcActionChoiceName;

        m_curChoice = m_curChoiceList[_curChoiceIndex];
    }
    public void CheckChoiceNextNPC()
    {
        m_curChoice.CheckNextNPC();

        m_nextNPC = m_curChoice.m_nextNPCName;
        m_nextNPCAction = m_curChoice.m_nextNPCAction;
    }


}
