using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBord : MonoBehaviour
{
    public LeftArm leftArm;

    float rotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate = - leftArm.myRotate;

        Quaternion rot = Quaternion.AngleAxis(-leftArm.myRotate, Vector3.forward);

        this.transform.localRotation = rot;
    }
}
