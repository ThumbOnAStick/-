using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Manager
{
    

    public override void Init()
    {
        base.Init();
    }

    public override void UpdateMethods()
    {
        base.UpdateMethods();
        Mouse_relaese.Check();
    }


    public class InputAndSignal
    {
        bool get_input;
        string signal;
        InputAndSignal next_node;

        public InputAndSignal(bool _get_input, string _signal, InputAndSignal _next_node)
        {
            get_input = _get_input;
            signal=_signal;
            next_node = _next_node; 
        }


        public void Check()
        {
            if (get_input)
            {
                SignalUtility.EmitSignal(signal);
                return;
            }
            next_node?.Check();
        }
    }

    InputAndSignal Mouse_relaese
    {
        get
        {
            return new(Input.GetKeyUp(KeyCode.Mouse0), "complete_operation", null);

        }
    }
}
