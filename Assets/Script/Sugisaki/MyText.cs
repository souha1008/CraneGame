using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProを扱う際に必要

public class MyText : MonoBehaviour
{
    TextMeshProUGUI text;

    float OneFrame; // 1フレームの秒数 

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "9999";

        OneFrame = 1.0f / 60.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int speedClearTime = CookMoveManager.instance.SPEED_CLEAR_TIME;
        int FPSTime = CookMoveManager.instance.FPS_Time;
        if (FPSTime > 17000)
            FPSTime = 0;
        int AllTime = CookMoveManager.instance.AllTime;

        int FrameTime = FPSTime + AllTime;
        float SecTime = (float)FrameTime * OneFrame;
        int time = speedClearTime - (int)SecTime;
        if (time < 0)
        {
            this.gameObject.SetActive(false);
        }

        text.text = time.ToString("000");
    }
}
