using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("カウントダウンデフォルト")]
    float DefaultTime = 0.0f;
    
    [SerializeField]
    [Tooltip("カウントダウンするUIオブジェクト")] Text CountDownText;

    [SerializeField]
    [Tooltip("時間の横に表示させたいテキスト")]
    string TimeExplanation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownText.text = string.Format(TimeExplanation) + DefaultTime.ToString("00");
        DefaultTime -= Time.deltaTime;

        if(DefaultTime <= 0.0f) DefaultTime = 0.0f;
    }
}
