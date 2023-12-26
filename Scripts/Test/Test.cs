using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    FiniteStateMachine fsm=new("State1");

    private void Awake()
    {
        List<string> inputs1 = new() { "1", "0" };
        List<string> targets1 = new() { "State3", "State2"};
        fsm.CreateState("State1", inputs1, targets1,SayMyTurnStateOne);

        List<string> inputs2 = new() { "0" };
        List<string> targets2 = new() { "State3" };
        fsm.CreateState("State2", inputs2, targets2,SayMyTurnStateTwo);


        List<string> inputs3 = new () { "0" };
        List<string> targets3 = new() { "State1" };
        fsm.CreateState("State3", inputs3, targets3,SayMyTurnStateThree);

        FsmManager.Instance.Register("TestFsm", fsm);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventManager.Instance.Dispatch("0");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            EventManager.Instance.Dispatch("1");
        }
    }

    void SayMyTurnStateOne()
    {
        Debug.Log("State 1's turn!");
    }
    void SayMyTurnStateTwo()
    {
        Debug.Log("State 2's turn!");
    }
    void SayMyTurnStateThree()
    {
        Debug.Log("State 3's turn!");

    }
}
