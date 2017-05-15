using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestButton : MonoBehaviour {

    public Text m_text;
    public FlowView m_view;
    public int m_id;
    public void Init(FlowView _view,int _id)
    {
        m_text = this.transform.GetChild(0).GetComponent<Text>();
        m_view = _view;
        m_id = _id;
        m_text.text = "";
    }

    public void Clicked()
    {
        m_view.TestButtonClicked(m_id);
    }
    public void Hide()
    {
        m_text.text = "";
        this.gameObject.SetActive(false);
    }
    public void Show(string _text)
    {
        m_text.text = _text;
        this.gameObject.SetActive(true);
    }
}
