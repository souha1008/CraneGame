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

    void Start()
    {
        image      = gameObject.GetComponent<Image>();
        imageColor = image.color;
        
        manager.SetState(ResultStateEnum.STATE.SCORE);
        Destroy(this);
    }

    void Update()
    {
        
    }
}
