using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour ,IManager{

    public InputModel m_model;
    public InputView m_view;

    private InputManager m_inst;
	public InputManager GetInst
    {
        get { return m_inst; }
    }
    public InputManager()
    {
        m_inst = this ;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<InputModel>("InputModel", this.gameObject);

        m_view = Utils.MakeObjectWithComponent<InputView>("InputView", this.gameObject);
    }

    public void StartMgr()
    {
        Debug.Log("St Input");
    }
    public void UpdateMgr()
    {
        if( Input.GetMouseButton(0))
        {

        }
    }
}
