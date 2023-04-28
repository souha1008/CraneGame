using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreMeter : ResultUI
{
    private Slider meter;

    private float volum = 0;
    private float volumMax;

    private float value;
    private float valueMax;

    [SerializeField, Range(1.0f, 20.0f)]
    private float speed;

    [SerializeField]
    private float waitTime = 1;

    void Start()
    {
        meter = gameObject.GetComponent<Slider>();

        // test
        volumMax = 0.85f;
        // testend
        // スコア割合確認
    }

    void Update()
    {
        // 終了確認
        if (Input.GetButtonDown("Submit") || volum >= volumMax)
        {
            meter.value = volumMax;
            Invoke("NextState", waitTime);
        }
        else
        {
            volum += speed * Co.Const.SCORE_SPEED_MAG;
            meter.value = volum;
        }
    }

    /// <summary>
    /// 次状態へ移行
    /// </summary>
    private void NextState()
    {
        GameObject.Find("ResultManager").GetComponent<ResultManager>().SetState(ResultStateEnum.STATE.RESULT);
        Destroy(this);
    }
}
