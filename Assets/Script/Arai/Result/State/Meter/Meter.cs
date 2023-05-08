using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Meter : ResultUI
{
    [SerializeField, Header("ゲージ")]
    private GameObject body;

    private RectTransform body_tf;
    private Vector2 body_tf_defSize;
    private Image body_image;

    private float volum = 0;
    private float volumMax;


    [SerializeField, Range(1.0f, 20.0f)]
    private float speed = 5;

    [SerializeField]
    private float waitTime = 0.8f;
    private float time = 0;

    void Start()
    {
        body_tf     = body.GetComponent<RectTransform>();
        body_image  = body.GetComponent<Image>();

        body_tf_defSize = body_tf.sizeDelta;

        // test
        volumMax = 0.85f;
        // testend
        // スコア割合確認
    }

    void Update()
    {
        // 終了確認
        if (Input.GetButtonDown("Submit"))
        {
            body_tf.sizeDelta = new Vector2(body_tf_defSize.x * volumMax, body_tf_defSize.y);
            Finish();
            return;
        }
        
        if (volum >= volumMax)
        {
            if (time <= 0) body_tf.sizeDelta = new Vector2(body_tf_defSize.x * volumMax, body_tf_defSize.y);
            else
            {
                if (time >= waitTime)
                {
                    Finish();
                }
            }
            time += Time.deltaTime;
        }
        else
        {
            body_tf.sizeDelta = new Vector2(body_tf_defSize.x * volum, body_tf_defSize.y);
            volum += speed * Co.Const.SCORE_SPEED_MAG;
        }
    }

    private void Finish()
    {
        GameObject.Find("ResultManager").GetComponent<ResultManager>().SetState(ResultStateEnum.STATE.RESULT);
        Destroy(this);
    }
}
