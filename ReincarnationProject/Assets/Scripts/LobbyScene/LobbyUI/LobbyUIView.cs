using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LobbyUIView : MonoBehaviour {

    public LobbyButton m_startBtn;

    
    public void Init()
    {
        GameObject prefab = Resources.Load("Lobby/PlayButton") as GameObject;

        m_startBtn = ((GameObject)Instantiate(prefab)).GetComponent<LobbyButton>();
        m_startBtn.Init();
    }
}
