using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Manager : MonoBehaviour
{
    public int index=0;
    public List<SignalListener> listeners = new ();

    public virtual void Init()
    {
       
    }

    public virtual void UpdateMethods()
    {
        foreach (var item in listeners)
        {
            item.Check();
        }
    }

 
}
