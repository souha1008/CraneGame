using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Select_UI : MonoBehaviour
{
    [SerializeField, Header("選択時画像")]
    protected Sprite m_ActiveSprite;

    [SerializeField, Header("非選択時画像")]
    protected Sprite m_InActiveSprite;

    private Image m_Image;

    protected bool m_Active = false;

    void Awake()
    {
        m_Image = gameObject.GetComponent<Image>();
        m_Image.sprite = m_InActiveSprite;
    }

    void Start()
    {

    }

    void Update()
    {
        // 選択＋決定ボタン
        if (m_Active && Input.GetButtonDown("Submit"))
            PushAction();
    }

    /// <summary>
    /// 押された動作
    /// </summary>
    virtual public void PushAction()
    {

    }

    /// <summary>
    /// 活性化
    /// </summary>
    public void Activate()
    {
        m_Image.sprite = m_ActiveSprite;
        m_Active = true;
    }

    /// <summary>
    /// 非活性化
    /// </summary>
    public void InActivate()
    {
        m_Image.sprite = m_InActiveSprite;
        m_Active = false;
    }
}
