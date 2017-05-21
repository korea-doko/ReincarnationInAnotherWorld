using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IManager {

    public PlayerModel m_model;
    public PlayerView m_view;
    public static PlayerManager m_inst;
    public static PlayerManager GetInst
    {
        get { return m_inst; }
    }
    public PlayerManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<PlayerModel>("PlayerModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<PlayerView>("PlayerView", this.gameObject);
        m_view.Init();
    }

    public void StartMgr()
    {

    }

    public void UpdateMgr()
    {

    }

    public void AddQuest(Quest _quest)
    {
        m_model.AddQuest(_quest);
    }

}
