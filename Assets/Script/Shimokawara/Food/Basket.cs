using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(FoodsSupportInterFace))]
#endif


public class Basket : FoodsSupportInterFace
{
    public Mikan[] MikanArray;

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

        for (int i = 0; i < MikanArray.Length; i++)
        {
            if(MikanArray[i])
            {
                Vector2 Max;
                Max.x = transform.position.x + transform.localScale.x / 2;
                Max.y = transform.position.z + transform.localScale.z / 2;

                Vector2 Min;
                Min.x = transform.position.x - transform.localScale.x / 2;
                Min.y = transform.position.z - transform.localScale.z / 2;

                if (MikanArray[i].transform.position.x > Min.x &&
                    MikanArray[i].transform.position.x < Max.x &&
                    MikanArray[i].transform.position.z > Min.y &&
                    MikanArray[i].transform.position.z < Max.y &&
                    !MikanArray[i].isNoAction)
                {
                    MikanArray[i].isClear = true;
                }
                else
                {
                    MikanArray[i].isClear = false; ;
                }
            }
            
        }
    }


}
