using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCActionChoiceName
{
    None,

    CityAction1Choice1,
    CityAction1Choice2,
    CityAction1Choice3,
    CityAction1Choice4,
    CityAction1Choice5,
    CityAction1Choice6,
    CityAction1Choice7,
    CityAction2Choice1,
    CityAction2Choice2,
    CityAction2Choice3,
    CityAction2Choice4,
    CityAction2Choice5,
    CityAction2Choice6,
    CityAction2Choice7,
    ForestAction1Choice1,
    ForestAction1Choice2,
    ForestAction1Choice3,
    GuildAction1Choice1,
    GuildAction1Choice2,
    CathedralAction1Choice1,
    CathedralAction1Choice2,
    GroceryStoreAction1Choice1,
    GroceryStoreAction1Choice2,
    MagicStoreAction1Choice1,
    MagicStoreAction1Choice2,
    SmithyAction1Choice1,
    SmithyAction1Choice2
}
[System.Serializable]
public class NPCActionChoice
{
    public int m_id;
    public string m_desc;
    
    // 나중에 따로 초기화
    public NPCActionChoiceName m_npcActionChoiceName;
    public NPCActionName m_parentNPCActionName;

    public NPCActionChoice()
    {
        m_id = -1;
        m_desc = "None";
        m_npcActionChoiceName = NPCActionChoiceName.None;
        m_parentNPCActionName = NPCActionName.None;
    }
    
    public void Init(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_desc = _data["Desc"];
    }
}
public class NPCActionChoice0 : NPCActionChoice
{

}
public class NPCActionChoice1 : NPCActionChoice
{

}
public class NPCActionChoice2 : NPCActionChoice
{

}
public class NPCActionChoice3 : NPCActionChoice
{

}
public class NPCActionChoice4 : NPCActionChoice
{

}
public class NPCActionChoice5 : NPCActionChoice
{

}
public class NPCActionChoice6 : NPCActionChoice
{

}
public class NPCActionChoice7 : NPCActionChoice
{

}
public class NPCActionChoice8 : NPCActionChoice
{

}
public class NPCActionChoice9 : NPCActionChoice
{

}
public class NPCActionChoice10 : NPCActionChoice
{

}
public class NPCActionChoice11: NPCActionChoice
{

}
public class NPCActionChoice12: NPCActionChoice
{

}
public class NPCActionChoice13: NPCActionChoice
{

}
public class NPCActionChoice14 : NPCActionChoice
{

}
public class NPCActionChoice15: NPCActionChoice
{

}
public class NPCActionChoice16: NPCActionChoice
{

}
public class NPCActionChoice17: NPCActionChoice
{

}
public class NPCActionChoice18: NPCActionChoice
{

}
public class NPCActionChoice19 : NPCActionChoice
{

}
public class NPCActionChoice20 : NPCActionChoice
{

}
public class NPCActionChoice21: NPCActionChoice
{

}
public class NPCActionChoice22: NPCActionChoice
{

}
public class NPCActionChoice23: NPCActionChoice
{

}
public class NPCActionChoice24: NPCActionChoice
{

}
public class NPCActionChoice25: NPCActionChoice
{

}
public class NPCActionChoice26: NPCActionChoice
{

}
public class NPCActionChoice27 : NPCActionChoice
{

}
