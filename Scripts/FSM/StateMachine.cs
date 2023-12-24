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
    public Action exit_methods;
    public StateMachineLayer self_layer;
    public StateMachineLayer children_layer;

    public StateMachine(string _id,Action _enter, Action _update, Action _exit, StateMachineLayer _self, StateMachineLayer _children = null)
    {
        id = _id;   
        update_methods = _update;
        enter_methods = _enter;
        exit_methods = _exit;   
        self_layer = _self;
        children_layer = _children;
    }

    public void Enter()
    {
        enter_methods?.Invoke();

        var all_conds = self_layer.conditions[id];
        int len = all_conds.Count;
        for (int i = 0; i < len; i++)
        {
            UnPackedCondition condition = all_conds[i];
            void onExitAction()
            {
                Exit();
                self_layer.SwitchToNewState(condition._to);
            }
            EventManager.Instance.TryToRegister(onExitAction, all_conds[i]._target_signal);
            Debug.Log("Registered: "+ all_conds[i]._target_signal);
        }
    }

    public void Update()
    {

        //update myself
        update_methods?.Invoke();
        children_layer?.machines[children_layer.activated_id].Update();
    }

    public void Exit()
    {
        exit_methods?.Invoke();

        var all_conds = self_layer.conditions[id];
        int len = all_conds.Count;
        for (int i = 0; i < len; i++)
        {
            EventManager.Instance.UnAssign(all_conds[i]._target_signal);
        }
    }

    public void ApplyTo()
    {
        self_layer.machines.Add(key: id, value: this);
    }

}

//second created
public class Condition
{
    public List<string> from;
    public List<string> to;
    public string target_signal;
    public StateMachineLayer self_layer;

    public void ApplyTo()
    {
        int len = from.Count;
        for (int i = 0; i < len; i++)
        {
            var conditions = self_layer.conditions;
            UnPackedCondition cond = new() { _to = to[i], _target_signal = target_signal };
            if (conditions.ContainsKey(from[i]))
            {
                conditions[from[i]].Add(cond);
            }
            else
            {
                conditions.Add(from[i], new() { cond });
            }
        }


    }
}

public class UnPackedCondition
{
    public string _to;
    public string _target_signal;    
}

//Combined with state machines and conditions
public class StateMachineLayer
{
    public int id;
    public string activated_id;
    public Dictionary<string, List<UnPackedCondition>> conditions = new();
    public Dictionary<string, StateMachine> machines = new();

    public void SwitchToNewState(string to)
    {
        //Debug.Log("Switch to" + to);
        activated_id = to;
        machines[to].Enter();
    }
    //Action switch_to  = delegate { SwitchToNewState("123"); };
    

    //public void Listen()
    //{
    //}
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

    public static Dictionary<object, SFM> clients = new();

    public static void Register(object _manager,SFM _sfm)
    {
        clients.Add(_manager, _sfm); 
    }

    public static void Init()
    {
        clients = new();
    }
}