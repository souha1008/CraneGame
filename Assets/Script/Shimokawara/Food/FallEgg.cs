using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class FallEgg : CircleFoodsInterFace
{
    // Start is called before the first frame update
    void Start()
    {
        FoodsStart();


    }

    // Update is called once per frame
    void Update()
    {
        FoodsUpdate();
    }

    void FixedUpdate()
    {
        FoodsFixedUpdate();
        if(transform.position.y < 6)
        {
            GameObject Cut1 = (GameObject)Resources.Load("GroundEgg");

            Vector3 tempPos1 = transform.position;


            Cut1 = Instantiate(Cut1, tempPos1, transform.rotation);
            //Cut1.GetComponent<CutTomato>().Vel = new Vector3(0.3f, 0.1f, 0);
            Cut1.GetComponent<GroundEgg>().FoodsStart();

            Destroy(gameObject);
        }
    }
}