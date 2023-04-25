using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Egg : CircleFoodsInterFace
{
    bool OldisGround = false;
    bool CrashEgg = false;
    bool OnceHoken = true;
    bool DropOnce = true;

    public GameObject FallEgg;

    // Start is called before the first frame update
    void Start()
    {
        FallEgg.GetComponent<Renderer>().enabled = false;

        OldisGround = false;
        CrashEgg = false;
        OnceHoken = true;
        DropOnce = true;

        FoodsStart();
    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        OldisGround = isGround;
        FoodsFixedUpdate();

        if(isGround && !OldisGround)//íÖínÇÃèuä‘ïKÇ∏
        {
            if(OnceHoken)
            {
                OnceHoken = false;
            }
            else
            {
                GetComponent<Renderer>().enabled = false;
            }
        }



        if (GetComponent<Renderer>().enabled == false)
        {
            if(DropOnce)
            {
                DropOnce = false;
                FallEgg.transform.position = transform.position;
                FallEgg.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
