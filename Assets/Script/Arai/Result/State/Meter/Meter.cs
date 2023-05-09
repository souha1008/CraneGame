using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Meter : ResultUI
{
    [System.Serializable]
    public class MeterPct
    {
        [SerializeField]
        public float pct;

        [SerializeField]
        public Sprite sprite;
    }

    [SerializeField]
    private GameObject body;        // メーター増える部分
    private RectTransform body_tf;
    private Vector2 body_tf_defSize;
    private Image body_image;

    [SerializeField]
    private List<MeterPct> pct;    // 画像切り替え用
    private int pctIndex = 0;

    private float volum = 0;        // 割合
    private float volumMax;         // 最大割合


    [SerializeField, Range(1.0f, 20.0f)]
    private float speed = 5;         // メーター増加速度

    [SerializeField]
    private float waitTime = 0.8f;   // 待機時間
    private float time = 0;

    void Start()
    {
        body_tf     = body.GetComponent<RectTransform>();
        body_image  = body.GetComponent<Image>();

        body_tf_defSize = body_tf.sizeDelta;
        body_image.sprite = pct[pctIndex].sprite;
        ++pctIndex;

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
        
        if (volum < volumMax)
        {
            // ゲージ増加
            body_tf.sizeDelta = new Vector2(body_tf_defSize.x * volum, body_tf_defSize.y);
            volum += speed * Co.Const.SCORE_SPEED_MAG;

            if (pctIndex < pct.Count && volum >= pct[pctIndex].pct)
            {
                body_image.sprite = pct[pctIndex].sprite;
                ++pctIndex;
            }
        }
        else
        {
            // 待機
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
    }

    private void Finish()
    {
        GameObject.Find("ResultManager").GetComponent<ResultManager>().SetState(ResultStateEnum.STATE.RESULT);
        Destroy(this);
    }
}
