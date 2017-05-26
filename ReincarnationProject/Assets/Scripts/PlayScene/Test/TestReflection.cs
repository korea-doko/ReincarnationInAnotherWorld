using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class TestReflection : MonoBehaviour
{

    private void Start()
    {
        Type trType = Type.GetType("TR");
        ConstructorInfo conInfo = trType.GetConstructor(Type.EmptyTypes);
        object trObj = conInfo.Invoke(new object[] { });

        MethodInfo trMethod = trType.GetMethod("Show1");
        //trMethod.Invoke(trObj, new object[] { });
        TrContainer con1 = new TrContainer();
        con1.SetInfo(trMethod);

        MethodInfo trMethod2 = trType.GetMethod("Show2");
        TrContainer con2 = new TrContainer();
        con2.SetInfo(trMethod2);

        con1.CallInfo(trObj, new object[] { });
        con2.CallInfo(trObj, new object[] { });

        DelTest delTest = (DelTest)Delegate.CreateDelegate(typeof(DelTest), trMethod);
        DelTest deltest2 = (DelTest)Delegate.CreateDelegate(typeof(DelTest), trMethod2);
        // 여기서 할 수 있는 것 
        // 만약에 처리하는 애들 함수 다 따로 만들면 동적으로 가져와서 콜 가능
        // 문제점 : delegate로 처리하려 했는데, 만약에 이렇게 된다면
        // method info를 통해서 그냥 가지고 있을 수 있나?
        DelConatiner delCon = new DelConatiner();
        delCon.SetDel(delTest);
        delCon.CallDel();

        DelConatiner delcon2 = new DelConatiner();
        delcon2.SetDel(deltest2);
        delcon2.CallDel();
    }
}

public delegate void DelTest();

public class DelConatiner
{
    public DelTest m_del;

    public void SetDel(DelTest _del)
    {
        m_del = _del;
    }
    public void CallDel()
    {
        if (m_del != null)
            m_del();
    }

}

public class TR
{
    public static void Show1()
    {
        Debug.Log("show1");
    }
    public static void Show2()
    {
        Debug.Log("sWHO2");
    }
}

public class TrContainer
{
    public MethodInfo info;

    public void SetInfo(MethodInfo _info)
    {
        info = _info;
    }
    public void CallInfo(object _obj,object[] _parameters)
    {
        info.Invoke(_obj, _parameters);
    }
}