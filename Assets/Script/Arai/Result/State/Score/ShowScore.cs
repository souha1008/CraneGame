using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : ResultUI
{
    [SerializeField]
    private PhaseScore score;

    [SerializeField]
    private Vector2 defaultPos;
    
    [SerializeField]
    private float distanceY;

    [SerializeField]
    private float interval;

    [SerializeField]
    private float delay;

    private int index = 0;

    private bool skip = false;

    void Start()
    {
        StartCoroutine(Show());
    }

    void Update()
    {
        // スキップ
        if (!skip && Input.GetKeyDown("joystick button 1"))
        {
            skip = true;
        }
    }
    
    private IEnumerator Show()
    {
        var wfs = new WaitForSecondsRealtime(interval);

        var data = GameObject.Find("Datas").GetComponent<ScoreData>();
        var offpos = this.GetComponent<RectTransform>().anchoredPosition;

        for (var i = index; i < Co.Const.FAZE_NUM; ++i)
        {
            if (!skip)
            {
                yield return wfs;
                manager.Sound.SEPlay("スコア表示SE");
            }

            var p = Instantiate(score, this.transform);

            p.GetComponent<RectTransform>().anchoredPosition
                = new Vector2(defaultPos.x + offpos.x, defaultPos.y + offpos.y - distanceY * i);

            p.SetScore(data.GetScore(i));
            p.SS = this;
        }

        if (!skip) yield return new WaitForSecondsRealtime(delay);

        Finish();
        yield break;
    }

    private void Finish()
    {
        manager.SetState(ResultStateEnum.STATE.METER);
        Destroy(this);
    }
}
