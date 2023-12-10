using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFMManager : Manager
{

    [HideInInspector]
    public List<StateMachineLayer> layers = new List<StateMachineLayer>();

    readonly int layer_count=3;
    readonly string data_folder = "SFM/SateMachines/";
    readonly string condition_folder = "SFM/Conditions/";

    

    public override void Init()
    {
        index = 0;
        base.Init();

        //Load state machines and conditions(Combine to layer in the progress)

  
        
    }

    public override void UpdateMethods()
    {
        base.UpdateMethods();
        layers[0].machines[layers[0].activated_machine].Update();
    }

    void LoadAllStateMachines()
    {
        List<StateMachineData> datas = Resources.LoadAll<StateMachineData>(data_folder).ToList();
        foreach (var data in datas)
        {
            //If new layer needs to be added
            if (layers.Count < data.self_layer + 1)
            {
                StateMachineLayer n_layer = new();
                layers.Add(n_layer);
            }
            if (layers.Count < data.children_layer + 1)
            {
                StateMachineLayer n_layer = new();
                layers.Add(n_layer);
            }

            //Create new state machine
            StateMachine new_machine = new(data, this);
            layers[data.self_layer].machines.Add(new_machine);
        }
    }


    void InitStateMachineLayers()
    {
        foreach (var layer in layers)
        {
             
        }
    }

}
