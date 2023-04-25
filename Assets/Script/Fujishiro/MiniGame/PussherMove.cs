using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PussherMove : MonoBehaviour
{
    [SerializeField] bool isPush = true;
    [SerializeField] float movement;

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
        if(isPush)
        {
            var pos = this.transform.position;
            pos.z -= movement;
            transform.position = pos;
        }
        if (!isPush)
        {
            var pos = this.transform.position;
            pos.z += movement;
            transform.position = pos;
        }
        if (transform.position.z <= max_push) isPush = false;
        if (transform.position.z >= max_pull) isPush = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        other.gameObject.transform.parent = this.transform.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        other.gameObject.transform.parent = null;
    }
}
