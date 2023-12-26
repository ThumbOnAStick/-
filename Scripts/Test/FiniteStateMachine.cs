using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.PlayerLoop;
using UnityEngine.Windows;


/// <summary>
/// ����״̬�������ж��״̬���ܵ�FsmManager����
/// </summary>
public class FiniteStateMachine 
{
    //��ǰ״̬
    string activeState;
    //�������е�״̬��
    public Dictionary<string, State> stateDic=new();

    public FiniteStateMachine(string _firstState)
    {
        activeState = _firstState;
    }

    public void Enter()
    {
        stateDic[activeState]?.Enter();
    }
    public void Update()
    {
        stateDic[activeState]?.Update();
    }
    public void Exit()
    {

        stateDic[activeState]?.Exit();

    }

    //public void CreateStates(List<string> _id, List<List<string>> _inputs, List<List<string>> _targets,
    //    List<Action> _enters = null, List<Action> _updates = null, List<Action> _exits = null, List<FiniteStateMachine> _childFsm = null)
    //{
    //    for (int i = 0; i < _id.Count; i++)
    //    {

    //        Action enter;
    //        if (_enters != null)
    //        {
    //            enter = _enters[i];
    //        }

    //        Action update;
    //        if (_enters != null)
    //        {
    //            update = _enters[i];
    //        }

    //        Action exit;
    //        if (_enters != null)
    //        {
    //            update = _enters[i];
    //        }


    //    }
    //}

    /// <summary>
    /// �����µ�״̬��
    /// </summary>
    /// <param name="_id"></param>
    /// <param name="_inputs"></param>
    /// <param name="_targets"></param>
    /// <param name="_enter"></param>
    /// <param name="_update"></param>
    /// <param name="_exit"></param>
    /// <param name="_childFsm"></param>
    public void CreateState(string _id, List<string> _inputs, List<string> _targets, Action _enter = null, Action _update = null, Action _exit = null, FiniteStateMachine _childFsm = null)
    {
        State newState = new(_id, _inputs, _targets, _enter, _update, _exit, _childFsm);
        if(stateDic.ContainsKey(_id) )
        {
            Debug.LogError("id �Ѿ�����");
            return;
        }
        newState.myFsm = this;
        stateDic.Add(_id, newState);
    }

    public void SetState(string id)
    {
        if (!stateDic.ContainsKey(id))
        {
            Debug.LogError("������Ŀ���״̬��");
            return;
        }
        activeState =id;
        stateDic[activeState].Enter();
    }
}


