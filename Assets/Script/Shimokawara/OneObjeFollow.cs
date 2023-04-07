using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneObjeFollow : MonoBehaviour
{

    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = obj.transform.position;
    }
}
