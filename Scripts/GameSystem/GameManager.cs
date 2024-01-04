using ChessGrid;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    private void Start()
    {

        //清空储存的所有状态机
        FsmManager.Instance.UnregisterAll();


        InputManager.Instance.Init();
        LogicManager.Instance.Init();
        VideoManager.Instance.Init();
    }
    


    private void Update()
    {
        
        InputManager.Instance.UpdateMethods();
        LogicManager.Instance.UpdateMethods();
        VideoManager.Instance.UpdateMethods();
        FsmManager.Instance.UpdateMethods();
    }


}
