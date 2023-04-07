using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hummer : MonoBehaviour
{
    public GameObject LockTex;
    bool isUnLock = false;

    bool isUp = true;

    // Start is called before the first frame update
    void Start()
    {
        isUnLock = false;
        isUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        float rAngle;

        if(isUp)
        {
            rAngle = 20;
        }
        else
        {
            rAngle = -20;
        }

        Quaternion rot = Quaternion.AngleAxis(rAngle, Vector3.right);

        this.transform.rotation = rot;
    }

    private void FixedUpdate()
    {
        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("RightX");
        LeftStick.y = Input.GetAxis("RightY");

        float length = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);//‘å‚«‚³

        if (length <= 0.7f)//¬‚³‚·‚¬‚ÄƒJƒbƒg
        {
            isUnLock = false;
        }

        if (length > 0.85f &&
            (Mathf.Atan2(LeftStick.y, LeftStick.x) <= (-Mathf.PI / 2 + 0.2f)) &&
            (Mathf.Atan2(LeftStick.y, LeftStick.x) >= (-Mathf.PI / 2 - 0.2f)))
        {
            isUnLock = true;
        }



        if (isUnLock && LeftStick.y > 0)
        {
            float temp = ((Input.GetAxis("RightY")) + 1) * 0.5f;
            //rAngle = temp * MAX_ANGLE;
            if (LockTex)
            {
                LockTex.GetComponent<Renderer>().enabled = false;
            }
            isUp = true;
        }
        else
        {
           // rAngle = 0;
            if (LockTex)
            {
                LockTex.GetComponent<Renderer>().enabled = true;
            }
            isUp = false;
        }

        Update();
    }
}
