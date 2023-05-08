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
    private float time = 0;

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
        if (Input.GetButtonDown("Submit"))
        {
            meter.value = volumMax;
            Finish();
            return;
        }
        
        if (volum >= volumMax)
        {
            if (time <= 0) meter.value = volumMax;
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
            volum += speed * Co.Const.SCORE_SPEED_MAG;
            meter.value = volum;
        }
    }

    private void Finish()
    {
        GameObject.Find("ResultManager").GetComponent<ResultManager>().SetState(ResultStateEnum.STATE.RESULT);
        Destroy(this);
    }
}
