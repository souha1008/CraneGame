using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Pienuts : CircleFoodsInterFace
{
    int Cnt = 0;
    public GameObject Effect;

    void Start()
    {
        Cnt = 0;
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

        if (Cnt >= 1 && m_HummerAction == HummerAction.ACTION)
        {
            GameObject Cut1 = (GameObject)Resources.Load("PienutsiNakami 1");
            GameObject Cut2 = (GameObject)Resources.Load("PienutsiNakami 1");

            Vector3 tempPos1 = transform.position;
            Vector3 tempPos2 = transform.position;
            tempPos1.x += 2;
            tempPos2.x -= 2;
            // Cubeプレハブを元に、インスタンスを生成、
            Cut1 = Instantiate(Cut1, tempPos1, transform.rotation);
            Cut1.GetComponent<PienutsNakami>().Vel = new Vector3(0.3f, 0.1f, 0);
            Cut2 = Instantiate(Cut2, tempPos2, transform.rotation);
            Cut2.GetComponent<PienutsNakami>().Vel = new Vector3(-0.3f, 0.1f, 0);

            Effect.SetActive(true);
            Effect.gameObject.transform.parent = null;

            //SE
            SoundManager.instance.SEPlay("ナッツ類割れたSE");

            Destroy(gameObject);

            m_HummerAction = HummerAction.STAY;
        }
    }

    public override void Hummer(Collider other)
    {
        //if(!isClear)
        //{
        //    isClear = true;

        //    m_HummerAction = HummerAction.STAY;
        //}


        if (m_HummerAction == HummerAction.ACTION)
        {
            Cnt++;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "AttachHummer")
    //    {
    //        if (m_HummerAction == HummerAction.ACTION)
    //        {
    //            Cnt++;
    //        }
    //    }
    //}


}
