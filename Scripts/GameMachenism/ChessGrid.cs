using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

 namespace ChessGrid
{
    //Only need on chessboard in one game, so make it static
    public static class Chessboard
    {
        public static Dictionary<Vector2Int, ChessCell> cells = new();

        public static Dictionary<Vector2Int, ChessCell> black_cells = new();
        public static Dictionary<Vector2Int, ChessCell> white_cells = new();

        public static Vector2Int location_pointer;
        public static int team_pointer;

        //On Game Start
        public static void Init(int _size)
        {
            cells = new();
            black_cells = new();
            white_cells = new();

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    var cell = new ChessCell(i,j);
                }
            }

            SignalUtility.EmitSignal("DrawChessBoard");
        }

        public static bool TryToPlace(Vector2Int location, int place_info)
        {
            if (place_info == 0)
            {
                return false;
            }

            if (!cells.ContainsKey(location))
            {
                return false;
            }

            if (cells[location].place_info != 0)
            {
                return false;
            }

            location_pointer = location;
            team_pointer = place_info;

            //Assign value to cell
            ChessCell cell = cells[location];
            cells[location].place_info = place_info;

            //Black
            if (place_info == -1)
            {

                black_cells.Add(location, cell);
            }
            //White
            else
            {
                white_cells.Add(location, cell);
            }

            return true;
        }

    }

    public class ChessCell
    {
        public readonly int x;
        public readonly int y;

        //-1=black,0=empty,1=white
        public int place_info = 0;

        public  ChessCell(int _x, int _y)
        {
            x = _x;
            y = _y;
            Chessboard.cells.TryAdd(new Vector2Int(x, y), this);
        }
    }

}
