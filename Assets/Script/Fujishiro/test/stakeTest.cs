using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stakeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<stake_ColorTransfer>().ZeroToOne(0.01f);
        }
    }
}
