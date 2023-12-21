using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : ManagerSingleton
{


    public SignalListener draw_chessboard;
    public SignalListener draw_chess;

    public override void Init()
    {
        draw_chessboard = new("DrawChessBoard", delegate
        {
            DrawingUtility.DrawChessboard();
        }, listeners);

        draw_chess = new("DrawChess", delegate
        {
            DrawingUtility.DrawChess();
        }, listeners);
        base.Init();

    }


    public override void UpdateMethods()
    {
        base.UpdateMethods();
    }





}
