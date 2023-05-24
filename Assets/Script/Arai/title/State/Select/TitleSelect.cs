using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSelect : TitleObject
{
    [SerializeField]
    private List<Select_Object> m_Objects;

    [SerializeField, EditLock]
    private int m_Index = 0;

    private float m_InputVolum = 0;         // 十字キー入力
    private float m_InputVolumStick = 0;    // スティック入力

    private bool move = true;

    [SerializeField]
    private float offset = 5;
    [SerializeField]
    private float moveTime = 5;

    private float moveVolum;

    // Start is called before the first frame update
    void Start()
    {
        m_Objects[m_Index].Activate();

        gameObject.transform.position = gameObject.transform.position - new Vector3(0, offset, 0);
        moveVolum = offset / moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)  CheckInput();
        else        Move();
    }

    /// <summary>
    /// 入力確認
    /// </summary>
    private void CheckInput()
    {
        {
            if (/*Input.GetButtonDown("Submit")*/ Input.GetMouseButton(0))
            {
                m_Objects[m_Index].PushAction();
                Destroy(this);
                return;
            }

            ///// 後で消す
            if(Input.GetKeyDown(KeyCode.RightArrow)) SelectChange(-1);
            if(Input.GetKeyDown(KeyCode.LeftArrow)) SelectChange(1);
            /////
        }
        //// 十字キー入力
        //{
        //    var newvolum = Input.GetAxis("JuujiKeyX");
        // 
        //    if (m_InputVolum != newvolum)
        //    {
        //        SelectChange(newvolum);
        //    }
        //    m_InputVolum = newvolum;
        //}
        //// スティック入力
        //{
        //    var newvolum = Input.GetAxis("Horizontal");
        //    if (m_InputVolumStick != newvolum)
        //    {
        //        SelectChange(newvolum);
        //    }
        //    m_InputVolumStick = newvolum;
        //}
    }
    
    /// <summary>
    /// 選択切り替え
    /// </summary>
    /// <param name="_volum">入力値（方向）</param>
    private void SelectChange(float _volum)
    {
        _volum *= -1;

        m_Objects[m_Index].InActivate();
        m_Index += (int)_volum;

        // 配列領域確認
        if (m_Index < 0)
        {
            m_Index = m_Objects.Capacity - 1;
        }
        else if (m_Index > m_Objects.Capacity - 1)
        {
            m_Index = 0;
        }

        m_Objects[m_Index].Activate();
    }

    private void Move()
    {
        gameObject.transform.position = gameObject.transform.position + new Vector3(0, moveVolum * Time.deltaTime, 0);

        moveTime -= Time.deltaTime;
        if (moveTime <= 0)
        {
            move = false;
        }
    }
}
