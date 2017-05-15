using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowModel : MonoBehaviour
{
    public NPC m_curNPC;
    public NPCAction m_curAction;
    public List<NPCActionChoice> m_curChoiceList;
    public FlowState m_curState;

    public NPCName m_nextNPC;
    public NPCActionName m_nextNPCAction;

    public void Init()
    {       
        m_curNPC = null;
        m_curAction = null;
        m_curChoiceList = null;
        m_curState = FlowState.GetNPC;

        m_nextNPC = NPCName.None;
        m_nextNPCAction = NPCActionName.None;
    }

    public void SetNPC(NPC _curNPC)
    {
        m_curNPC = _curNPC;
    }
    public void SetNPCAction(NPCAction _curNPCAction)
    {
        m_curAction = _curNPCAction;
    }
    public void SetChoiceList(List<NPCActionChoice> _choiceList)
    {
        m_curChoiceList = _choiceList; 
    }

}
