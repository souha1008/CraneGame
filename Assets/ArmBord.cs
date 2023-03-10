using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBord : MonoBehaviour
{
    public GameObject FollowObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = FollowObject.transform.position;
    }

    private void FixedUpdate()
    {
        
    }
}
