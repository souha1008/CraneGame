using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    [SerializeField]
    private Sprite[] resultSprites = new Sprite[(int)ResultEnum.RESULT.MAX];

    private Image image;

    [SerializeField]
    private ResultText textMotion;

    [SerializeField]
    private float excellentScore;

    [SerializeField]
    private float goodScore;

    [SerializeField]
    private float testscore;

    void Start()
    {
        image = gameObject.GetComponent<Image>();

        var result = ResultEnum.RESULT.A;

/*
        var score = GameObject.Find("Datas").GetComponent<Datas>().GetAddScore();
        
        // リザルト分岐
        if (score > 2)
            result = RESULT.B;
*/
        // リザルト分岐
        if (testscore >= excellentScore)
            result = ResultEnum.RESULT.EXCELLENT;
        else if (testscore >= goodScore)
            result = ResultEnum.RESULT.B;

        image.sprite = resultSprites[(int)result];

        textMotion.Action(result);
        Destroy(this);
    }
}
