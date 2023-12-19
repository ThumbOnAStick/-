using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Windows;

public static class PrefabLoader
{
    public static UnityEngine.Object LoadPrefab(Catagory _catagory, string _name)
    {
        switch (_catagory)
        {
            case Catagory.Prefab:
                GameObject obj = Resources.Load<GameObject>("Prefabs" + "/" + _name);
                return obj;

            case Catagory.SO:
                ScriptableObject obj1 = Resources.Load<ScriptableObject>("SOs" + "/" + _name);
                return obj1;
            default: return null;   
        }



    }

    public enum Catagory {Prefab,SO};  
}
