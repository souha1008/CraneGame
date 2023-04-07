using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public enum KNIFE_STATE
    {
        Have,
        Cut,
        Ground
    }

    KNIFE_STATE KnifeState;

    float rAngle;
    float MIN_ANGLE = 0;
    float MAX_ANGLE = Mathf.PI * 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        KnifeState = KNIFE_STATE.Have;
    }

    // Update is called once per frame
    void Update()
    {
        if(KnifeState == KNIFE_STATE.Have)
        {
            this.transform.position = knifeHassya.instance.transform.position;
        }
    }
    private void FixedUpdate()
    {

        switch (KnifeState)
        {
            case KNIFE_STATE.Have:

                RotateKnife();
                if (Input.GetButton("Lbutton"))
                {
                    KnifeState = KNIFE_STATE.Cut;
                    knifeHassya.instance.haveKnife = false;
                }
                break;

            case KNIFE_STATE.Cut:
                UpdateCut();
                break;

            case KNIFE_STATE.Ground:
                break;

        }

        if(!knifeHassya.instance.gameObject.activeInHierarchy)
        {
            knifeHassya.instance.haveKnife = false;
            knifeHassya.instance.RespawnCnt = 0;
            Destroy(gameObject);

        }

    }

    void UpdateCut()
    {
        bool isGround = false;

        //キャラクターから真下方向へのレイを作成する
        Ray underRay = new Ray(this.transform.position, new Vector3(0.0f, -1.0f, 0.0f).normalized);
        RaycastHit underHit; //当たった結果を代入する変数
        //レイを飛ばしてオブジェクトに当たれば
        if (Physics.Raycast(underRay, out underHit, 10.0f))
        {
            //あたったのがプラットフォームなら
            if (underHit.collider.gameObject.tag == "EscarateUp" ||
                underHit.collider.gameObject.tag == "EscarateRight" ||
                underHit.collider.gameObject.tag == "EscarateDown")
            {
                float distance = underHit.distance; //レイの開始位置と当たったオブジェクトの距離を取得
                                                    //Debug.Log(distance);
                if (distance < transform.localScale.y / 2 + 0.1f)  //※Unityちゃんの身長の場合0.04くらいで地面に接触した状態
                {
                    isGround = true; //地面に接触している


                }


            }
        }

        if (!isGround)
        {
            //if (isGo)
            {
                Vector3 temp = transform.position;
                temp.y -= 0.3f;
                transform.position = temp;
            }
        }
        else
        {
            KnifeState = KNIFE_STATE.Ground;
        }
    }



    void RotateKnife()
    {

        Vector2 LeftStick;
        LeftStick.x = Input.GetAxis("RightX");
        LeftStick.y = Input.GetAxis("RightY");

        float length = Mathf.Sqrt(LeftStick.x * LeftStick.x + LeftStick.y * LeftStick.y);//大きさ

        float temp = ((Input.GetAxis("RightY")) + 1) * 0.5f;
        rAngle = temp * MAX_ANGLE;


        Quaternion rot = Quaternion.AngleAxis(rAngle * 180 / Mathf.PI, Vector3.right);

        transform.rotation = rot;
    }
}
