using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Listens all constant values
public class InputManager : Manager<InputManager>
{
    //Triggers
    public InputSignal mouse_release;


    //Constants
    public  Dictionary<string, List<float>> keys_and_values = new();
    public KeyedValue mouseXY;



    public override void Init()
    {
        base.Init();
        //Init Triggers
        mouse_release = new(MouseUp, "HumanTryToPlace", null);

        //Init Constants
        mouseXY = new("MouseXY", ListenMouseXY, keys_and_values);
    }
    public override void UpdateMethods()
    {
        base.UpdateMethods();
        //Check Triggers
        mouse_release.Check();

        //Check Constants
        mouseXY.Check(keys_and_values);
    }

    //Listens
    public static bool MouseUp()
    {
        return Input.GetKeyUp(KeyCode.Mouse0);
    }


    public static List<float> ListenMouseXY()
    {
        Vector3 mouse_world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new List<float> { mouse_world.x, mouse_world.y };
    }



}

//Triggers
public class InputSignal
{
    Func<bool> get_input;
    string signal;
    InputSignal next_node;

    public InputSignal(Func<bool> _get_input, string _signal, InputSignal _next_node)
    {
        get_input = _get_input;
        signal = _signal;
        next_node = _next_node;
    }


    public void Check()
    {
        if (get_input.Invoke())
        {
            EventManager.Instance.Dispatch(signal);
            return;
        }
        next_node?.Check();
    }
}

//ConstantValues
public class KeyedValue
{
    public string key;

    //Constantly check values
    public Func<List<float>> listen;

    public KeyedValue(string _key, Func<List<float>> _listen, Dictionary<string, List<float>> _keys_and_values)
    {
        key = _key;
        listen = _listen;
        List<float> values = new();
        _keys_and_values.TryAdd(_key, values);
    }

    public void Check(Dictionary<string, List<float>> _keys_and_values)
    {
        _keys_and_values[key] = listen.Invoke();
            
    }
}