using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSelect : TitleObject
{
    [SerializeField]
    private List<Select_Object> m_Objects;

    [SerializeField]
    private int m_Index = 0;

    private float m_InputVolum = 0;         // 十字キー入力
    private float m_InputVolumStick = 0;    // スティック入力

    private bool move = true;

    [SerializeField]
    private float offset = 5;
    [SerializeField]
    private float moveTime = 5;

    private float moveVolum;

    private bool setting = false;
    public bool Setting
    {
        set => setting = value;
    }

    private ReadIsFade fade;

    private GameObject settingobj;

    void Start()
    {
        m_Objects[m_Index].Activate();

        if (manager.First)
        {
            gameObject.transform.position = gameObject.transform.position - new Vector3(0, offset, 0);
            moveVolum = offset / moveTime;
        }
        else
        {
            move = false;
        }
        fade = GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>();

        settingobj = GameObject.Find("Title_OptionManager").transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (fade.GetIsFade()) return;
        if (setting)
        {
            if (!settingobj.activeInHierarchy)
                setting = false;
            return;
        }
        
        if (!move)  CheckInput();
        else        Move();
    }

    /// <summary>
    /// 入力確認
    /// </summary>
    private void CheckInput()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            m_Objects[m_Index].PushAction();
            manager.Sound.SEPlay("決定SE");
            if (m_Index != 1) Destroy(this);
            else setting = true;
            return;
        }
        
        // 十字キー入力
        {
            var newvolum = Input.GetAxis("JuujiKeyX");
         
            if (m_InputVolum != newvolum)
            {
                SelectChange(-newvolum);
            }
            m_InputVolum = newvolum;
        }
        // スティック入力
        {
            var newvolum = Input.GetAxis("Horizontal");
            if (m_InputVolumStick != newvolum)
            {
                SelectChange(-newvolum);
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
        if ((int)_volum == 0) return;

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

        manager.Sound.SEPlay("選択SE");
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
