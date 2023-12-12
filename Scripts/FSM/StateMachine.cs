using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

//first created
public class StateMachine
{
    public string id;
    //Calls functions from other managers
    public Action update_methods;
    public Action enter_methods;
    public StateMachineLayer self_layer;
    public StateMachineLayer children_layer;

    public void Enter()
    {
        enter_methods.Invoke();
    }

    public void Update()
    {
        //check condition
        var all_conds =self_layer.conditions[id];
        int len = all_conds.Count;
        for(int i = 0; i < len; i++)
        {
            Condition condition = all_conds[i];
            if (SignalUtility.CapcturedSignal(condition.target_signal))
            {
                self_layer.SwitchToNewState(condition.to);   
                return;
            }
        }

        //update myself
        update_methods.Invoke();
        children_layer?.machines[children_layer.activated_id].Update();

    }

 
}

//second created
public class Condition
{
    public string to;
    public string target_signal;

    public Condition(ConditionData _so, SFM _master)
    {
        StateMachineLayer target_layer = _master.layers[_so.self_layer];
     
        to = _so.to_id;
        target_signal = _so.target_signal;
    }

}

//Combined with state machines and conditions
public class StateMachineLayer
{
    public int id;
    public string activated_id;
    public Dictionary<string, List<Condition>> conditions = new();
    public Dictionary<string, StateMachine> machines = new();

    public void SwitchToNewState(string to)
    {
        activated_id = to;
        machines[to].Enter();
    }
}

//One single SFM
public class SFM
{
    public List<StateMachineLayer> layers = new();

    public void Enter()
    {
        layers[0].machines[layers[0].activated_id].Enter();
    }

    public void Update()
    {
        layers[0].machines[layers[0].activated_id].Update();
    }
}

public static class RegisteredSFM
{
    public static int desired_registers = 1;

    public static Dictionary<Manager, SFM> clients = new();

    public static void Register(Manager _manager,SFM _sfm)
    {
        clients.Add(_manager, _sfm); 
    }
}