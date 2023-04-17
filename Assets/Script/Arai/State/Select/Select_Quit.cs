using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Quit : Select_UI
{
    protected override void SubUpdate()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Quit();
        }
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
        Application.Quit();//ゲームプレイ終了
        #endif
    }
}
