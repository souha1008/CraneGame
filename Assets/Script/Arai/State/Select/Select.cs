using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : TitleUI
{
    [SerializeField]
    private List<Select_UI> m_Uis;

    private int m_Index = 0;

    private float m_InputVolum = 0;
    private float m_InputVolumStick = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectChange(m_Index);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        {
            var newvolum = Input.GetAxis("JuujiKeyY");
            if (m_InputVolum != newvolum)
            {
                SelectChange(newvolum);
            }
            m_InputVolum = newvolum;
        }
        {
            var newvolum = Input.GetAxis("Vertical");
            if (m_InputVolumStick != newvolum)
            {
                SelectChange(newvolum);
            }
            m_InputVolumStick = newvolum;
        }
    }

    private void SelectChange(float _volum)
    {
        _volum *= -1;

        if ((m_Index + _volum) < 0 || (m_Index + _volum) > m_Uis.Capacity - 1)
            return;

        m_Uis[m_Index].InActivate();
        m_Index += (int)_volum;
        m_Uis[m_Index].Activate();
    }
}
