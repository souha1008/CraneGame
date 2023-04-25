using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeHassya : MonoBehaviour
{
    static public knifeHassya instance;

    public bool haveKnife = true;
    public bool OldHaveKnife = true;

    public int RespawnCnt = 0;
    public int RESPAWN_TIME = 120;

    
    public GameObject Knife;
    bool isUnLock;
    public GameObject LockTex;

  

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        OldHaveKnife = haveKnife = false;
    }

    private void OnEnable()
    {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        


       

        //if (Input.GetButton("Lbutton"))
        //{
        //    Release();
        //}

        CheckRespawn();

        OldHaveKnife = haveKnife;
    }

    

    void Release()
    {
        haveKnife = false;
    }

    void CheckRespawn()
    {
        if(haveKnife == false && OldHaveKnife == true)
        {
            RespawnCnt = RESPAWN_TIME;
        }

        RespawnCnt--;

        if(haveKnife == false && RespawnCnt <= 0)
        {
            haveKnife = true;
            // CubeプレハブをGameObject型で取得
            Knife = null;
            Knife = (GameObject)Resources.Load("Knife");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(Knife, transform.position, Quaternion.identity);

        }
    }
}
