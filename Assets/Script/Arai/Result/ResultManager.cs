using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Canvas m_Canvas;

    [SerializeField]
    private ResultStateEnum.STATE m_NowState = ResultStateEnum.STATE.BEGIN;

    [SerializeField]
    private ResultObjectList m_ObjectList;

    void Start()
    {
        StateSetting();
    }
    
    /// <summary>
    /// 状態設定
    /// </summary>
    /// <param name="_newstate">新規状態</param>
    public void SetState(ResultStateEnum.STATE _newstate)
    {
        if (_newstate == ResultStateEnum.STATE.MAX) return;

        m_NowState = _newstate;
        StateSetting();
    }
    
    /// <summary>
    /// ステート設定
    /// </summary>
    private void StateSetting()
    {
        m_ObjectList.CreateObjects(m_NowState, m_Canvas);
    }
}
