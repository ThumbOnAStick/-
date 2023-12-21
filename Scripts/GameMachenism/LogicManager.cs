using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChessGrid;

public class LogicManager : SFMClientManager
{

    GameController active_controller=null;
    GameController player1;
    GameController player2;

    //Game Loop
    public override void Init()
    {
        base.Init();
        player1 = new(1, false);
        player2 = new(-1, false);
        active_controller = player1;
    }

    public override void SFMInit()
    {
        //Make machines and conds
        InitLogicManagerStateMachines();

        //Apply machines
        Player_one_round.ApplyTo();
        Player_two_round.ApplyTo();
        Game_end.ApplyTo();

        //Apply conds
        NextPlayer.ApplyTo();
        EndGame.ApplyTo();

        The_only_layer.activated_id = Player_one_round.id;

        sfm = new SFM
        {
            layers = new() { The_only_layer }
        };
        base.SFMInit();

    }

    public override void UpdateMethods()
    {
        base.UpdateMethods();
    }


    // 逻辑管理器的状态机层级
    public StateMachineLayer The_only_layer = new();

    //逻辑管理器的状态机
    StateMachine Player_one_round;
    StateMachine Player_two_round;
    StateMachine Game_end;
    Condition NextPlayer;
    Condition EndGame;

    /// <summary>
    /// 生成逻辑管理器的所有状态机
    /// </summary>
    void InitLogicManagerStateMachines()
    {
        //Debug.Log(player1.team);
        //Debug.Log(player2.team);

        Player_one_round = new(
            "player1",
            delegate
         {
             active_controller = player1;
         },
            delegate
         {
             CheckHumanPlayerOperation();
             CheckComputerPlayerOperation();
         },
            delegate
         {

         },
         The_only_layer
        );

        Player_two_round = new(
            "player2",
         delegate
        {
            active_controller = player2;
        },
         delegate
        {
            CheckHumanPlayerOperation();
            CheckComputerPlayerOperation();
        },
         delegate
        {

        },
       The_only_layer
       );

        Game_end = new(
            "game end",
         delegate
         {

         },
         delegate
         {
            
         },
         delegate
         {

         },
         The_only_layer
       );

        NextPlayer = new()
        {
            from = new List<string> { "player1", "player2" },
            to = new List<string> { "player2", "player1" },
            target_signal = "NextPlayer",
            self_layer = The_only_layer,
        };
        EndGame = new() 
        {
            from = new List<string> { "player1", "game end" },
            to = new List<string> { "player2", "game end" },
            target_signal = "Win",
            self_layer = The_only_layer,
        };


    }

    //Controller Update
    public void CheckHumanPlayerOperation()
    {
        if (active_controller.is_ai == true)
        {
            return;
        }

        if (SignalUtility.CapcturedSignal("HumanTryToPlace"))
        {
            active_controller.CtrollerPlace();
        }
    }

    public void CheckComputerPlayerOperation()
    {
        if (!active_controller.is_ai == true)
        {
            return;
        }

        if (SignalUtility.CapcturedSignal("AIThinkingComplete"))
        {
            active_controller.CtrollerPlace();
        }
    }

}