using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pussher_CildIN : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
            other.gameObject.transform.parent = this.transform.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Coin")
            other.gameObject.transform.parent = null;
    }
}
