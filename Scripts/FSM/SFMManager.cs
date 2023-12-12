using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFMManager : Manager
{

    [HideInInspector]
    
    public override void Init()
    {
        base.Init();
    }



    public override void UpdateMethods()
    {
        base.UpdateMethods();
        foreach(var client in RegisteredSFM.clients)
        {
            client.Value.Update();
        }
    }

    



}
