using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karaage : MonoBehaviour
{
    public bool isClear;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("�Ȃ񂩂�������");
        if(other.GetComponent<LemonJIru>())
        {
            isClear = true;
        }
    }
}
