using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LobbyUIManager : MonoBehaviour
{
    public LobbyUIModel m_model;
    public LobbyUIView m_view;

    private static LobbyUIManager m_inst;
    public static LobbyUIManager GetInst
    {
        get { return m_inst; }
    }
    public LobbyUIManager()
    {
        m_inst = this;
    }
    public void Init()
    {
        m_model = Utils.MakeObjectWithComponent<LobbyUIModel>("LobbyUIModel",this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<LobbyUIView>("LobbyUIView", this.gameObject);
        m_view.Init();
    }
}
