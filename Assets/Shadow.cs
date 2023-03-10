using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{

  

    public GameObject playerObj;

    float y;

    // Start is called before the first frame update
    void Start()
    {
        y = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3 (
            playerObj.transform.position.x,
            y, 
            playerObj.transform.position.z);

        this.transform.position = temp;
    }
}
