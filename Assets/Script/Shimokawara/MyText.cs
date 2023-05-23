using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProを扱う際に必要

public class MyText : MonoBehaviour
{
    TextMeshProUGUI text;

    int speedClearTime; // タイムリミット秒
    int FPSTime;    // 今フェーズのフレーム数
    int AllTime;    // それまでのフレーム数

    float OneFrame; // 1フレームの秒数 

    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "9999";

        speedClearTime = CookMoveManager.instance.SPEED_CLEAR_TIME;
        FPSTime = CookMoveManager.instance.FPS_Time;
        AllTime = CookMoveManager.instance.AllTime;

        OneFrame = 1.0f / 60.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FPSTime = CookMoveManager.instance.FPS_Time;
        AllTime = CookMoveManager.instance.AllTime;
        
        int FrameTime = FPSTime + AllTime;
        float SecTime = (float)FrameTime * OneFrame;
        time = speedClearTime - (int)SecTime;

        text.text = time.ToString("000");
    }
}
