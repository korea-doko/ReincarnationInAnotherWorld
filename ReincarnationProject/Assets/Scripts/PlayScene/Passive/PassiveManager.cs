using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveManager : MonoBehaviour,IManager {

    public PassiveModel m_model;
    public PassiveView m_view;

    private static PassiveManager m_inst;
    public static PassiveManager GetInst
    {
        get { return m_inst; }
    }
    public PassiveManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<PassiveModel>("PassiveModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<PassiveView>("PassiveView", this.gameObject);
        m_view.Init();
    }

    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {

    }


    public void Notified()
    {
        CheckPassiveToBeApplied();
    }

    void CheckPassiveToBeApplied()
    {
        List<Passive> passiveList = m_model.m_passiveList;

        for(int i = 0; i < passiveList.Count;i++)
        {
            Passive p = passiveList[i];

            if (p.m_isAccepted)
                continue;

            if (p.CheckCondition())
                PlayerManager.GetInst.AddPassive(p);            
        }
    }




}
