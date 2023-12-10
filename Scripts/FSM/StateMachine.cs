using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//first created
public class StateMachine
{
    public string id;
    //Calls functions from other managers
    Action update_methods;
    public StateMachineLayer self_layer;
    public StateMachineLayer children_layer;


    public void Update()
    {
        //update myself
        update_methods.Invoke();
        children_layer?.machines[children_layer.activated_machine].Update();

        //check condition
        var all_conds =self_layer.conditions[this];
        int len = all_conds.Count;
        for(int i = 0; i < len; i++)
        {
            Condition condition = all_conds[i];
            if (SignalUtility.CapcturedSignal(condition.target_signal))
            {
                self_layer.activated_machine =self_layer.machines.IndexOf(condition.to);
                return;
            }
        }
    }

    public StateMachine(StateMachineData _so, SFMManager _master)
    {
        id=_so.id;
        update_methods =delegate
        {
            _master.Invoke(_so.update_methods,0f);
        };
        self_layer = _master.layers[_so.self_layer];
        children_layer = _master.layers[_so.children_layer];
    }
}

//second created
public class Condition
{
    public StateMachine to;
    public string target_signal;

    public Condition(ConditionData _so, SFMManager _master)
    {
        StateMachineLayer target_layer = _master.layers[_so.self_layer];
     
        to = target_layer.machines[_so.to_id];
        target_signal = _so.target_signal;
    }

}


//combined with state machines and conditions
public class StateMachineLayer
{
    public int id;
    public int activated_machine;
    public Dictionary<StateMachine, List<Condition>> conditions=new();
    public Dictionary<string,StateMachine> machines=new();  

}
