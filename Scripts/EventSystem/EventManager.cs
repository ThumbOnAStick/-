using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public Dictionary<string, Action> listenList=new();


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        listenList.Clear();
    }

    /// <summary>
    /// ע��ĳ���¼�
    /// </summary>
    /// <param name="_myAction"></param>
    /// <param name="_id"></param>
    public void TryToRegister(Action _myAction, string _id)
    {
        if (listenList.ContainsKey(_id))
        {
            listenList[_id] += _myAction;
        }
        else
        {
            listenList.TryAdd(_id, _myAction);
        }

    }

    /// <summary>
    /// �ɷ�ĳ���¼�
    /// </summary>
    public void Dispatch(string id)
    {
        if(listenList.TryGetValue(id, out var action))
        {
            action.Invoke();
            return;
        }
        Debug.LogError("Event None Exists: "+id);
    }

    /// <summary>
    /// �Ƴ�ĳ���¼�
    /// </summary>
    /// <param name="id"></param>
    public void UnRegister(string id)
    {
        if (!listenList.ContainsKey(id))
        {
            return;
        }   

        listenList.Remove(id);
    }
}
