using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(FoodsSupportInterFace))]
#endif


public class Salada : FoodsSupportInterFace
{
    public Nat[] NatArray;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        bool tempClear = true;

        for(int i = 0; i < NatArray.Length; i++)
        {
            float VectorLength = (transform.position - NatArray[i].transform.position).magnitude;
            if (VectorLength < 8)
            {
                tempClear = false;
            }
            
        }

        //isClear = tempClear;
    }


}
