using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Wait : TitleUI
{
    private const float RATIO_MIN = 0;      // 媒介変数最小値
    private const float RATIO_MAX = 1.0f;   // 媒介変数最大値

    private Image m_Image;          // テクスチャ
    private Color m_ImageColor;     // テクスチャカラー
    
    [SerializeField, Header("初期アルファ値"), Range(0, 1)]
    private float m_Alpha = 1.0f;

    [SerializeField, Header("アルファ変更速度")]
    private float m_AlphaVolum = 0.005f;
    
    private float m_Ratio;  // 媒介変数

    private TitleManager m_Manager; // タイトルマネージャー

    private bool m_PressButton = false; // 押されたフラグ

    [SerializeField, Header("押されてから待機する時間")]
    private float m_WaitTime = 1.5f;

    [SerializeField]
    private Wait_Pushed m_PushedAction;

    void Start()
    {
        m_Image      = gameObject.GetComponent<Image>();
        m_ImageColor = m_Image.color;

        m_Ratio      = m_Alpha / 1.0f;

        m_Manager    = GameObject.Find("TitleManager").GetComponent<TitleManager>();
    }

    void Update()
    {
        // フラグ確認
        if (m_PressButton) return;
        
        // 何か押された
        if (Input.anyKeyDown)
        {
            m_PressButton = true;
            Invoke("ExitWait", m_WaitTime);
            m_Image.color = new Color(m_ImageColor.r, m_ImageColor.g, m_ImageColor.b, 1.0f);

            m_Manager.Sound.SEPlay("プレスエニーSE");

            m_PushedAction.Action();
        }
        else
        {
            // アルファ値設定
            m_Image.color = new Color(m_ImageColor.r, m_ImageColor.g, m_ImageColor.b, m_Alpha);

            // アルファ値計算
            m_Alpha = 1 - (1 - (m_Ratio / RATIO_MAX)) * (1 - (m_Ratio / RATIO_MAX) * (1 - (m_Ratio / RATIO_MAX)));

            // 媒介変数計算
            m_Ratio += m_AlphaVolum;

            // 媒介変数限界確認
            if (m_Ratio < RATIO_MIN || m_Ratio > RATIO_MAX)
            {
                m_AlphaVolum *= -1;
            }
        }
    }

    /// <summary>
    /// 待機解除
    /// </summary>
    private void ExitWait()
    {
        m_PushedAction.End();

        m_Manager.SetState(TitleStateEnum.STATE.SELECT);
        Destroy(gameObject);
    }
}
