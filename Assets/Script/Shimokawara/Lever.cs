using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    float MaxAngle = 20;
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

        //float StickVel = Mathf.Atan2(LeftStick.y, LeftStick.x);

        float Power = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);

        if(Power == 0)
        {
            transform.rotation = Quaternion.Euler(DefaultVector);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(Power * MaxAngle, new Vector3(LeftStick.y, 0, -LeftStick.x)) * Quaternion.Euler(DefaultVector);
        }
       

    }
}
