using ChessGrid;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private void Start()
    {
        //All registered Fsm must be cleaed
        RegisteredSFM.Init();

        //Initialize input listener
        InputManager.Instance.Init();
        LogicManager.Instance.Init();
        VideoManager.Instance.Init();
        SFMManager.Instance.Init();
    }
    


    private void Update()
    {
        //Update input layer
        InputManager.Instance.UpdateMethods();
        LogicManager.Instance.UpdateMethods();
        VideoManager.Instance.UpdateMethods();
        SFMManager.Instance.UpdateMethods();

        //Update the managers

    }
}
