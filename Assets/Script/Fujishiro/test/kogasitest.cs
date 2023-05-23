using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kogasitest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        Material_ColorTransfer.instance.Scorch_Object(1.4f);
    }
}
