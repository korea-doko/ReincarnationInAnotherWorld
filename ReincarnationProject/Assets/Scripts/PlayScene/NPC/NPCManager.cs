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

        Debug.Log("ST NPC");
    }

    public void UpdateMgr()
    {
        Debug.Log("Up NPC");
    }

}
