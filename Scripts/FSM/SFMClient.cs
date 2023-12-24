using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFMClientManager<T>: Manager<T> where T : MonoBehaviour
{
    public SFM sfm = new();

    public override void Init()
    {
        base.Init();
        SFMInit();
    }
    public override void UpdateMethods()
    {
        base.UpdateMethods();
    }

    public virtual void SFMInit()
    {
        RegisteredSFM.clients.Add(this, sfm);
        //sfm.layers[0]?.machines[sfm.layers[0].activated_id]?.Enter();
    }


}

