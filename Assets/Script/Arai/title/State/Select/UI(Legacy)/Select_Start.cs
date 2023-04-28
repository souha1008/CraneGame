using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Start : Select_UI
{
    public override void PushAction()
    {
        // ステージセレクトへ
        GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("ResultTest");
        //GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("SampleScene");
        //SceneManager.LoadScene("ResultTest");
    }
}
