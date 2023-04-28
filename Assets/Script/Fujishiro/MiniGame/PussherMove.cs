using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PussherMove : MonoBehaviour
{
    [SerializeField] Rigidbody Pussher_rb;
    [SerializeField] bool isPush = true;
    [SerializeField] float movement;
    [SerializeField] Vector3 move_trans;

    [SerializeField] float max_push;
    [SerializeField] float max_pull;

    // Start is called before the first frame update
    void Start()
    {
        isPush = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPush)
        {
            //var pos = this.transform.position;
            //pos.z -= movement;
            //transform.position = pos;
            transform.Translate(-move_trans);
        }
        if (!isPush)
        {
            //var pos = this.transform.position;
            //pos.z += movement;
            //transform.position = pos;
            transform.Translate(move_trans);
        }
        //if (isPush)
        //{
        //    Pussher_rb.AddForce(new Vector3(0, 0, movement));
        //}
        //if (!isPush)
        //{
        //    Pussher_rb.AddForce(new Vector3(0, 0, -movement));
        //}
        if (transform.position.z <= max_push) isPush = false;
        if (transform.position.z >= max_pull) isPush = true;
    }


}
