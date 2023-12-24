using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Manager<T> : Singleton<T> where T : MonoBehaviour
{
    public int index=0;

    public virtual void Init()
    {

    }

    public virtual void UpdateMethods()
    {
        //foreach (var item in listeners)
        //{
        //    item.Check();
        //}
    }

 
}
