using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : Manager<VideoManager>
{


    public Action draw_chess=() => DrawingUtility.DrawChess();

    public override void Init()
    {
        base.Init();
        DrawingUtility.DrawChessboard();
        EventManager.Instance.TryToRegister(draw_chess, "DrawChess");
        //Debug.Log(EventManager.Instance.listenList.ContainsKey("DrawChess"));

    }


    public override void UpdateMethods()
    {
        base.UpdateMethods();
    }





}
