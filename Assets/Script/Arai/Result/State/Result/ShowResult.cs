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

    private ScoreData data;
    private SaveManager save;

    void Start()
    {
        image = gameObject.GetComponent<Image>();

        float score = 0, border = 0;
        var result = ResultEnum.RESULT.BAD;

        var datas = GameObject.Find("Datas");
        data = datas.GetComponent<ScoreData>();
        save = datas.GetComponent<SaveManager>();

        score  = data.GetScoreParcent();
        border = data.ClearBorder;

        // リザルト分岐
        if (score >= border)
        {
            result = ResultEnum.RESULT.GOOD;
        }

        image.sprite = resultSprites[(int)result];
        data.FinalResult = result;

        StartCoroutine(Next());
    }

    public void Excellent()
    {
        // 表示をEXCELLENTに変える
        image.sprite = resultSprites[(int)ResultEnum.RESULT.EXCELLENT];
        data.FinalResult = ResultEnum.RESULT.EXCELLENT;
    }

    private IEnumerator Next()
    {
        yield return new WaitForSeconds(waittime);

        manager.SetState(ResultStateEnum.STATE.BADGE);

        yield break;
    }
}
