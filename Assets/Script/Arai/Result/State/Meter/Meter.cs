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

    private bool active = false;

    private bool skip = false;

    void Start()
    {
        body_tf     = body.GetComponent<RectTransform>();
        body_image  = body.GetComponent<Image>();

        body_tf_defSize = body_tf.sizeDelta;
        body_image.sprite = pct[pctIndex].sprite;
        ++pctIndex;

        body_tf.sizeDelta = new Vector2(0, body_tf_defSize.y);

        // test
        volumMax = GameObject.Find("Datas").GetComponent<ScoreData>().GetScoreParcent();
        // testend
        // スコア割合確認
    }

    void Update()
    {
        if (!active) return;

        // 終了確認
        if (!skip && (Input.GetKeyDown("joystick button 0") || Input.GetMouseButton(0)))
        {
            skip = true;
        }
    }

    private IEnumerator GainMeter()
    {
        var waitframe = new WaitForEndOfFrame();

        while(volum < volumMax)
        {
            // ゲージ増加
            body_tf.sizeDelta = new Vector2(body_tf_defSize.x * volum, body_tf_defSize.y);
            volum += speed * Co.Const.SCORE_SPEED_MAG;

            // テクスチャ切り替え
            if (pctIndex < pct.Count && volum >= pct[pctIndex].pct)
            {
                body_image.sprite = pct[pctIndex].sprite;
                ++pctIndex;
            }

            if (!skip) yield return waitframe;
        }
        body_tf.sizeDelta = new Vector2(body_tf_defSize.x * volumMax, body_tf_defSize.y);

        yield return new WaitForSeconds(waitTime);

        Finish();
        yield break;
    }

    private void Finish()
    {
        manager.SetState(ResultStateEnum.STATE.RESULT);
        Destroy(this);
    }

    public void Activate()
    {
        active = true;
        manager.Sound.SEPlay("メータアップSE");
        StartCoroutine(GainMeter());
    }
}
