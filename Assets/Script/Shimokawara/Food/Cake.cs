using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(FoodsSupportInterFace))]
#endif


public class Cake : FoodsSupportInterFace
{
    public Candle Candle;
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
        bool tempClear = false;

        Vector3 MyPos = transform.position;
        MyPos.y = 0;
        Vector3 OtherPos = Candle.transform.position;
        OtherPos.y = 0;

        float VectorLength = (MyPos - OtherPos).magnitude;
        if (VectorLength < 7)
        {
            if(Candle.isFire)
            {
                tempClear = true;
            }
        }

        isClear = tempClear;
    }
}
