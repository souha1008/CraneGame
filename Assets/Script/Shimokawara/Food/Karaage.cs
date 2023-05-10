using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(FoodsSupportInterFace))]
#endif


public class Karaage : FoodsSupportInterFace
{ 

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("�Ȃ񂩂�������");
        if(other.GetComponent<LemonJIru>())
        {
            isClear = true;
        }
    }
}
