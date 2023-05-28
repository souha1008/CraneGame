using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiriBiri : MonoBehaviour
{
    //bool isSlow = false;
    //int SlowCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        //isSlow = false;
        //SlowCnt = 0;
    }

    private void OnDestroy()
    {
        //Player2.instance.isSlow = false;
    }

    // Update is called once per frame
    void Update()
    {
       


    }

    private void FixedUpdate()
    {
        //if (SlowCnt <= 0)
        //{
        //    isSlow = false;
        //}

        //SlowCnt--;


        //Player2.instance.isSlow = isSlow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player2.instance.gameObject)
        {
            Debug.Log("‚Ñ‚è‚ñ‚è‚’");
            Player2.instance.PlayerSlow();
        }
    }
}
