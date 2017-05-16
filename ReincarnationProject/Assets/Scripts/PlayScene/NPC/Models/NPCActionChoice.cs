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


    public NPCActionChoice(Dictionary<string,string> _data)
    {
        m_id = int.Parse(_data["ID"]);
        m_desc = _data["Desc"];
    }    
}
