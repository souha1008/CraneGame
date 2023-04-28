using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Pushed : MonoBehaviour
{
    public void PushAction()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;// ゲーム終了
        #else
        Application.Quit();// ゲーム終了
        #endif
    }
}
