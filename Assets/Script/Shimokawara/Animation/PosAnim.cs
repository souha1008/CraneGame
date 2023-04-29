using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosAnim : MonoBehaviour
{
    public GameObject Follow;
    Vector3 PosVector;


    // Start is called before the first frame update
    void Start()
    {
        PosVector = transform.position - Follow.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Follow.transform.position + PosVector;
    }
}
