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

    public override void SFMInit()
    {
        base.SFMInit();
        sfm = new SFM();
        sfm.layers = new() { The_only_layer };
        Player_one_round.ApplyTo();
        Player_two_round.ApplyTo();
        Game_end.ApplyTo();
        The_only_layer.activated_id = Player_one_round.id;

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

    public StateMachine Player_two_round
    {
        get
        {
            return new()
            {
                children_layer = null,
                self_layer = The_only_layer,
                id = "player2",
                enter_methods = delegate
                {

                },
                update_methods = delegate
                {

                }
            };
        }
    }

    public StateMachine Game_end
    {
        get
        {
            return new()
            {
                children_layer = null,
                self_layer = The_only_layer,
                id = "game end",
                enter_methods = delegate
                {

                },
                update_methods = delegate
                {

                }
            };
        }
    }

    //My state machine conditions
    public Condition Next_player
    {
        get
        {
            return new()
            {
                from = { "player1","player2" },
                to = { "player2","player1" },
                self_layer = The_only_layer,
                target_signal = "complete_operation"

            };
        }
    }

    public Condition EndGame
    {
        get
        {
            return new()
            {
                from = { "player1", "game end" },
                to = { "player2", "game end" },
                self_layer = The_only_layer,
                target_signal = "win"

            };
        }
    }

    // My state machine layers
    public StateMachineLayer The_only_layer;


}