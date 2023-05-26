using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

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

    private ScoreData data;

    private bool skip = false;

    void Start()
    {
        StartCoroutine(Show());
    }

    void Update()
    {
        // スキップ
        if (!skip && (Input.GetKeyDown("joystick button 0") || Input.GetMouseButton(0)))
        {
            skip = true;
        }
    }
    
    private IEnumerator Show()
    {
        var wfs = new WaitForSeconds(interval);

        var data = GameObject.Find("Datas").GetComponent<ScoreData>();
        var offpos = this.GetComponent<RectTransform>().anchoredPosition;

        for (var i = index; i < Co.Const.FAZE_NUM; ++i)
        {
            if (!skip) yield return wfs;

            var p = Instantiate(score, this.transform);

            p.GetComponent<RectTransform>().anchoredPosition
                = new Vector2(defaultPos.x + offpos.x, defaultPos.y + offpos.y - distanceY * i);

            p.SetScore(data.GetScore(i));
        }

        if (!skip) yield return new WaitForSeconds(delay);

        Finish();
        yield break;
    }

    private void Finish()
    {
        manager.SetState(ResultStateEnum.STATE.METER);
        Destroy(this);
    }
}
