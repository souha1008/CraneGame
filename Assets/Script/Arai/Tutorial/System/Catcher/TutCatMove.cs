using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCatMove : TutModule
{
    private enum DIRECTION
    {
        UP, DOWN, LEFT, RIGHT, MAX
    }

    private bool[] inputs = new bool[(int)DIRECTION.MAX];

    private bool getinput = false;

    void Start()
    {
        for(int i = 0; i < (int)DIRECTION.MAX; ++i)
        {
            inputs[i] = false;
        }
    }

    void Update()
    {
        if (!getinput)
        {
            // 入力確認
            var stickHor = Input.GetAxis("Horizontal");
            var stickVer = Input.GetAxis("Vertical");
            if (!inputs[(int)DIRECTION.UP] && (int)stickVer > 0)
            {
                inputs[(int)DIRECTION.UP] = true;
            }
            if (!inputs[(int)DIRECTION.DOWN] && (int)stickVer < 0)
            {
                inputs[(int)DIRECTION.DOWN] = true;
            }
            if (!inputs[(int)DIRECTION.LEFT] && (int)stickHor < 0)
            {
                inputs[(int)DIRECTION.LEFT] = true;
            }
            if (!inputs[(int)DIRECTION.RIGHT] && (int)stickHor > 0)
            {
                inputs[(int)DIRECTION.RIGHT] = true;
            }
                
            // オールグリーンチェック
            foreach(var input in inputs)
            {
                if (!input)
                {
                    getinput = false;
                    break;
                }
                else
                {
                    getinput = true;
                }
            }

        }
        else
        {
            Fin();
        }
    }
}
