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

    [SerializeField][Tooltip("�I�𒆂̐F")] Color nowSelectColor = new Color(0, 255, 255);

    [Header("UI�n")]
    [SerializeField] Canvas Pause_Canvas = null;
    [SerializeField] Image Option;
    [SerializeField] Image Retry;
    [SerializeField] Image StageSelect;

    [SerializeField, ReadOnly] int SelectCount = 0;

    [SerializeField] Animator animator_Pause;
    [SerializeField] Animator animator_Oshinagaki;
    [SerializeField] string UI_anim_paramator;

    [Header("�R���[�`���p�ϐ�")]
    [SerializeField] float C_Option_WaitTime = 1.5f;
    [SerializeField] float C_Option_WaitFrame = 180;
    [SerializeField] float UpdateModeChange_WaitTime = 5;

    [ReadOnly] public bool Update_isPause;

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
        if (Input.GetKeyDown(pauseKey) && mPauseCooldown <= 0.0f && mPaused == false)
        {
            Pause();
        }

    }

    private void LateUpdate()
    {
        if (isPauseMenu == true)
        {
            switch (SelectCount)
            {
                case (int)SelectCorsor.Option:
                    Option.color = nowSelectColor;
                    Retry.color = Color.blue;
                    StageSelect.color = Color.blue;

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
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z) && isPauseMenu == true && mPauseCooldown >= pauseCoolTime);

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


                switch (SelectCount)
                {
                    case (int)SelectCorsor.Option:
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            //StartCoroutine(Animator_UpdateModeChange(AnimatorUpdateMode.UnscaledTime));
                            animator_Pause.SetBool(UI_anim_paramator, true);
                            animator_Oshinagaki.SetBool(UI_anim_paramator, true);
                            SetIsPauseMenu(false);
                            StartCoroutine(C_Option());
                        }
                        break;

                    case (int)SelectCorsor.Retry:

                        break;

                    case (int)SelectCorsor.StageSelect:

                        break;
                }
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

    IEnumerator Animator_UpdateModeChange(AnimatorUpdateMode mode)
    {
        animator_Pause.updateMode = mode;

        yield return new WaitForSecondsRealtime(UpdateModeChange_WaitTime);
    }

    IEnumerator C_Option()
    {
        yield return new WaitForSecondsRealtime(C_Option_WaitTime);
        
        while (true)
        {
            // �|�[�Y���j���[�֖߂�
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator_Pause.SetBool(UI_anim_paramator, false);
                animator_Oshinagaki.SetBool(UI_anim_paramator, false);
                yield return new WaitForSecondsRealtime(C_Option_WaitTime);
                SetIsPauseMenu(true);
                //StartCoroutine(Animator_UpdateModeChange(AnimatorUpdateMode.AnimatePhysics));
                yield break;
            }
            yield return null;
        }
    }
}
