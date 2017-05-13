using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyButton : MonoBehaviour
{
    public void Init()
    {
        this.transform.SetParent(GameObject.Find("Canvas").transform);

        RectTransform rect = this.GetComponent<RectTransform>();
        rect.localPosition = Vector2.zero;

    }   	

    public void Clicked()
    {
        SceneManager.GetInst.ChangeSceneTo(SceneName.Play);
    }
}
