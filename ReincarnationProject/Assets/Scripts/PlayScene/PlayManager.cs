using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlaySceneManagerName
{
    NPC,
    Input
}

public class PlayManager : MonoBehaviour
{
    public IManager[] m_mgrAry;
    public int m_numOfMgr;

    private static  PlayManager m_inst;
    public static PlayManager GetInst
    {
        get { return m_inst; }
    }
    public PlayManager()
    {
        m_inst = this;
    }

    private void Awake()
    {
        m_numOfMgr = System.Enum.GetNames(typeof(PlaySceneManagerName)).Length;
        m_mgrAry = new IManager[m_numOfMgr];

        for (int i = 0; i < m_numOfMgr; i++)
        {
            string mgrName = ((PlaySceneManagerName)i).ToString() + "Manager";
            GameObject obj = Utils.MakeObjectWithType(mgrName, this.gameObject);
            m_mgrAry[i] = obj.GetComponent<IManager>();

            m_mgrAry[i].AwakeMgr();
        }
    }
    private void Start()
    {
        for (int i = 0; i < m_numOfMgr; i++)
        {
            if (m_mgrAry[i] != null)
                m_mgrAry[i].StartMgr();
        }
    }
    private void Update()
    {
        for(int i = 0; i < m_numOfMgr;i++)
        {
            if (m_mgrAry[i] != null)
                m_mgrAry[i].UpdateMgr();
        }
    }
}
