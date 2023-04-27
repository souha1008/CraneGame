using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Wait_Pushed_Blink : Wait_Pushed
{
    [SerializeField, Header("待機中点滅速度")]
    private float m_BlinkTime = 0.1f;
    
    private Image m_Image;

    void Start()
    {
        m_Image = gameObject.GetComponent<Image>();
    }

    public override void Action() 
    {
        InvokeRepeating("Blink", m_BlinkTime, m_BlinkTime);
    }

    public override void End()
    {
        CancelInvoke("Blink");
    }
    
    private void Blink()
    {
        m_Image.enabled = !m_Image.enabled;
    }
}
