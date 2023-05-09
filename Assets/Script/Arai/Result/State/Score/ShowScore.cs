using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShowScore : ResultUI
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private List<Sprite> sprites;

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

    void Start()
    {
//        m_Data = GameObject.Find("Datas").GetComponent<Datas>();

        Invoke("Show", interval);
    }

    void Update()
    {
        // スキップ
        if (Input.GetButtonDown("Submit"))
        {
            CancelInvoke("Show");

            for (var i = index; i < Co.Const.FAZE_NUM; ++i)
            {
                var obj = Instantiate(image);
                obj.transform.SetParent(this.transform.parent, false);

                var offpos = this.transform.parent.transform.position;

                obj.rectTransform.anchoredPosition = new Vector2(defaultPos.x + offpos.x, defaultPos.y + offpos.y - distanceY * i);
            }
            Finish();
        }
    }

    /// <summary>
    /// スコア表示
    /// </summary>
    private void Show()
    {
        if (index == Co.Const.FAZE_NUM)
        {
            Invoke("Finish", delay);
            return;
        }

        var obj = Instantiate(image);
        obj.transform.SetParent(this.transform.parent, false);

        // スコアのスプライトに切り替え

        var offpos = this.transform.parent.transform.position;

        obj.rectTransform.anchoredPosition = new Vector2(defaultPos.x + offpos.x, defaultPos.y + offpos.y - distanceY * index);

        ++index;
        Invoke("Show", interval);
    }

    private void Finish()
    {
        GameObject.Find("ResultManager").GetComponent<ResultManager>().SetState(ResultStateEnum.STATE.METER);
        Destroy(this);
    }
}
