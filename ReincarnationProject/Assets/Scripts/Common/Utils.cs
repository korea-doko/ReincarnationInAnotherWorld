using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static T MakeObjectWithComponent<T>(string _name = null, GameObject _parent = null) where T : Component
    {

        GameObject temp = new GameObject(_name);

        if (_parent != null)
            temp.transform.SetParent(_parent.transform);

        temp.AddComponent<T>();
        

        return temp.GetComponent<T>();
    }
}
