//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class SignalListener
//{
//    public string trigger;
//    public Action action;
//    public SignalListener child_node;

//    public SignalListener(string _trigger, Action _action, List<SignalListener> _listeners, SignalListener _child_node=null)
//    {
//        trigger = _trigger;
//        action = _action;
//        child_node = _child_node;
//        _listeners.Add(this);
//    }


//    //Signal -> Action
//    public void Check()
//    {
//        if (SignalUtility.CapcturedSignal(trigger))
//        {
//            action?.Invoke();
//            child_node?.Check();
//        }
//    }

//}
