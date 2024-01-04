using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChessGrid;
using System;

public class LogicManager : Manager<LogicManager>
{
    //��ģ�飺����
    public Chessboard current_board = new();

    //��ģ�飺������
    GameController active_controller=null;
    GameController player1;
    GameController player2;

    //״̬��
    FiniteStateMachine fsm;

    //�����ֶ�
    public readonly static string playerOneRound="PlayerOneRound";
    public readonly static string playerTwoRound = "PlayerTwoRound";
    public readonly static string endGame = "EndGame";
    public readonly static string nextPlayer = "NextPlayer";
    public readonly static string win = "Win";


    //Game Loop
    public override void Init()
    {
        player1 = new(1, false);
        player2 = new(-1, false);
        active_controller = player1;
        GameData.Set("Player1", "CurrentPlayer");
        current_board.Init(15);
        InitLogicManagerStateMachines();
        base.Init();
    }


    public override void UpdateMethods()
    {
        base.UpdateMethods();
    }


    /// <summary>
    /// ��ʼ���߼���������״̬��
    /// </summary>
    void InitLogicManagerStateMachines()
    {
        fsm = new(playerOneRound);

        List<string> inputs1 = new() { nextPlayer, win };
        List<string> targets1 = new() { playerTwoRound, endGame };
        fsm.CreateState(playerOneRound, inputs1, targets1, InitController,null, SwitchController);

         List<string> inputs2 = new() { nextPlayer, win }; ;
        List<string> targets2 = new() { playerOneRound, endGame };
        fsm.CreateState(playerTwoRound, inputs2, targets2, InitController,null, SwitchController);


        List<string> inputs3 = new();
        List<string> targets3 = new();
        fsm.CreateState(endGame, inputs3, targets3);

        FsmManager.Instance.Register("TestFsm", fsm);



    }

    /// <summary>
    /// ��ʼ��������
    /// </summary>
    public void InitController()
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

    /// <summary>
    /// �л�������
    /// </summary>
    public void SwitchController()
    {
        if (active_controller == player1)
        {
            active_controller = player2;
            GameData.Set("Player2", "CurrentPlayer");
        }
        else
        {
            active_controller = player1;
            GameData.Set("Player1", "CurrentPlayer");

        }
    }


}