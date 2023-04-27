using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonJIru : MonoBehaviour
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
        Vector3 temp = transform.position;
        temp.y -= 0.9f;
        transform.position = temp;
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "EscarateNone")
        {
            Destroy(gameObject);
        }
    }
}
