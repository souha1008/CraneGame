using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hopper : MonoBehaviour
{
    [SerializeField] GameObject Prefab_Coin;
    [SerializeField] float speed;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        float degree = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
        if(degree == 180)
        {
            var coin = Instantiate(Prefab_Coin);
            Vector3 force = Vector3.forward * speed;
            coin.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }
}
