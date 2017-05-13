using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    private static SceneManager m_inst;
    public static SceneManager GetInst
    {
        get { return m_inst; }
    }
    public SceneManager()
    {
        m_inst = this;
    }

    public void Init()
    {
        DontDestroyOnLoad(this.gameObject);
        ChangeSceneTo(SceneName.Lobby);
    }

    public void ChangeSceneTo(SceneName _name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)_name, LoadSceneMode.Single);
    }
}
