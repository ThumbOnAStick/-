using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : Singleton<Emitter>
{

    public Action MyQuestion1 = delegate { Debug.Log("Can you hear me?"); };

    //在Awake内将需要被订阅的事件注册到字典里
    protected override void Awake()
    {
        base.Awake();
        EventManager.Instance.Register(MyQuestion1, "q1");
    }

    void Start()
    {
        StartCoroutine(StartAsking());
    }

    /// <summary>
    /// 如果在 Start() 内直接调用MyQuestion不会产生后续的效果，因为订阅没有完成。这里需要等待一段时间。
    /// </summary>
    /// <returns></returns>
    IEnumerator StartAsking()
    {
        yield return new WaitForSeconds(.5f);
        EventManager.Instance.Call("q1");
    }


}
