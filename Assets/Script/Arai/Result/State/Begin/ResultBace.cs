using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ResultBace : ResultUI
{
    private Image image;

    private Color imageColor;

    [SerializeField, Header("アルファ変更速度")]
    private float alphaVolum = 0.005f;
    
    [SerializeField, Range(0.1f, 1.0f)]
    private float alphaMax = 1;

    private float alpha = 0;

    [SerializeField]
    private Image world;
    
    [SerializeField]
    private Image stage;

    [SerializeField]
    private Numbers numbers;

    void Start()
    {
        image      = gameObject.GetComponent<Image>();
        imageColor = image.color;

        var a = GameObject.Find("Datas");
        var datas = GameObject.Find("Datas").GetComponent<ScoreData>();

        world.sprite = numbers.numbers[datas.WorldIndex + 1];
        stage.sprite = numbers.numbers[datas.StageIndex + 1];
        
        manager.SetState(ResultStateEnum.STATE.SCORE);
        Destroy(this);
    }

    void Update()
    {
        
    }
}
