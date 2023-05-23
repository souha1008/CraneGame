using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Pushed : MonoBehaviour
{
    public void PushAction()
    {
        // ステージセレクトへ
        GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("StageSelect");
    }
}
