using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;
using System;


public class BGMPlayer : MonoBehaviour
{
    public string selectplayTitle;

    BGMPlayer()
    {

    }
    ~BGMPlayer() 
    {
        SoundManager.instance.BGMStop();
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.BGMPlay(selectplayTitle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
