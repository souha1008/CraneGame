using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShowResult : ResultUI
{
    [SerializeField]
    private Sprite[] resultSprites = new Sprite[(int)ResultEnum.RESULT.MAX];

    private Image image;

    [SerializeField]
    private float waittime;

    private ScoreData datas;

    void Start()
    {
        image = gameObject.GetComponent<Image>();

        float score = 0, border = 0;
        var result = ResultEnum.RESULT.BAD;

        datas = GameObject.Find("Datas").GetComponent<ScoreData>();
        score  = datas.GetScoreParcent();
        border = datas.ClearBorder;

        // リザルト分岐
        if (score >= border)
        {
            result = ResultEnum.RESULT.GOOD;
        }

        image.sprite = resultSprites[(int)result];
        datas.FinalResult = result;

        StartCoroutine(Next());
    }

    public void Excellent()
    {
        // 表示をEXCELLENTに変える
        image.sprite = resultSprites[(int)ResultEnum.RESULT.EXCELLENT];
        datas.FinalResult = ResultEnum.RESULT.EXCELLENT;
    }

    private IEnumerator Next()
    {
        yield return new WaitForSeconds(waittime);

        manager.SetState(ResultStateEnum.STATE.BADGE);

        yield break;
    }
}
