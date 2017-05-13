using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

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

    private void Start()
    {
        GameObject temp = new GameObject("NPCModel");
        temp.AddComponent<NPCModel>();

        m_model = temp.GetComponent<NPCModel>();
        m_model.Init();
        
    }

}
