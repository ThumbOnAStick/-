using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance!= null && Instance.gameObject!=null && Instance != this as T)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this as T;
        }
    }
}
