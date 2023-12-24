using ChessGrid;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public static class DrawingUtility
{

    public static void DrawChessboard()
    {
        Debug.Log("Draw");
        Chessboard current_board = LogicManager.Instance.current_board;

        //Draw Lines
        PrefabLoader.Catagory catagery = PrefabLoader.Catagory.Prefab;
        GameObject line = (GameObject)PrefabLoader.LoadPrefab(catagery, "Line");
        int size = 15;
        for (int i = 0; i < size; i++)
        {
            var start1 = new Vector3Int(i, 0);
            var start2 = new Vector3Int(0, i);
            var end1 = new Vector3Int(i, size - 1);
            var end2 = new Vector3Int(size - 1, i);
            GameObject line1 = Object.Instantiate(line);
            LineRenderer l_r1 = line1.GetComponent<LineRenderer>();
            l_r1.SetPosition(0, start1);
            l_r1.SetPosition(1, end1);

            GameObject line2 = Object.Instantiate(line);
            LineRenderer l_r2 = line2.GetComponent<LineRenderer>();
            l_r2.SetPosition(0, start2);
            l_r2.SetPosition(1, end2);
        }


        //Draw Dots
        GameObject dot = (GameObject)PrefabLoader.LoadPrefab(catagery, "Dot");
        int size1 = current_board.cells.Count;
        var to_list = current_board.cells.ToList();
        for (int i = 0; i < size1; i++)
        {
            Vector2Int point = to_list[i].Key;
            Object.Instantiate(dot, new Vector3(point.x, point.y), Quaternion.identity);

        }
    }

    public static void DrawChess()
    {
        PrefabLoader.Catagory catagery = PrefabLoader.Catagory.Prefab;
        int team =LogicManager.Instance.current_board.team_pointer;
        string name;
        if(team == -1)
        {
            name = "Black";
        }
        else
        {
            name = "White";
        }

        GameObject chess = (GameObject)PrefabLoader.LoadPrefab(catagery, "Chess"+name);
        Vector2Int pointer = LogicManager.Instance.current_board.location_pointer;
        Object.Instantiate(chess, new Vector3(pointer.x, pointer.y), Quaternion.identity);
    }

}
