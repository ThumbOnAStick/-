using ChessGrid;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Manager> managers = new List<Manager>();

    private void Awake()
    {

        //Reset all the signals
        SignalUtility.KillAllSignals();

        //All registered Fsm must be cleaed
        RegisteredSFM.Init();

        //Initialize the board
        Chessboard.Init(15);

        //Initialize input listener
        InputListener.Init();

        //Find the managers in current scene with FindObjectsOfType 
        managers = FindObjectsOfType<Manager>().ToList();

        //Re-order the managers, FSM manager goes last
        managers.OrderBy(x => x.index).ToList();

        //Init
        foreach (var manager in managers)
        {
            manager.Init();
        }

    }

    private void Update()
    {
        //Update input layer
        InputListener.Update();

        //Update the managers
        foreach (var manager in managers)
        {
            manager.UpdateMethods();
        }

    }
}
