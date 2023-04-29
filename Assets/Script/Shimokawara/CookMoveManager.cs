using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMoveManager : MonoBehaviour
{

    public GameObject[] GameStage;//最初は本作業場
    public int FadesTime = 20;

    public int FPS_Time = 0;

    static int SYATTA_TIME = 30;

    public GameObject Syatta;
    float SyattaMax;
    float SyattaMin = 0.873f;

    // Start is called before the first frame update
    void Start()
    {
        SyattaMax = Syatta.transform.localPosition.y;
        FPS_Time = 0;
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR
        if(Input.GetButtonDown("Jump"))
        {
            FPS_Time = FadesTime * 60 - SYATTA_TIME;
            //NextScene();
            //Debug.Log("呼ばれた");
        }
#endif
    }

    private void FixedUpdate()
    {
        FPS_Time++;

        if(FPS_Time > FadesTime * 60)
        {
            NextScene();
            FPS_Time = 0;

            Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, SyattaMin, Syatta.transform.localPosition.z);
        }
        //前後Nフレームで移動アニメーション
        else if(Mathf.Abs(( FadesTime * 60 / 2) - FPS_Time)  > (FadesTime * 60 / 2) - SYATTA_TIME)
        {
            float PosY = (float)((FadesTime * 60 / 2) - Mathf.Abs((FadesTime * 60 / 2) - FPS_Time)) / SYATTA_TIME * (SyattaMax - SyattaMin) + SyattaMin;
            Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, PosY, Syatta.transform.localPosition.z);
        }

        else
        {
            Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, SyattaMax, Syatta.transform.localPosition.z);
        }
    }

    public void NextScene()
    {
        GameObject[] Foods = GameObject.FindGameObjectsWithTag("Foods");
        for(int i = 0; i < Foods.Length;i++)//食べ物分
        {
            float thisNearMagni = 999999;//現状の最短距離
            int nearIndex = 0;
            Vector3 PosVector = Vector3.zero;//位置ベクトル

            for(int j =0; j < GameStage.Length; j++)//ステージ数分
            {
                float Magni = (Foods[i].transform.position - GameStage[j].transform.position).magnitude;
                if (thisNearMagni > Magni )
                {
                    thisNearMagni = Magni;
                    nearIndex = j;
                    PosVector = Foods[i].transform.position - GameStage[j].transform.position;
                }
            }

            if(nearIndex == 0)//消すべき
            {
                Destroy(Foods[i]);
            }

            else//次の箇所へ行くべき
            {
                Foods[i].transform.position = GameStage[nearIndex - 1].transform.position + PosVector;
            }
        }





        GameObject[] FoodsSupport = GameObject.FindGameObjectsWithTag("FoodsSupport");
        for (int i = 0; i < FoodsSupport.Length; i++)//食べ物分
        {
            float thisNearMagni = 999999;//現状の最短距離
            int nearIndex = 0;
            Vector3 PosVector = Vector3.zero;//位置ベクトル

            for (int j = 0; j < GameStage.Length; j++)//ステージ数分
            {
                float Magni = (FoodsSupport[i].transform.position - GameStage[j].transform.position).magnitude;
                if (thisNearMagni > Magni)
                {
                    thisNearMagni = Magni;
                    nearIndex = j;
                    PosVector = FoodsSupport[i].transform.position - GameStage[j].transform.position;
                }
            }

            if (nearIndex == 0)//消すべき
            {
                Destroy(FoodsSupport[i]);
            }

            else//次の箇所へ行くべき
            {
                FoodsSupport[i].transform.position = GameStage[nearIndex - 1].transform.position + PosVector;
            }
        }
    }
}
