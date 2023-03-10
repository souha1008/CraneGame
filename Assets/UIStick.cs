using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStick : MonoBehaviour
{
    Vector2 Stick;
    Vector3 CenterPos; 


    // Start is called before the first frame update
    void Start()
    {
        CenterPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float Haba = 25.0f;

        Stick.x = Input.GetAxis("Horizontal");
        Stick.y = Input.GetAxis("Vertical");

        Stick = Stick.normalized;

        Vector3 temp = new Vector3 ((Stick * Haba).x , (Stick * Haba).y,0);
        transform.position = CenterPos + temp;

    }
}
