using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    float MAX_ANGLE = 60;

    Vector3 DefaultVector = new Vector3(0, 0, -90);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("Horizontal");
        LeftStick.y = Input.GetAxis("Vertical");

        float Power = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);

        if(Power <= 0.1f)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(Power * MAX_ANGLE, new Vector3(LeftStick.y , 0 , -LeftStick.x));
            //transform.rotation = Quaternion.Euler(DefaultVector);
        }


        
    }
}
