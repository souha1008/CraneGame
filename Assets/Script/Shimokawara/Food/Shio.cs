using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shio : MonoBehaviour
{

    public int HitCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        HitCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttachHummer")
        {
            HitCnt = Mathf.Min(HitCnt + 1, 2);
            Debug.Log("‰–ƒqƒbƒg");
        }
          
    }
}
