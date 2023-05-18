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

    void Start()
    {
        image = gameObject.GetComponent<Image>();

        var result = ResultEnum.RESULT.A;

        var score = GameObject.Find("Datas").GetComponent<ScoreData>().GetScoreParcent();

        // リザルト分岐
        if (score >= excellentScore)
            result = ResultEnum.RESULT.EXCELLENT;
        else if (score >= goodScore)
            result = ResultEnum.RESULT.B;

        image.sprite = resultSprites[(int)result];

        textMotion.Action(result);
        Destroy(this);
    }
}
