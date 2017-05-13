using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    void AwakeMgr();             // 초기화 할 때, 자신의 멤버변수만 사용
    void StartMgr();            // 초기화 할 때, 다른 곳에 있는 변수 사용할 때
    void UpdateMgr();           // 업데이트
}