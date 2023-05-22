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

    void Start()
    {
        image = gameObject.GetComponent<Image>();

        float score = 0, border = 0;
        var result = ResultEnum.RESULT.BAD;

        {
            var data = GameObject.Find("Datas").GetComponent<ScoreData>();
            score  = data.GetScoreParcent();
            border = data.ClearBorder;
        }

        // リザルト分岐
        if (score >= border)
        {
            if (score > 10)
            {

            }
            else
            {
                result = ResultEnum.RESULT.GOOD;
            }
        }

        image.sprite = resultSprites[(int)result];

        textMotion.Action(result);
        Destroy(this);
    }
}
