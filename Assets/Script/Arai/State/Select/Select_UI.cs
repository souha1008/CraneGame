using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Select_UI : MonoBehaviour
{
    private RectTransform m_Transform;
    private float m_DefaultX, m_DefaultY;
    protected bool m_Active = false;

    void Awake()
    {
        m_Transform = gameObject.GetComponent<RectTransform>();
        m_DefaultX = m_Transform.sizeDelta.x;
        m_DefaultY = m_Transform.sizeDelta.y;
    }

    void Start()
    {
        SubStart();
    }

    virtual protected void SubStart()
    {

    }

    void Update()
    {
        if (m_Active) SubUpdate();
    }

    virtual protected void SubUpdate()
    {

    }

    public void Activate()
    {
        m_Transform.sizeDelta = new Vector2(m_DefaultX * 1.5f, m_DefaultY * 1.5f);
        m_Active = true;
    }

    public void InActivate()
    {
        m_Transform.sizeDelta = new Vector2(m_DefaultX, m_DefaultY);
        m_Active = false;
    }
}
