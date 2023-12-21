using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : Singleton<Emitter>
{

    public Action MyQuestion1 = delegate { Debug.Log("Can you hear me?"); };

    //��Awake�ڽ���Ҫ�����ĵ��¼�ע�ᵽ�ֵ���
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
    /// ����� Start() ��ֱ�ӵ���MyQuestion�������������Ч������Ϊ����û����ɡ�������Ҫ�ȴ�һ��ʱ�䡣
    /// </summary>
    /// <returns></returns>
    IEnumerator StartAsking()
    {
        yield return new WaitForSeconds(.5f);
        EventManager.Instance.Call("q1");
    }


}
