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

    //���ڶ���ĳ���¼�֮ǰ��Ҫ�ֵ�����ڸ��¼������Զ��ĵķ�������� Start() ��
    private void Start()
    {
        EventManager.Instance.Listen(MyAnswer1, "q1");

    }


}
