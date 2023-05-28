using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

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
    private TextMeshProUGUI world;

    [SerializeField]
    private TextMeshProUGUI stage;
    
    private ReadIsFade fade;

    void Start()
    {
        image      = gameObject.GetComponent<Image>();
        imageColor = image.color;

        var a = GameObject.Find("Datas");
        var datas = GameObject.Find("Datas").GetComponent<ScoreData>();

        world.text = (datas.WorldIndex + 1).ToString();
        stage.text = (datas.StageIndex + 1).ToString();
        
        fade = GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>();

        //manager.SetState(ResultStateEnum.STATE.SCORE);
        //Destroy(this);
    }

    void Update()
    {
        if (!fade.GetIsFade())
        {
            manager.SetState(ResultStateEnum.STATE.SCORE);
            Destroy(this);
        }
    }
}
