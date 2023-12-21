using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public Dictionary<string, Action> listenList=new();

    /// <summary>
    /// ע��ĳ���¼�
    /// </summary>
    /// <param name="_myAction"></param>
    /// <param name="_id"></param>
    public void Register(Action _myAction, string _id)
    {
        listenList.TryAdd(_id, _myAction);

    }

    /// <summary>
    /// ��ĳ���¼������ֵ����ĳ���¼�
    /// </summary>
    /// <param name="_myAction"></param>
    /// <param name="_targetActionId"></param>
    public void Listen(Action _myAction, string _targetActionId)
    {
        if (!listenList.ContainsKey(_targetActionId))
        {
            Debug.Log("Key not found!");
        }
        listenList[_targetActionId] += _myAction;
    }

    /// <summary>
    /// ִ��ĳ���¼�
    /// </summary>
    public void Call(string id)
    {
        if(listenList.TryGetValue(id, out var action))
        {
            action.Invoke();
        }
    }
}
