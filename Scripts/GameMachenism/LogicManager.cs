using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChessGrid;
using System;

public class LogicManager : SFMClientManager<LogicManager>
{
    //��ģ�飺����
    public Chessboard current_board = new();

    //��ģ�飺������
    GameController active_controller=null;
    GameController player1;
    GameController player2;

    //Game Loop
    public override void Init()
    {
        player1 = new(1, false);
        player2 = new(-1, false);
        active_controller = player1;
        current_board.Init(15);
        base.Init();
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


    // �߼���������״̬���㼶
    public StateMachineLayer The_only_layer = new();

    //�߼���������״̬��
    StateMachine Player_one_round;
    StateMachine Player_two_round;
    StateMachine Game_end;
    Condition NextPlayer;
    Condition EndGame;

    /// <summary>
    /// �����߼�������������״̬��
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
             SwitchController();
         },
            delegate
         {
             //CheckHumanPlayerOperation();
             //CheckComputerPlayerOperation();
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
            SwitchController();
        },
         delegate
        {
            //CheckHumanPlayerOperation();
            //CheckComputerPlayerOperation();
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

    /// <summary>
    /// ����Ϸ�������������õ��¼�
    /// </summary>
    public void SwitchController()
    {
        Action action = () =>
        {
            active_controller.CtrollerPlace();
        };

        //Is AI
        if (active_controller.is_ai == true)
        {
            EventManager.Instance.UnRegister("AIThinkingComplete");
            EventManager.Instance.TryToRegister(action,"AIThinkingComplete");
            return;
        }
        //Else
        EventManager.Instance.UnRegister("HumanTryToPlace");
        EventManager.Instance.TryToRegister(action, "HumanTryToPlace");

    }




}