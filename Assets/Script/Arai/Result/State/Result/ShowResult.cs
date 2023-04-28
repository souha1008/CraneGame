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

        var result = ResultEnum.RESULT.A;

/*
        var score = GameObject.Find("Datas").GetComponent<Datas>().GetAddScore();
        
        // リザルト分岐
        if (score > 2)
            result = RESULT.B;
*/
        image.sprite = resultSprites[(int)result];

        textMotion.Action(result);
        Destroy(this);
    }
}
