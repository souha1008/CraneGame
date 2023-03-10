using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPang : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //エスカレート処理
        // if (isGround)
        {
            Vector3 tempPos = transform.position;
            tempPos.z -= 0.05f;
            transform.position = tempPos;
        }
    }
}
