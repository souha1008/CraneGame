using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Start : Select_UI
{
    protected override void PushAction()
    {
        // ステージセレクトへ
        GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("SampleScene");
        
        //SceneManager.LoadScene("TitleTest");
    }
}
