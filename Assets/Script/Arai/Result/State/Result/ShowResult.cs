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
            manager.Sound.SEPlay("グッドSE");
        }

        image.sprite = resultSprites[(int)result];
        data.FinalResult = result;

        if (result == ResultEnum.RESULT.BAD)
        {
            manager.Sound.SEPlay("バッドSE");
            GameObject.Find("Animals(Clone)").GetComponent<Animals>().Bad();
        }

        StartCoroutine(Next(result));
    }

    public void Excellent()
    {
        // 表示をEXCELLENTに変える
        image.sprite = resultSprites[(int)ResultEnum.RESULT.EXCELLENT];
        data.FinalResult = ResultEnum.RESULT.EXCELLENT;
        manager.Sound.SEPlay("エクセレントSE");
    }

    private IEnumerator Next(ResultEnum.RESULT _result)
    {
        yield return new WaitForSecondsRealtime(waittime);

        if (_result == ResultEnum.RESULT.BAD)
            manager.SetState(ResultStateEnum.STATE.WAIT);
        else
            manager.SetState(ResultStateEnum.STATE.BADGE);

        yield break;
    }
}
