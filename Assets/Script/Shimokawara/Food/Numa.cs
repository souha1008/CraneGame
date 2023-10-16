using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<CircleFoodsInterFace>())
        {
            if(other.GetComponent<CircleFoodsInterFace>().isGround)
            {
                Destroy(other.gameObject);
                SoundManager.instance.SEPlay("ì≈è¿Ç…êZÇ©ÇÈSE");
            }
        }
    }
}
