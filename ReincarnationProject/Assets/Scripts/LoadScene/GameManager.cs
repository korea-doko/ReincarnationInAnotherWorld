using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SceneName
{
    Load,
    Lobby,
    Play,
    Result
}
public class GameManager : MonoBehaviour
{
    public GameManager GetInst
    {
        get { return m_inst; }
    }
    private GameManager m_inst;
    public GameManager()
    {
        m_inst = this;
    }
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        Utils.MakeObjectWithComponent<SceneManager>("SceneManager",this.gameObject);
        SceneManager.GetInst.Init();
    }
}
