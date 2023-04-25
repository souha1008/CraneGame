using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMoveManager : MonoBehaviour
{

    public GameObject[] GameStage;//最初は本作業場

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            NextScene();
            Debug.Log("呼ばれた");
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
