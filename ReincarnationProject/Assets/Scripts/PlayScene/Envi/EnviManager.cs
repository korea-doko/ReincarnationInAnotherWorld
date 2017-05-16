using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviManager : MonoBehaviour,IManager {

    public EnviModel m_model;
    public EnviView m_view;

    private static EnviManager m_inst;
    public static EnviManager GetInst
    {
        get { return m_inst; }
    }
    public EnviManager()
    {
        m_inst = this;        
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<EnviModel>("EnviModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<EnviView>("EnviView", this.gameObject);
        m_view.Init();
    }
    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {

    }
    
    public LocationName GetCurLocation()
    {
        return m_model.m_curLocation;
    }
    public WeatherName GetCurWeather()
    {
        return m_model.m_curWeather;
    }
    public TimeName GetCurTime()
    {
        return m_model.m_curTime;
    }

}
