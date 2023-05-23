using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterActivator : ResultUI
{
    void Start()
    {
        transform.parent.gameObject.transform.Find("Meter(Clone)").GetComponent<Meter>().Activate();
        Destroy(this.gameObject);
    }
}
