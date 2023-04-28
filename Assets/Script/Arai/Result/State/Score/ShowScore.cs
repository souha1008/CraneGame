using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShowScore : ResultUI
{
    [SerializeField]
    private Image m_Image;

    [SerializeField]
    private List<Sprite> m_Sprites;

    [SerializeField]
    private Vector2 defaultPos;
    
    [SerializeField]
    private float distanceY;

    [SerializeField]
    private float interval;

    private int m_Index = 0;

    private ScoreData m_Data;

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

            for (var i = m_Index; i < Co.Const.FAZE_NUM; ++i)
            {
                var obj = Instantiate(m_Image);
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
        if (m_Index == Co.Const.FAZE_NUM)
        {
            Finish();
            return;
        }

        var obj = Instantiate(m_Image);
        obj.transform.SetParent(this.transform.parent, false);

        // スコアのスプライトに切り替え

        var offpos = this.transform.parent.transform.position;

        obj.rectTransform.anchoredPosition = new Vector2(defaultPos.x + offpos.x, defaultPos.y + offpos.y - distanceY * m_Index);

        ++m_Index;
        Invoke("Show", interval);
    }

    private void Finish()
    {
        GameObject.Find("ResultManager").GetComponent<ResultManager>().SetState(ResultStateEnum.STATE.METER);
        Destroy(this);
    }
}
