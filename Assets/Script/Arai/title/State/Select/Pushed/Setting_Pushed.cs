using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_Pushed : MonoBehaviour
{
    public void PushAction()
    {
        // 設定
        GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("TitleTest");
    }
}
