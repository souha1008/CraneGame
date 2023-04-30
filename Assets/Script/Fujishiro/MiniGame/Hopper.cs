using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hopper : MonoBehaviour
{
    [SerializeField] GameObject Prefab_Coin;
    [SerializeField] float speed;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
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

        if(Input.GetKey(KeyCode.Space))
        {
            var coin = Instantiate(Prefab_Coin, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            Vector3 force = Vector3.up * speed * 100;
            coin.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }
}
