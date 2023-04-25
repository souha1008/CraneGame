using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 100f;

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
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Foods" ||
        other.gameObject.tag == "FoodsSupport" )
        {

            Vector3 PosVector = other.transform.position - transform.position;
            float Angle = Mathf.Atan2(PosVector.z, PosVector.x);

            Vector3 TempVel = Vector3.zero;

            if(Mathf.PI * 0.25f < Angle && Mathf.PI * 0.75f > Angle)
            {
                TempVel.x = -1;
            }
            else if(Mathf.PI * 0.25f > Angle && Mathf.PI * -0.25f < Angle)
            {
                TempVel.z = 1;
            }
            else if((Mathf.PI * -0.25f > Angle && Mathf.PI * -0.75f < Angle))
            {
                TempVel.x = 1;
            }
            else
            {
                TempVel.z = -1;
            }


            other.transform.position += (TempVel * speed);
        }
    }

}
