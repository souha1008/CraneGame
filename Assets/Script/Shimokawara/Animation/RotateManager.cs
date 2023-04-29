using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    static public RotateManager instance;

    public GameObject[] ModelArray;

    Attach.AttachType OldAttach;
    Attach.AttachType NewAttach;


    int AnimCnt = 0;

    public Attach.AttachType FirstAttach;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        for(int i = 0; i < ModelArray.Length;i++)
        {
            Quaternion rot = Quaternion.AngleAxis(-90, Vector3.right);
            ModelArray[i].transform.localRotation = rot;
        }
        NewAttach = OldAttach = FirstAttach;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        switch (AnimCnt)
        {
            case 0:
                {
                    Quaternion rot = Quaternion.AngleAxis(-8, Vector3.right);
                    ModelArray[(int)OldAttach].transform.localRotation = rot;
                }
                break;
            case 1:
                {
                    Quaternion rot = Quaternion.AngleAxis(-16, Vector3.right);
                    ModelArray[(int)OldAttach].transform.localRotation = rot;
                }
                break;
            case 2:
                {
                    Quaternion rot = Quaternion.AngleAxis(-30, Vector3.right);
                    ModelArray[(int)OldAttach].transform.localRotation = rot;
                }
                break;
            case 3:
                {
                    Quaternion rot = Quaternion.AngleAxis(-90, Vector3.right);
                    ModelArray[(int)OldAttach].transform.localRotation = rot;

                    rot = Quaternion.AngleAxis(-30, Vector3.right);
                    ModelArray[(int)NewAttach].transform.localRotation = rot;
                }
                break;
            case 4:
                {
                    Quaternion rot = Quaternion.AngleAxis(-16, Vector3.right);
                    ModelArray[(int)NewAttach].transform.localRotation = rot;
                }
                break;
            case 5:
                {
                    Quaternion rot = Quaternion.AngleAxis(-8, Vector3.right);
                    ModelArray[(int)NewAttach].transform.localRotation = rot;
                }
                break;
            case 6:
                {
                    Quaternion rot = Quaternion.AngleAxis(0, Vector3.right);
                    ModelArray[(int)NewAttach].transform.localRotation = rot;
                }
                break;
            case 7:
                break;
            default:
                break;
        }
        AnimCnt++;
    }

    public void Rotate(Attach.AttachType oldType , Attach.AttachType newType )
    {
        AnimCnt = 0;
        OldAttach = oldType;
        NewAttach = newType;
    }
}
