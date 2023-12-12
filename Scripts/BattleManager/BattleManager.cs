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
     
        //machines
        Player_one_round.ApplyTo();
        Player_two_round.ApplyTo();
        Game_end.ApplyTo();

        //conditions
        NextPlayer.ApplyTo();
        EndGame.ApplyTo();

        The_only_layer.activated_id = Player_one_round.id;

        sfm = new SFM
        {
            layers = new() { The_only_layer }
        };
        Debug.Log("complete sfm init");
        base.SFMInit();

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
    public Condition NextPlayer
    {
        get
        {
            return new()
            {
                from = new List<string>{ "player1", "player2" },
                to = new List<string>{ "player2", "player1" },
                target_signal = "complete_operation",
                self_layer = The_only_layer,

            };
        }
    }

    public Condition EndGame
    {
        get
        {
            return new()
            {
                from = new List<string> { "player1", "game end" },
                to = new List<string> { "player2", "game end" },
                self_layer = The_only_layer,
                target_signal = "win"

            };
        }
    }

    // My state machine layers
    public StateMachineLayer The_only_layer=new();


}