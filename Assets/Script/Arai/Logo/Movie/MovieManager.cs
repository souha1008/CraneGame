using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Debug Multiplier"))
        {
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("TitleTest");
        }
    }
}
