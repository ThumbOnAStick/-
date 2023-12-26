using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmManager : Singleton<FsmManager>
{
    public Dictionary<string, FiniteStateMachine> fsms=new();

    void Start()
    {
        foreach (var fsm in fsms.Values)
        {
            fsm?.Enter();
        }
    }

    void Update()
    {
        foreach (var fsm in fsms.Values)
        {
            fsm?.Update();
        }
    }

    public void Register(string _id, FiniteStateMachine _fsm)
    {
        fsms.TryAdd( _id, _fsm);
    }

    public void Unregister(string _id)
    {
        fsms.Remove(_id);
    }
}
