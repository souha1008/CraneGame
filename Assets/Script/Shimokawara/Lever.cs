using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    float MaxAngle = 60;

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


        transform.rotation = Quaternion.AngleAxis(Power, new Vector3(LeftStick.y, 0, -LeftStick.x));

    }
}
