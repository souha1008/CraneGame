using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select_Start : Select_UI
{
    protected override void SubUpdate()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("TitleTest");
        }
    }
}
