using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class SFMManager : ManagerSingleton
{

    [HideInInspector]

    List<KeyValuePair<object, SFM>> clean_clients;

    public override void Init()
    {
        base.Init();
        clean_clients = RegisteredSFM.clients.Where(x => x.Value.layers.Count > 0).ToList();
        foreach (var client in clean_clients)
        {
            client.Value.Enter();
        }
    }



    public override void UpdateMethods()
    {
        base.UpdateMethods();
        foreach (var client in clean_clients)
        {
            client.Value.Update();
        }
    }





}
