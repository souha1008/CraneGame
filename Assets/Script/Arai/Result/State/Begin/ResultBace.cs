using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ResultBace : ResultUI
{
    private Image m_Image;

    private Color m_ImageColor;

    [SerializeField, Header("アルファ変更速度")]
    private float m_AlphaVolum = 0.005f;

    private float m_Alpha = 0;

    void Start()
    {
        m_Image      = gameObject.GetComponent<Image>();
        m_ImageColor = m_Image.color;
    }

    void Update()
    {
        m_Alpha += m_AlphaVolum;
        m_Image.color = new Color(m_ImageColor.r, m_ImageColor.g, m_ImageColor.b, m_Alpha);

        if (m_Alpha >= 1)
        {
            GameObject.Find("ResultManager").GetComponent<ResultManager>().SetState(ResultStateEnum.STATE.SCORE);
            Destroy(this);
        }
    }
}
