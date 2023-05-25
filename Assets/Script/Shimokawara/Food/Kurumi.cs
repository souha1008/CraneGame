using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Kurumi : CircleFoodsInterFace
{
    int Cnt = 0;
    int OldCnt = 0;
    public GameObject Effect;

    public GameObject obj1;
    public GameObject obj2;

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

        

        if (Cnt == 1)
        {
            if(OldCnt == 0)
            {
                SoundManager.instance.SEPlay("ナッツ類割れたSE");
            }
            obj1.SetActive(true);
        }
        if (Cnt == 2)
        {
            if (OldCnt == 1)
            {
                SoundManager.instance.SEPlay("ナッツ類割れたSE");
            }
            obj2.SetActive(true);
        }

        if(Cnt >= 3 && !isNoAction)
        {
            GameObject Kurumi = (GameObject)Resources.Load("KurumiNakami");

            Vector3 tempPos1 = transform.position;
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(Kurumi, tempPos1, transform.rotation);
            tempPos1.y += 2;

            Kurumi.GetComponent<KurumiNakami>().Vel = new Vector3(0.3f, 0.1f, 0);
            //Debug.Log(Nakami.GetComponent<KurumiNakami>().Vel);
            //Destroy(Kurumi);

            Effect.SetActive(true);
            Effect.gameObject.transform.parent = null;

            //SE
            SoundManager.instance.SEPlay("ナッツ類割れたSE");
            m_HummerAction = HummerAction.STAY;
            Destroy(gameObject);
        }

        OldCnt = Cnt;
    }

    public override void Hummer(Collider other)
    {
        //if(!isClear)
        //{
        //    isClear = true;

        //    m_HummerAction = HummerAction.STAY;
        //}


        if (!isNoAction)
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
