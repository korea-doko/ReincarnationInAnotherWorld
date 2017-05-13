using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NPCModel : MonoBehaviour
{
    public List<NPC> m_npcList;

    
    public void Init()
    {
        NPCActionChoiceFactory NPCChoiceFactory = new NPCActionChoiceFactory();
        NPCActionFactory NPCActionFactory = new NPCActionFactory(NPCChoiceFactory);
        NPCFactory NPCFactory = new NPCFactory(NPCActionFactory);

        m_npcList = NPCFactory.GetInitailizedNPCList();
    }

}
