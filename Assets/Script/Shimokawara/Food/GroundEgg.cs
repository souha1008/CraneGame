using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class GroundEgg : CircleFoodsInterFace
{

    FlyPang[] FlyPangArray;
    // Start is called before the first frame update
    void Start()
    {
        FoodsStart();


    }

    private void OnEnable()
    {
        FlyPangArray = GameObject.FindObjectsOfType<FlyPang>();
    }


    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {

        for (int i = 0; i < FlyPangArray.Length; i++)
        {
            if (FlyPangArray[i])
            {
                float VectorLength = (transform.position - FlyPangArray[i].transform.position).magnitude;
                if (VectorLength < 8)
                {
                    isClear = true;
                }
            }
        }

        FoodsFixedUpdate();
    }
}
