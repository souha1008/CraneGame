using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(CircleFoodsInterFace))]
#endif

public class Egg : CircleFoodsInterFace
{

    bool GlabOnce = false;
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

        if(FoodsArmState == FOODS_ARM_STATE.GLAB && transform.position.y >= 7)
        {
            GlabOnce = true;
        }


        if(GlabOnce && transform.position.y < 6)
        {
            //中身
            GameObject Nakami1 = (GameObject)Resources.Load("GroundEgg");
            Vector3 tempPos = transform.position;
            Nakami1 = Instantiate(Nakami1, tempPos, transform.rotation);
            //Cut1.GetComponent<CutTomato>().Vel = new Vector3(0.3f, 0.1f, 0);
            Nakami1.GetComponent<GroundEgg>().FoodsStart();

            //殻
            GameObject Cut1 = (GameObject)Resources.Load("EggKara");
            GameObject Cut2 = (GameObject)Resources.Load("EggKara");

            Vector3 tempPos1 = transform.position;
            Vector3 tempPos2 = transform.position;
            tempPos1.x += 3;//右
            tempPos2.x -= 3;
            // Cubeプレハブを元に、インスタンスを生成、

            Cut1 = Instantiate(Cut1, tempPos1, transform.rotation);
            Cut1.GetComponent<EggKara>().Vel = new Vector3(0.3f, 0.1f, 0);
            Cut1.GetComponent<EggKara>().FoodsStart();
            Cut2 = Instantiate(Cut2, tempPos2, Quaternion.Euler(0f, 180f, 0.0f));
            Cut2.GetComponent<EggKara>().Vel = new Vector3(-0.3f, 0.1f, 0);
            Cut2.GetComponent<EggKara>().FoodsStart();

            Destroy(gameObject);
        }
    }

    public override void NigiriTubushi()
    {
        GameObject Cut1 = (GameObject)Resources.Load("FallEgg");

        Vector3 tempPos1 = transform.position;


        Cut1 = Instantiate(Cut1, tempPos1, transform.rotation);
        //Cut1.GetComponent<CutTomato>().Vel = new Vector3(0.3f, 0.1f, 0);
        Cut1.GetComponent<FallEgg>().FoodsStart();
        

        //SoundManager.instance.SEPlay("おもちゃ切断SE");

        //Destroy(gameObject);
    }
}
