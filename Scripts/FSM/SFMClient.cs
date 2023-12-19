using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFMClientManager: Manager
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
    }


}

