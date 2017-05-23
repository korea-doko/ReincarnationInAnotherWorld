using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour{

    public List<Quest> m_questList;

    public void Init()
    {
        m_questList = new List<Quest>();
    }

    public void AddQuest(Quest _quest)
    {
        m_questList.Add(_quest);
    }

}
