using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Exit : Select_UI
{
    public override void PushAction()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;// ゲーム終了
        #else
        Application.Quit();// ゲーム終了
        #endif
    }
}
