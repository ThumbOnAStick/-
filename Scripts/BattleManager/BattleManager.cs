using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Manager
{

    //game loop
    public override void Init()
    {
        base.Init();

    }

    public override void UpdateMethods()
    {
        base.UpdateMethods();

    }

    //My state mahcines

    public StateMachine Player_one_round
    {
        get
        {
            return new()
            {
                children_layer = null,
                self_layer = The_only_layer,
                id = "player1",
                enter_methods = delegate
                {

                },
                update_methods = delegate
                {

                }
            };
        }
    }



    // My state machine layers
    public StateMachineLayer The_only_layer;
}
