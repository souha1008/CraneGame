using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Controll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            this.gameObject.SetActive(false);
            Time.fixedDeltaTime = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(false);
            Time.fixedDeltaTime = 1;
        }
    }
}
