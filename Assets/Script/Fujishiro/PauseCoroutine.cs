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

    [SerializeField][Tooltip("�I�𒆂̐F")] Color nowSelectColor;

    [Header("UI�n")]
    [SerializeField] Canvas Pause_Canvas = null;
    [SerializeField] Image Option;
    [SerializeField] Image Retry;
    [SerializeField] Image StageSelect;

    [SerializeField, ReadOnly] int SelectCount = 0;

    [SerializeField] Animator animator_Pause;
    [SerializeField] string UI_anim_paramator;

    // �v���C�x�[�g�ϐ�
    private bool isPauseMenu = false;

    enum SelectCorsor
    {
        Option = 0,
        Retry = 1,
        StageSelect = 2,
        max
    };

    void SetIsPauseMenu(bool set)
    {
        isPauseMenu = set;
    }
    void SetPause(bool set)
    {
        mPaused = set;
    }

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
    }

    void Pause()
    {
        SetPause(true);
        Debug.Log("�|�[�Y����YO");
        Pause_Canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        SetIsPauseMenu(true);
        StartCoroutine(PauseStart());
    }

    IEnumerator PauseStart()
    {
        Debug.Log("�|�[�Y��");
        StartCoroutine(PauseMenu());
        yield return new WaitUntil(() => Input.GetKeyDown(pauseKey) && mPauseCooldown >= pauseCoolTime);

        Debug.Log("�|�[�Y����");
        StopCoroutine(PauseMenu());
        SetPause(false);
        Pause_Canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        
    }
    IEnumerator PauseMenu()
    {
        while (true)
        {
            if (isPauseMenu)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Debug.Log("��");
                    SelectCount--;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Debug.Log("��");
                    SelectCount++;
                }
                if (SelectCount > 2) SelectCount = 0;   // ��ɂ���
                if (SelectCount < 0) SelectCount = 2;   // ���ɍs��
            }

            switch(SelectCount)
            {
                case (int)SelectCorsor.Option:
                    Option.color = nowSelectColor;
                    Retry.color = Color.blue;
                    StageSelect.color = Color.blue;
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        animator_Pause.SetBool(UI_anim_paramator, true);
                        SetIsPauseMenu(false);
                        StartCoroutine(C_Option());
                        //StopCoroutine(CoolDown());
                        //StopCoroutine(PauseMenu());
                    }
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
            // �|�[�Y���j���[�֖߂�
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(PauseMenu());
                StartCoroutine(CoolDown());
                animator_Pause.SetBool(UI_anim_paramator, false);
                SetIsPauseMenu(true);
                StopCoroutine(C_Option());
            }
            yield return null;
        }
    }
}
