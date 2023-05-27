using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private Canvas m_Canvas;

    [SerializeField, Header("初期状態")]
    private TitleStateEnum.STATE m_NowState = TitleStateEnum.STATE.WAIT;
    
    [SerializeField, Header("状態時生成物")]
    private TitleObjectList m_ObjectList;

    private SoundManager sound;
    public SoundManager Sound
    {
        get => sound;
    }

    void Start()
    {
        StateSetting();

        sound = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if(!sound.CheckPlayBGM("タイトルBGM")) sound.BGMPlay("タイトルBGM", true);
    }

    /// <summary>
    /// 状態設定
    /// </summary>
    /// <param name="_newstate">新規状態</param>
    public void SetState(TitleStateEnum.STATE _newstate)
    {
        if (_newstate == TitleStateEnum.STATE.MAX) return;

        m_NowState = _newstate;
        StateSetting();
    }

    /// <summary>
    /// ステート設定
    /// </summary>
    private void StateSetting()
    {
        m_ObjectList.CreateObjects(m_NowState, m_Canvas, this);
    }
}
