using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 
/// 이 클래스에는 NPCActionChoice에서 조건별로 달라지는 선택지
/// 그것들의 Delegate만들기 위해서 존재한다.
/// 
/// </summary>
public class ConditionalChoice
{
    public static NPCName DelDeepForestMeetKobold1C1()
    {
        int random = UnityEngine.Random.Range(0, 100);

        if (random < 10)
            return NPCName.Kobold;
        else
            return NPCName.DeepForest;

    }
    public static NPCName DelDeepForestMeetTroll1C1()
    {

        Debug.Log("123");
        int random = UnityEngine.Random.Range(0, 100);

        if (random < 10)
            return NPCName.Kobold;
        else
            return NPCName.DeepForest;

    }
    public static NPCName DelDeepForestMeetTroll2C1()
    {

        int random = UnityEngine.Random.Range(0, 100);

        if (random < 10)
            return NPCName.Kobold;
        else
            return NPCName.DeepForest;

    }
    public static NPCName DelKoboldIntro1C3()
    {

        Debug.Log("5");
        int random = UnityEngine.Random.Range(0, 100);

        if (random < 10)
            return NPCName.Kobold;
        else
            return NPCName.DeepForest;

    }
    public static NPCName DelKoboldNormal1C3()
    {
        Debug.Log("4");
        int random = UnityEngine.Random.Range(0, 100);

        if (random < 10)
            return NPCName.Kobold;
        else
            return NPCName.DeepForest;

    }
    public static NPCName DelTrollIntro1C3()
    {
        Debug.Log("3");
        int random = UnityEngine.Random.Range(0, 100);

        if (random < 10)
            return NPCName.Kobold;
        else
            return NPCName.DeepForest;

    }
    public static NPCName DelTrollNormal1C3()
    {
        Debug.Log("2");
        int random = UnityEngine.Random.Range(0, 100);

        if (random < 10)
            return NPCName.Kobold;
        else
            return NPCName.DeepForest;

    }
    public static NPCName DelDeepForestMeetKobold2C1()
    {
        Debug.Log("1");
        int random = UnityEngine.Random.Range(0, 100);

        if (random < 10)
            return NPCName.Kobold;
        else
            return NPCName.DeepForest;

    }

}
