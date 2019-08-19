using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisGrid : MonoBehaviour
{
    public static int w = 10;//高度
    public static int h = 20;//宽度

    public static int score;
    public static int extraScore;

    public static Transform[,] grid = new Transform[w, h];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool isBlockInborder(Vector2 v)
    {
        return (
            (int)v.x >= 0 &&
            (int)v.x <= 9 &&
            (int)v.y >= 0

            );
        //throw new NotImplementedException();
    }


    //四舍六入五凑偶
    internal static Vector2 roundVec2(Vector3 position)
    {
        return new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        //throw new NotImplementedException();
    }

    internal static void deleteAllFullRow()
    {
        for (int y = 0; y < h;)
        {
            if (isRowFull(y))
            {

                //分数分布：
                /*
                 * 同时消1行 -> 1分
                 * 同时消2行 -> 3分
                 * 同时消3行 -> 6分
                 * 同时消4行 -> 10分
                */
                score++;
                if(extraScore>=1)
                {
                    score=score+extraScore;
                }
                extraScore++;
                deleteRow(y);
                moveUpToDown(y);
            }
            else
            {
                extraScore = 0;
                y++;
            }

        }
    }


    static void moveUpToDown(int full_max_Y)
    {
        for (int y = full_max_Y; y < h - 1; y++)
        {
            for (int x = 0; x < w; x++)
            {
                //数组上把一行移到它的下一行。
                grid[x, y] = grid[x, y + 1];
                if (grid[x, y + 1] != null)
                {
                    //视觉上把一行移到它的下一行
                    grid[x, y + 1].position += new Vector3(0, -1, 0);

                }
            }
        }
    }


    internal static bool isRowFull(int y)
    {
        for (int x = 0; x < w; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
        //throw new NotImplementedException();
    }


    static void deleteRow(int y)
    {
        for (int x = 0; x < w; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }



}
