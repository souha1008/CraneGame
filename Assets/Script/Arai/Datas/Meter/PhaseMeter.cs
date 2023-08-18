using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PhaseMeter : MonoBehaviour
{
    public static PhaseMeter instance;

    [SerializeField]
    private GameObject body;        // メーター増える部分
    private RectTransform body_tf;
    private Vector2 body_tf_defSize;
    private Image body_image;

    [SerializeField]
    private Image border;

    private float percent = 0;        // 現在割合

    private float nowvalue = 0;
    private float valueMax;           // 最大値
    public float ValueMax
    {
        set => valueMax = value;
    }

    private bool increasing = false;
    private bool add = false;
    private bool reset = false;

    [SerializeField, Range(0.001f, 20.0f)]
    private float speed = 5;         // メーター増加速度

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
        body_tf     = body.GetComponent<RectTransform>();
        body_image  = body.GetComponent<Image>();

        body_tf_defSize = body_tf.sizeDelta;

        body_tf.sizeDelta = new Vector2(0, body_tf_defSize.y);
    }

    private IEnumerator GainMeter()
    {
        increasing = true;
        
        var finpercent = nowvalue / valueMax;
        var waitframe = new WaitForSecondsRealtime(0.016f);

        while(percent < finpercent)
        {
            if (reset)
            {
                increasing = false;
                reset = false;
                yield break;
            }
            // 後加算
            if (add)
            {
                finpercent = nowvalue / valueMax;
                add = false;
            }

            // ゲージ増加
            body_tf.sizeDelta = new Vector2(body_tf_defSize.x * percent, body_tf_defSize.y);
            percent += speed * Co.Const.SCORE_SPEED_MAG;

            // 1フレーム待機
            yield return waitframe;
        }
        // 保険で最終サイズに調整
        percent = finpercent;
        body_tf.sizeDelta = new Vector2(body_tf_defSize.x * finpercent, body_tf_defSize.y);

        increasing = false;
        yield break;
    }
    
    /// <summary>
    /// メーター増加（元値入れ）
    /// </summary>
    /// <param name="_value">値</param>
    public void SetMeter(float _value)
    {
        if (_value <= valueMax) nowvalue = _value;
        else                    nowvalue = valueMax;

        if (!increasing)
        {
            StartCoroutine(GainMeter());
        }
        else
        {
            add = true;
        }
    }

    /// <summary>
    /// メーター増加（値加算）
    /// </summary>
    /// <param name="_value">値</param>
    public void AddMeter(float _value)
    {
        if (nowvalue + _value <= valueMax) nowvalue += _value;
        else                               nowvalue = valueMax;

        if (!increasing)
        {
            StartCoroutine(GainMeter());
        }
        else
        {
            add = true;
        }
    }

    /// <summary>
    /// メーターリセット
    /// </summary>
    public void ResetMeter()
    {
        if(increasing) reset = true;
        body_tf.sizeDelta = new Vector2(0, body_tf_defSize.y);
        percent = 0;
        nowvalue = 0;
    }

    public void SetBorder(float _value)
    {
        var bt = border.GetComponent<RectTransform>();
        bt.sizeDelta = new Vector2(bt.sizeDelta.x * _value, bt.sizeDelta.y);
    }
}
