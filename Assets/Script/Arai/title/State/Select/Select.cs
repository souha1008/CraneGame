using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : TitleUI
{
    [SerializeField]
    private List<Select_UI> m_Uis;

    private int m_Index = 0;

    private float m_InputVolum = 0;         // 十字キー入力
    private float m_InputVolumStick = 0;    // スティック入力

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

    /// <summary>
    /// 入力確認
    /// </summary>
    private void CheckInput()
    {
        // 十字キー縦入力
        {
            var newvolum = Input.GetAxis("JuujiKeyY");
            if (m_InputVolum != newvolum)
            {
                SelectChange(newvolum);
            }
            m_InputVolum = newvolum;
        }
        // スティック縦入力
        {
            var newvolum = Input.GetAxis("Vertical");
            if (m_InputVolumStick != newvolum)
            {
                SelectChange(newvolum);
            }
            m_InputVolumStick = newvolum;
        }
    }

    /// <summary>
    /// 選択切り替え
    /// </summary>
    /// <param name="_volum">入力値（方向）</param>
    private void SelectChange(float _volum)
    {
        _volum *= -1;

        // 配列領域確認
        if ((m_Index + _volum) < 0 || (m_Index + _volum) > m_Uis.Capacity - 1)
            return;

        // 選択切り替え
        m_Uis[m_Index].InActivate();
        m_Index += (int)_volum;
        m_Uis[m_Index].Activate();
    }
}
