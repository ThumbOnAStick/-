using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmManager : Singleton<FsmManager>
{
    public Dictionary<string, FiniteStateMachine> fsms=new();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        foreach (var fsm in fsms.Values)
        {
            fsm?.Enter();
        }
    }

    public void UpdateMethods()
    {
        foreach (var fsm in fsms.Values)
        {
            fsm?.Update();
        }
    }

    public void Register(string _id, FiniteStateMachine _fsm)
    {
        fsms.TryAdd( _id, _fsm);
        _fsm.Enter();
    }

    public void Unregister(string _id)
    {
        fsms.Remove(_id);
    }
    public void UnregisterAll()
    {
        fsms = new();
    }

    public FiniteStateMachine Find(string _id)
    {
        FiniteStateMachine fsm=fsms[_id];
        return fsm;
    }
}
