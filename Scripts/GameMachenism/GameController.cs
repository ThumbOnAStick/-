using ChessGrid;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController
{
    //Black or White
    public int team;
    public bool is_ai;

    public Vector2Int Pointer()
    {
        //if I am a robot
        if (is_ai)
        {
            return new();
        }

        //if I am a human
        List<float> mouse_po = InputListener.keys_and_values["MouseXY"];
        
        int x = Mathf.RoundToInt(mouse_po[0]);
        int y = Mathf.RoundToInt(mouse_po[1]);
        return new Vector2Int(x,y);
    }

    public void CtrollerPlace()
    {
        Vector2Int pointer = Pointer();
        if (Chessboard.TryToPlace(pointer, team))
        {
            //Debug.Log("Place Succeed, Locatoin: "+pointer);

            //Instantiate Chess Game Object
            SignalUtility.EmitSignal("DrawChess");

            //If win
            if (VictoryCheck.IsWin(team, pointer))
            {
                SceneManager.LoadScene(0);
                return;
            }

            //If not win
            SignalUtility.EmitSignal("NextPlayer");


        }

    }

    public GameController(int _team, bool _is_ai)
    {
        team= _team;
        is_ai= _is_ai;
    }
}
