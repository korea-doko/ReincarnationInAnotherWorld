using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCFactory
{

    public List<NPC> m_npcList;

    public NPCFactory(NPCActionFactory _actionFactory)
    {
        m_npcList = new List<NPC>();
        int numOfNPC = Enum.GetNames(typeof(NPCName)).Length;

        for (int i = 0; i < numOfNPC; i++)
        {
            string name = "NPC" + i.ToString();
            object obj = Activator.CreateInstance(Type.GetType(name));
            NPC npc = (NPC)obj;
            npc.Init(i);
            m_npcList.Add(npc);
        }

        for(int i = 0; i < _actionFactory.m_actionList.Count;i++)
        {
            NPCAction ac = _actionFactory.m_actionList[i];

            NPC npc = m_npcList[(int)ac.m_parentNPCName];

            npc.AddNPCAction(ac);
        }
    }
    
    public List<NPC> GetInitailizedNPCList()
    {
        return m_npcList;
    }
}
