using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PauseCoroutine : MonoBehaviour
{
    [SerializeField, ReadOnly] public bool mPaused = false;
    [SerializeField, ReadOnly] private float mPauseCooldown;

    [SerializeField][Tooltip("�|�[�Y�̃N�[���^�C��")] float pauseCoolTime;

    [SerializeField][Tooltip("��������|�[�Y������")] KeyCode pauseKey = KeyCode.P;

    [SerializeField][Tooltip("�I�𒆂̐F")] Color nowSelect;

    [Header("UI�n")]
    [SerializeField] Canvas Pause_Canvas = null;
    [SerializeField] Image Option;
    [SerializeField] Image Retry;
    [SerializeField] Image StageSelect;

    [SerializeField, ReadOnly] int SelectCount = 0;


    // �v���C�x�[�g�ϐ�

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
            mPauseCooldown += Time.deltaTime;
            if (mPauseCooldown > 1.0f) mPauseCooldown = 1.0f;
        }
        if (!mPaused)
        {
            mPauseCooldown -= Time.deltaTime;
            if (mPauseCooldown < 0.0f) mPauseCooldown = 0.0f;
        }
    }

    void Pause()
    {
        mPaused = true;
        Debug.Log("�|�[�Y����YO");
        Pause_Canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        StartCoroutine("PauseStart");
    }

    IEnumerator PauseStart()
    {
        Debug.Log("�|�[�Y��");
        StartCoroutine("PauseMenu");
        yield return new WaitUntil(() => Input.GetKeyDown(pauseKey) && mPauseCooldown >= pauseCoolTime);

        Debug.Log("�|�[�Y����");
        StopCoroutine("PauseMenu");
        mPaused = false;
        Pause_Canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 1.0f;
    }
    IEnumerator PauseMenu()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("��");
                SelectCount--;
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("��");
                SelectCount++;
            }
            if (SelectCount > 2) SelectCount = 0;   // ��ɂ���
            if (SelectCount < 0) SelectCount = 2;   // ���ɍs��


            switch(SelectCount)
            {
                case (int)SelectCorsor.Option:
                    Option.color = nowSelect;
                    Retry.color = Color.blue;
                    StageSelect.color = Color.blue;
                    break;

                case (int)SelectCorsor.Retry:
                    Option.color = Color.blue;
                    Retry.color = nowSelect;
                    StageSelect.color = Color.blue;
                    break;

                case (int)SelectCorsor.StageSelect:
                    Option.color = Color.blue;
                    Retry.color = Color.blue;
                    StageSelect.color = nowSelect;
                    break;
            }
            yield return null;
        }
    }

    IEnumerator CoolDown()
    {
        while (true) { 
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
}
