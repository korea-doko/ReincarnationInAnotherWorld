using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PassiveModel : MonoBehaviour
{
    public List<Passive> m_passiveList;
    

    public void Init()
    {
        m_passiveList = new List<Passive>();

        /*
            public string m_name;
            public string m_desc;
            public PassiveType m_type;
            public Status m_deltaStatus;
            public int m_duration;
         */

        int numOfPassive = Enum.GetNames(typeof(PassiveName)).Length;

        for (int i = 0; i < numOfPassive; i++)
        {
            string name = "Passive" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            Passive p = (Passive)obj;
            m_passiveList.Add(p);
        }


    }
}
