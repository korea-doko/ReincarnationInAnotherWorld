using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestModel : MonoBehaviour {

    public List<Quest> m_questList;

    
    public void Init()
    {
        m_questList = new List<Quest>();

        int numOfQuest = System.Enum.GetNames(typeof(QuestName)).Length;

        for (int i = 0; i < numOfQuest; i++)
        {
            string name = "Quest" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            Quest quest = (Quest)obj;                       
            m_questList.Add(quest);
        }
    }

  
}
