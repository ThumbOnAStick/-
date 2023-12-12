using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Manager : MonoBehaviour
{
    public int index=0;
    public SFM sfm = new();

    //Assign the index
    public virtual void Init()
    {
        SFMInit();
    }

    public virtual void UpdateMethods()
    {

    }

    public virtual void SFMInit()
    {

    }
}
