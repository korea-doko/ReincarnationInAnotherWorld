using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTest : MonoBehaviour
{
    private void Start()
    {
        IC c = new C();
        IC2 c2 = new C2();

        c.CommonCheck();
        c2.CommonCheck();
        // 여기서는 부모 것을 콜해야함
        Debug.Log("@@");

        IP ipc = c;
        IP ipc2 = c2;

        ipc.CommonCheck();
        // 여기서는 c의 커먼 체크
        Debug.Log("##");
        ipc2.CommonCheck();
        // 여기서는 c2의 커먼 체크 나와야함

        // 여기서 보면... 상속해서 가상으로 쓸 필요가 없는데??

    }
}

public interface IP
{
    void CommonCheck();
    // 공통 메소드는 인터페이스에 넣고\
    // 자식에서 어떤 것을 체크할 때 다를 수 있음.
    // 일반적이라면 가상함수 쓰는게.. 좋을 수 있음

}
public interface IC :IP
{
    void SpecialIC();
    // 각 타입에 따라서 다른 것들이 존재하면 이것을 인터페이스로 넣는다.
}
public interface IC2 : IP
{
    void SpecialIC2();
    // 각 타입에 따라서 다른 인터페이스에 넣는다.
}
public class P : IP
{
    public int m_count;

    public virtual void CommonCheck()
    {
        Debug.Log("Common Check in Parent");
    }
}
public class C : P, IC
{
    //void IP.CommonCheck()
    //{
    //    // 명시적 콜, 단순히 외부에서 호출 불가능
    //    Debug.Log("Common Check in C1");
    //}
    public void SpecialIC()
    {
        Debug.Log("Special ic");
    }
    public override void CommonCheck()
    {
        Debug.Log("Common Check overriden in C1");
    }
}
public class C2 : P, IC2
{
    void IP.CommonCheck()
    {
        // 명시적 콜, 외부에서 호출 불가
        Debug.Log("Common Check in C2");
    }
    public void SpecialIC2()
    {

        Debug.Log("Special ic2");
    }
    public override void CommonCheck()
    {
        Debug.Log("Common Check overriden in C2");
    }
}
