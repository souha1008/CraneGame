using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBord : MonoBehaviour
{
    public RightArm rightArm;

    float rotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotate = -rightArm.myRotate;

        Quaternion rot = Quaternion.AngleAxis(-rightArm.myRotate, Vector3.forward);

        this.transform.localRotation = rot;
    }
}
