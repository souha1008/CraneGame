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

    private bool skip = false;

    void Start()
    {
//        m_Data = GameObject.Find("Datas").GetComponent<Datas>();

        StartCoroutine(Show());
    }

    void Update()
    {
        // スキップ
        if (!skip && /*Input.GetButtonDown("Submit")*/ Input.GetMouseButton(0))
        {
            skip = true;
        }
    }
    
    private IEnumerator Show()
    {
        var wfs = new WaitForSeconds(interval);

        for (var i = index; i < Co.Const.FAZE_NUM; ++i)
        {
            if (!skip) yield return wfs;

            var obj = Instantiate(image, this.transform);

            var offpos = this.transform.position;

            obj.rectTransform.anchoredPosition = new Vector2(defaultPos.x + offpos.x, defaultPos.y + offpos.y - distanceY * i);
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
