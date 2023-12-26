using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows;

public class State
{
    public FiniteStateMachine myFsm;
    public FiniteStateMachine childFsm;
    public List<string> inputs = new();
    public List<string> targets = new();

    public Action enter;
    public Action update;
    public Action exit;

    public State(string _id, List<string> _inputs, List<string> _targets,
        Action _enter = null, Action _update = null, Action _exit = null, FiniteStateMachine _childFsm = null)
    {
        childFsm = _childFsm;
        enter = _enter;
        update = _update;
        exit = _exit;

        if (_inputs.Count != _targets.Count)
        {
            Debug.LogError("ת����ϵ��Ŀ��״̬������һ��");
            return;
        }
        inputs = _inputs;
        targets = _targets;

    }

    public void Enter()
    {
        RegisterTransistions();

        enter?.Invoke();
        childFsm?.Enter();
    }

    public void Update()
    {

        update?.Invoke();
        childFsm?.Update();
    }

    public  void Exit()
    {
        UnRegisterTransistions();

        exit?.Invoke();
        childFsm?.Exit();
    }

    /// <summary>
    /// ����״̬ʱ��ע��״̬�ĸ���ת������
    /// </summary>
    public void RegisterTransistions()
    {
        for (int i = 0; i < targets.Count; i++)
        {

            string target = targets[i];
            Action exit =()=>
            {
                Exit();
                myFsm.SetState(target);
            };
            EventManager.Instance.TryToRegister(exit, inputs[i]);
            Debug.Log("Registered: " + inputs[i]);
        }


    }

    /// <summary>
    /// �˳��¼�ʱ���Ƴ�ע��
    /// </summary>
    public void UnRegisterTransistions()
    {
        for (int i = 0; i < inputs.Count; i++)
        {

            EventManager.Instance.UnRegister(inputs[i]);
        }

    }
}