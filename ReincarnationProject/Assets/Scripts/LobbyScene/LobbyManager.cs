using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    private static LobbyManager m_inst;
    public static LobbyManager GetInst
    {
        get { return m_inst; }
    }
    public LobbyManager()
    {
        m_inst = this;
    }

    public void Awake()
    {
        Utils.MakeObjectWithComponent<LobbyUIManager>("LobbyUIManager", this.gameObject);
        LobbyUIManager.GetInst.Init();
    }
}
