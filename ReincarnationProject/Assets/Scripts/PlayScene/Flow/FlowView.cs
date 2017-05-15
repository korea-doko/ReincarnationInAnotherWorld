using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowView : MonoBehaviour {

    public FlowManager m_mgr;

    public Text m_testActionText;
    public List<TestButton> m_choiceBtnList;

    public void Init(FlowManager _mgr)
    {
        m_mgr = _mgr;

        m_choiceBtnList = new List<TestButton>();
        
        m_testActionText = GameObject.Find("TestActionPanel").transform.GetChild(0).GetComponent<Text>();

        TestButton[] btns =GameObject.Find("TestChoicePanel").GetComponentsInChildren<TestButton>();

        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].Init(this,i);
            m_choiceBtnList.Add(btns[i]);
        }
    }   
    public void TestButtonClicked(int _id)
    {
        m_mgr.TestBtnClicked(_id);
    }

    public void ChangeTestActionTest(FlowModel _model)
    {
        m_testActionText.text = _model.m_curAction.m_desc;
    }
    public void ChangeTestChoice(FlowModel _model)
    {
        for (int i = 0; i < m_choiceBtnList.Count; i++)
            m_choiceBtnList[i].Hide();

        int numOfChoice = _model.m_curChoiceList.Count;

        for(int i = 0; i < numOfChoice;i++)
            m_choiceBtnList[i].Show(_model.m_curChoiceList[i].m_parentNPCActionName.ToString());
            
    }

}
