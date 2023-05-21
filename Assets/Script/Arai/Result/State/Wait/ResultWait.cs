using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultWait : ResultObject
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("TitleTest");
            SceneManager.LoadScene("StageSelect");
        }
    }
}
