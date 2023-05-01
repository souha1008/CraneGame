using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    public Arm arm;

    public float myRotate;

    float MAX_ANGLE = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Wariai = arm.rAngle / arm.MAX_ANGLE;

        myRotate = Wariai * MAX_ANGLE;

        Quaternion rot = Quaternion.AngleAxis(myRotate, Vector3.forward);

        this.transform.rotation = rot;
    }
}
