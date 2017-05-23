using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour{

    public Status m_status;

    public List<Quest> m_questList;
    public List<Passive> m_passiveList;

    public void Init()
    {
        m_status = new Status(10, 1, 1, 500);
        m_questList = new List<Quest>();
        m_passiveList = new List<Passive>();
    }

    public void AddQuest(Quest _quest)
    {
        m_questList.Add(_quest);
    }
    public void AddPassive(Passive _passive)
    {
        m_status += _passive.m_deltaStatus;
        m_passiveList.Add(_passive);
    }


}
