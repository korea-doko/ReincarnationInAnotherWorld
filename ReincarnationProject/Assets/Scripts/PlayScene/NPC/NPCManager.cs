using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour ,IManager {

    private static NPCManager m_inst;
    public NPCManager()
    {
        m_inst = this;
    }
    public static NPCManager GetInst
    {
        get
        {
            return m_inst;
        }
    }

    public NPCModel m_model;


    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<NPCModel>("NPCModel", this.gameObject);
        m_model.Init();
    }
    public void StartMgr()
    {
        //Debug.Log("ST NPC");
    }
    public void UpdateMgr()
    {
        //Debug.Log("Up NPC");
    }

    public NPC GetNPC(NPCName _name = NPCName.None)
    {
        if (_name != NPCName.None)
            return m_model.GetNPC(_name);

        // 여기서 이제 여러 상황에 따라서 npc를 골라서 넘겨줘야 한다.
        // 테스트를 위해서 랜덤하게 그냥 넘긴다.

        Debug.Log("적당한 친구들이 필요하다. 여기서 조건에 따라서 골라올 수 있게 하기");

        NPCName name = UnityEngine.Random.Range(0, 2) == 0 ? NPCName.T1 : NPCName.T2;

        return m_model.GetNPC(name);
    }

}
