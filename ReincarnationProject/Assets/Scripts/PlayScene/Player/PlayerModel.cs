using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour{

    public Status m_status;

    public List<Quest> m_questList;
    public List<Passive> m_passiveList;

    public void Init()
    {
        m_status = new Status(10, 1, 1, 500,10);
        m_questList = new List<Quest>();
        m_passiveList = new List<Passive>();
    }

    public void AddQuest(Quest _quest)
    {
        m_questList.Add(_quest);
    }
    public void AttachPassive(Passive _passive)
    {
        m_passiveList.Add(_passive);
        m_status += _passive.m_deltaStatus;
    }
    public void DetachPassive(Passive _passive)
    {
        for (int i = 0; i < m_passiveList.Count; i++)
        {
            if (m_passiveList[i].m_name == _passive.m_name)
            {
                m_status -= m_passiveList[i].m_deltaStatus;
                m_passiveList.RemoveAt(i);
                break;
            }
        }
    }
}
