using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Receiver : Singleton<Receiver>
{

    public Action MyAnswer1 = delegate { Debug.Log("Yes"); };

    protected override void Awake()
    {
        base.Awake();
    }

    //由于订阅某个事件之前需要字典里存在该事件，所以订阅的方法存放在 Start() 内
    private void Start()
    {
        EventManager.Instance.Listen(MyAnswer1, "q1");

    }


}
