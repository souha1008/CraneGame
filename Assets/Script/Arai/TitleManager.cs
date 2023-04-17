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
    // private List<TitleState> m_States = new List<TitleState>((int)TitleStateEnum.STATE.MAX);
    private TitleObjectList m_ObjectList;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Canvas == null)
        {
            Debug.Log("Canvas is null!");
        }
        if (m_ObjectList == null)
        {
            Debug.Log("List is null!");
        }

        StateSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        m_ObjectList.CreateObjects(m_NowState, m_Canvas);
    }
}
