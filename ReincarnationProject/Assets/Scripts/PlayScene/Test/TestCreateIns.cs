using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestCreateIns : MonoBehaviour
{
    public List<ABP> m_abplist;

    public void Start()
    {
        
        string name = "PPP";
        object obj = Activator.CreateInstance(Type.GetType(name));
        ABP pp = (ABP)obj;

        pp.Show();
        pp.Show2();
        pp.Show3();

    }
}

public class ABP
{ 
    public virtual void Show()
    {
        Debug.Log("ABP Show");

    }
    public virtual void Show2()
    {
        Debug.Log("ABP SHOW2");
    }
    public virtual void Show3()
    {
        Debug.Log("ABP SHOW3");
    }
}
public class PP : ABP
{
    public override void Show()
    {
        Debug.Log("PP Show");
    }
    public override void Show2()
    {
        Debug.Log("pp show2");
    }
}
public class PPP : PP
{
    public override void Show()
    {
        Debug.Log("ppp show");

        base.Show();
    }
}