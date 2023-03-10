using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEgg : MonoBehaviour
{
    public bool isGround = false;
    float BallSize;
    Vector3 Vel = Vector3.zero;
    float GLAVITY = 0.006f;
    public GameObject GroundEgg;

    // Start is called before the first frame update
    void Start()
    {
        BallSize = transform.localScale.y/* * transform.lossyScale.x*/;
        GroundEgg.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vel.y -= GLAVITY;


        //キャラクターから真下方向へのレイを作成する
        Ray underRay = new Ray(this.transform.position, new Vector3(0.0f, -1.0f, 0.0f).normalized);
        //RaycastHit underHit; //当たった結果を代入する変数
        //レイを飛ばしてオブジェクトに当たれば
       // if (Physics.Raycast(underRay, out underHit, 10))
        {
            //配列化
            RaycastHit[] hitArray = Physics.RaycastAll(underRay,10);
            //えらい奴選び
            if(hitArray.Length > 0)
            {
                int justIndex = -1;
                //Debug.Log(hitArray.Length + "レングス");
                for (int i = 0; i < hitArray.Length; i++)
                {
                    if (hitArray[i].collider.gameObject.tag != "PlatForm")
                    {
                        continue;
                    }
                    else
                    {
                        if (justIndex < 0)//初見
                        {
                            justIndex = i;//platform比べ
                        }
                        else
                        {
                            if (hitArray[i].distance <= hitArray[justIndex].distance)//更新
                            {
                                justIndex = i;
                            }
                        }

                    }
                }
                if(justIndex >= 0)
                {
                    RaycastHit hit = hitArray[justIndex];



                    float distance = hit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                   //Debug.Log(distance);
                    if (distance < BallSize / 2 + 0.1f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                    {
                        isGround = true; //地面に接触している

                        if (Vel.y < 0.0f)
                            Vel.y = 0.0f;

                        Vector3 temp = hit.point;
                        temp.y += BallSize / 2;

                        transform.position = temp;


                        GroundEgg.GetComponent<Renderer>().enabled = true;
                        GroundEgg.transform.position = hit.point;
                        Destroy(this.gameObject);

                    }
                }
               
            }
            
            
        }

        //エスカレート処理
        if (isGround)
        {
            Vector3 tempPos = transform.position;
            tempPos.z -= 0.05f;
            transform.position = tempPos;
        }

        if (GetComponent<Renderer>().enabled == false)
        {
            Vel = Vector3.zero;
        }

        transform.position += Vel;
    }
}