using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public GameObject obj;
    public static Fire instance;
    public float Y = 0;
    // Start is called before the first frame update
    void Start()
    {
        Y = 40;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = obj.transform.position;
        temp.y = Y;
        transform.position = temp;
    }
}