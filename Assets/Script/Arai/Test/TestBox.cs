using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var xvol = Input.GetAxis("Horizontal") * 0.01f;
        var yvol = Input.GetAxis("Vertical") * 0.01f;

        transform.Translate(xvol, yvol, 0);
    }
}
