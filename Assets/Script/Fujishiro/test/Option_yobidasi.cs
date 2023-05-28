using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_yobidasi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            Title_OptionManager.instance.Call_Option();
        }
    }
}
