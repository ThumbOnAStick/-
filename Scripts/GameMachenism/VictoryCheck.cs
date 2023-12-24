using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ChessGrid;

public static class VictoryCheck
{
    public static bool IsWin(int team, Vector2Int point)
    {
        //This shouldn't exist
        if (team == 0)
        {
            Debug.LogError("Team Zero Non Exists!");
            return false;
        }

        Dictionary<Vector2Int, ChessCell> target_grid;

        if (team == -1)
        {
            target_grid = LogicManager.Instance.current_board.black_cells;
        }
        else
        {
            target_grid = LogicManager.Instance.current_board.white_cells;

        }
        return Horizontal(point, target_grid) || Vertical(point, target_grid) || Slash(point, target_grid) || BackSlash(point, target_grid);
    }

    //Check horizontally
    public static bool Horizontal(Vector2Int me, Dictionary<Vector2Int, ChessCell> target_grid)
    {
        int score = 1;

        Vector2Int left = me + Vector2Int.left;
        Vector2Int right = me + Vector2Int.right;

        while (target_grid.ContainsKey(left))
        {
            left += Vector2Int.left;
            score++;
        }

        while (target_grid.ContainsKey(right))
        {
            right += Vector2Int.right;
            score++;
        }

        return score > 4;
    }

    //Check vertically
    public static bool Vertical(Vector2Int me, Dictionary<Vector2Int, ChessCell> target_grid)
    {
        int score = 1;

        Vector2Int up = me + Vector2Int.up;
        Vector2Int bottom = me + Vector2Int.down;

        while (target_grid.ContainsKey(up))
        {
            up += Vector2Int.up;
            score++;
        }

        while (target_grid.ContainsKey(up))
        {
            bottom += Vector2Int.down;
            score++;
        }

        return score > 4;
    }

    //Check slash
    public static bool Slash(Vector2Int me, Dictionary<Vector2Int, ChessCell> target_grid)
    {
        int score = 1;

        Vector2Int up = me + Vector2Int.one;
        Vector2Int bottom = me - Vector2Int.one;

        while (target_grid.ContainsKey(up))
        {
            up += Vector2Int.one;
            score++;
        }

        while (target_grid.ContainsKey(bottom))
        {
            bottom -= Vector2Int.one;
            score++;
        }

        return score > 4;
    }

    //Check back slash
    public static bool BackSlash(Vector2Int me, Dictionary<Vector2Int, ChessCell> target_grid)
    {
        int score = 1;

        Vector2Int back_slash_direction = Vector2Int.left + Vector2Int.up;

        Vector2Int up = me + back_slash_direction;
        Vector2Int bottom = me - back_slash_direction;

        while (target_grid.ContainsKey(up))
        {
            up += back_slash_direction;
            score++;
        }

        while (target_grid.ContainsKey(bottom))
        {
            bottom -= back_slash_direction;
            score++;
        }

        return score > 4;
    }
}
