using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PauseCoroutine : MonoBehaviour
{
    [SerializeField, ReadOnly] public bool mPaused = false;
    [SerializeField, ReadOnly] private float mPauseCooldown;

    [SerializeField][Tooltip("ポーズのクールタイム")] float pauseCoolTime;

    [SerializeField][Tooltip("押したらポーズする画面")] KeyCode pauseKey = KeyCode.P;

    [SerializeField][Tooltip("選択中の色")] Color nowSelectColor;

    [Header("UI系")]
    [SerializeField] Canvas Pause_Canvas = null;
    [SerializeField] Image Option;
    [SerializeField] Image Retry;
    [SerializeField] Image StageSelect;

    [SerializeField, ReadOnly] int SelectCount = 0;

    [SerializeField] Animator animator_Pause;
    [SerializeField] string UI_anim_paramator;

    // プライベート変数

    enum SelectCorsor
    {
        Option = 0,
        Retry = 1,
        StageSelect = 2,
        max
    };

    private void Awake()
    {
        Pause_Canvas.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CoolDown");
    }


    // Update is called once per frame
    void FixedUpdate()
    {


    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey) && mPauseCooldown <= 0.0f)
        {
            Pause();
        }

        //Cooldown();
    }

    void Cooldown()
    {
        if (mPaused)
        {
            mPauseCooldown += 1;
            if (mPauseCooldown > pauseCoolTime) mPauseCooldown = pauseCoolTime;
        }
        if (!mPaused)
        {
            mPauseCooldown -= 1;
            if (mPauseCooldown < 0.0f) mPauseCooldown = 0.0f;
        }
    }

    void Pause()
    {
        mPaused = true;
        Debug.Log("ポーズしたYO");
        Pause_Canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        
        StartCoroutine("PauseStart");
    }

    IEnumerator PauseStart()
    {
        Debug.Log("ポーズ中");
        StartCoroutine("PauseMenu");
        yield return new WaitUntil(() => Input.GetKeyDown(pauseKey) && mPauseCooldown >= pauseCoolTime);

        Debug.Log("ポーズ解除");
        StopCoroutine("PauseMenu");
        mPaused = false;
        Pause_Canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        
    }
    IEnumerator PauseMenu()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("上");
                SelectCount--;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("下");
                SelectCount++;
            }
            if (SelectCount > 2) SelectCount = 0;   // 上にいく
            if (SelectCount < 0) SelectCount = 2;   // 下に行く


            switch(SelectCount)
            {
                case (int)SelectCorsor.Option:
                    Option.color = nowSelectColor;
                    Retry.color = Color.blue;
                    StageSelect.color = Color.blue;
                    if (Input.GetKeyDown(KeyCode.Space)) CallOption();
                    break;

                case (int)SelectCorsor.Retry:
                    Option.color = Color.blue;
                    Retry.color = nowSelectColor;
                    StageSelect.color = Color.blue;
                    break;

                case (int)SelectCorsor.StageSelect:
                    Option.color = Color.blue;
                    Retry.color = Color.blue;
                    StageSelect.color = nowSelectColor;
                    break;
            }
            yield return null;
        }
    }

    IEnumerator CoolDown()
    {
        while (true)
        {
            if (mPaused)
            {
                mPauseCooldown += 1;
                if (mPauseCooldown > pauseCoolTime) mPauseCooldown = pauseCoolTime;
            }
            if (!mPaused)
            {
                mPauseCooldown -= 1;
                if (mPauseCooldown < 0.0f) mPauseCooldown = 0.0f;
            }
            yield return null;
        }
    }

    IEnumerator C_Option()
    {
        while (true)
        {


            // ポーズメニューへ戻る
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine("PauseMenu");
                StartCoroutine("CoolDown");
                animator_Pause.SetBool(UI_anim_paramator, false);
                yield return null;
            }
        }
    }

    void CallOption()
    {
        animator_Pause.SetBool(UI_anim_paramator, true);
        StopCoroutine("PauseMenu");
        StopCoroutine("CoolDown");
        StartCoroutine("C_Option");
    }
}
