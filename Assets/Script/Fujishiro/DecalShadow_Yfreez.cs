using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalShadow_Yfreez : MonoBehaviour
{
    private float freez;

    // Start is called before the first frame update
    void Start()
    {
        freez = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        var thisy = this.transform.position;
        thisy = new Vector3(thisy.x ,freez, thisy.z);
        this.transform.position = thisy;
        
    }
}
