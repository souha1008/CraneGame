using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Content;
using UnityEngine.Rendering;

public class PauseCoroutine : MonoBehaviour
{
    // マクロ定数
    const int M_MAXSELECT = 3;
    const int M_MINSELECT = 0;

    [SerializeField, ReadOnly] public bool mPaused = false;
    [SerializeField, ReadOnly] private float mPauseCooldown;

    [SerializeField][Tooltip("ポーズのクールタイム")] float pauseCoolTime;

    [SerializeField][Tooltip("押したらポーズするボタン")] KeyCode pauseKey = KeyCode.P;
    [SerializeField][Tooltip("押したら決定する")] KeyCode KetteiKey = KeyCode.Space;
    [SerializeField][Tooltip("押したらキャンセル")] KeyCode BackKey = KeyCode.Z;
    [SerializeField] [Tooltip("下キー")] KeyCode DownArrow = KeyCode.DownArrow;
    [SerializeField] [Tooltip("下キー")] KeyCode UpArrow = KeyCode.UpArrow;

    [SerializeField][Tooltip("選択中の色")] Color nowSelectColor = new Color(0, 255, 255);
    [SerializeField][Tooltip("選択してない色")] Color notSelectColor = Color.white;

    [Header("UI系")]
    [SerializeField] Canvas Pause_Canvas = null;
    [SerializeField] Image Option;
    [SerializeField] Image Retry;
    [SerializeField] Image StageSelect;
    [SerializeField] Image Oshinagaki;

    [SerializeField, ReadOnly] int MenuSelectCount = 0;
    [SerializeField, ReadOnly] int OptionSelectCount = 0;

    [SerializeField] Animator animator_Pause;
    [SerializeField] Animator animator_Oshinagaki;
    [SerializeField] Animator animator_Option_c;
    [SerializeField] string UI_anim_paramator;
    [SerializeField] string Oshinagaki_anim_paramator;

    [Header("オプション内スライダー")]
    [SerializeField] GameObject Option_C;
    [SerializeField] Image TI_BGM;
    [SerializeField] Image TI_SE;
    [SerializeField] Slider BGM_Slider;
    [SerializeField] Slider SE_Slider;
    [SerializeField] float slider_rate = 0.1f;
    [SerializeField] float slider_coolfrate = 35;
    private float slider_nowcoolframe;

    [Header("コルーチン用変数")]
    [SerializeField] float C_Option_WaitTime = 1.5f;
    [SerializeField] float C_Option_WaitFrame = 180;
    [SerializeField] float UpdateModeChange_WaitTime = 5;

    [Header("おしながきステップ")]
    public Oshinagaki_Icon[] use_Icon;
    public int nowSelect = 0;
    public int usecount = 0;

    [SerializeField] bool DEBUG;

    public static PauseCoroutine instance { get; private set; } = new PauseCoroutine();
    public bool Update_isPause;

    // プライベート変数
    private bool isPauseMenu = false;
    private bool isOption_c = false;
    private float prevAxis = 0;
    private Coroutine counddown_corutine;

    enum SelectCorsor
    {
        Option = 0,
        Retry = 1,
        StageSelect = 2,
        Oshinagaki = 3,
    };

    void SetIsPauseMenu(bool set)
    {
        isPauseMenu = set;
    }

    public bool GetIsPauseMenu()
    {
        return isPauseMenu;
    }

    void SetPause(bool set)
    {
        mPaused = set;
    }
    void SetIsOption_c(bool set)
    {
        isOption_c = set;
    }

    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        BGM_Slider.value = SoundManager.instance.BGM_Volume;
        SE_Slider.value = SoundManager.instance.SE_Volume;
        Pause_Canvas.gameObject.SetActive(false);
        counddown_corutine = StartCoroutine(CoolDown());

        for (int i = 0, j = 0; i < Pause_Oshinagaki.instance.oshinagaki_Icon.Length; i++)
        {
            if (Pause_Oshinagaki.instance.oshinagaki_Icon[i].isUse == true)
            {
                use_Icon[j] = Pause_Oshinagaki.instance.oshinagaki_Icon[i];
                GameObject pa = use_Icon[j].Step;
                Image[] com = pa.GetComponentsInChildren<Image>();
                foreach (Image component in com)
                {
                    component.color = new Color(1, 1, 1, 0);
                }
                j++;
            }
        }
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void Update()
    {
        if (!DEBUG)
        {
            if (Input.GetKeyDown(pauseKey) && mPauseCooldown <= 0.0f && mPaused == false && ReadIsFade.instance.GetIsFade() == false)
            {
                Pause();
            }
        }
        else
        {
            if (Input.GetKeyDown(pauseKey) && mPauseCooldown <= 0.0f && mPaused == false)
            {
                Pause();
            }
        }

    }
    private void OnDestroy()
    {
        StopAllCoroutines();
        counddown_corutine = null;
    }

    private void LateUpdate()
    {
        if (isPauseMenu == true)
        {
            switch (MenuSelectCount)
            {
                case (int)SelectCorsor.Option:
                    Option.color = nowSelectColor;
                    Retry.color = notSelectColor;
                    StageSelect.color = notSelectColor;
                    Oshinagaki.color = notSelectColor;
                    break;

                case (int)SelectCorsor.Retry:
                    Option.color = notSelectColor;
                    Retry.color = nowSelectColor;
                    StageSelect.color = notSelectColor;
                    Oshinagaki.color = notSelectColor;
                    break;

                case (int)SelectCorsor.StageSelect:
                    Option.color = notSelectColor;
                    Retry.color = notSelectColor;
                    StageSelect.color = nowSelectColor;
                    Oshinagaki.color = notSelectColor;
                    break;

                case (int)SelectCorsor.Oshinagaki:
                    Option.color = notSelectColor;
                    Retry.color = notSelectColor;
                    StageSelect.color = notSelectColor;
                    Oshinagaki.color = nowSelectColor;
                    break;
            }
        }

        if(isOption_c == true)
        {
            switch (OptionSelectCount)
            {
                case 0:
                    TI_BGM.color = nowSelectColor;
                    TI_SE.color = notSelectColor;
                    break;

                case 1:
                    TI_BGM.color = notSelectColor;
                    TI_SE.color = nowSelectColor;
                    break;
            }
        }
    }

    void Pause()
    {
        if(GameObject.Find("SoundManager")) SoundManager.instance.SEPlay("ポーズ開くSE");
        // プライベート変数初期化
        prevAxis = 0;
        MenuSelectCount = 0;

        // 音声ストップ
        if (GameObject.Find("SoundManager")) SoundManager.instance.SELoopStop();

        SetPause(true);
        Update_isPause = true;
        Debug.Log("ポーズしたYO");
        Pause_Canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        SetIsPauseMenu(true);
        StartCoroutine(PauseStart());
    }

    void AnimSetBool(string anim_param, bool set)
    {
        animator_Pause.SetBool(anim_param, set);
        animator_Oshinagaki.SetBool(anim_param, set);
        animator_Option_c.SetBool(anim_param, set);
    }

    void OshinagakiAnimSetBool(string anim_param, bool set)
    {
        animator_Oshinagaki.SetBool(anim_param, set);
        use_Icon[nowSelect].animator.SetBool(anim_param, set);
        //for (int i = 0; i < use_Icon.Length; i++)
        //{
        //    GameObject pa = use_Icon[i].Step;
        //    Image[] com = pa.GetComponentsInChildren<Image>();
        //    foreach (Image component in com)
        //    { 
        //        component.color = new Color(1, 1, 1, 255);
        //    }
        //}
    }

    IEnumerator PauseStart()
    {
        Debug.Log("ポーズ中");
        StartCoroutine(PauseMenu());
        yield return new WaitUntil(() => Input.GetKeyDown(BackKey) && isPauseMenu == true && mPauseCooldown >= pauseCoolTime);

        Debug.Log("ポーズ解除");
        MenuSelectCount = 0;
        StopCoroutine(PauseMenu());
        SetPause(false);
        if (GameObject.Find("SoundManager")) SoundManager.instance.SEPlay("ポーズ閉じるSE");
        Update_isPause = false;
        Pause_Canvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        yield break;
        
    }
    IEnumerator PauseMenu()
    {
        while (true)
        {
            if (isPauseMenu)
            {
                if (Input.GetKeyDown(UpArrow) || (Input.GetAxis("Vertical") > 0.3f && prevAxis == 0))
                {
                    Debug.Log("上");
                    MenuSelectCount--;
                    prevAxis = Input.GetAxis("Vertical");
                    if (GameObject.Find("SoundManager"))
                        SoundManager.instance.SEPlay("選択SE");
                }

                if (Input.GetKeyDown(DownArrow) || (Input.GetAxis("Vertical") < -0.3f && prevAxis == 0))
                {
                    Debug.Log("下");
                    MenuSelectCount++;
                    prevAxis = Input.GetAxis("Vertical");
                    if (GameObject.Find("SoundManager"))
                        SoundManager.instance.SEPlay("選択SE");
                }

                if (MenuSelectCount > M_MAXSELECT) MenuSelectCount = M_MINSELECT;   // 上にいく
                if (MenuSelectCount < M_MINSELECT) MenuSelectCount = M_MAXSELECT;   // 下に行く

                // 入力無し
                if (Input.GetAxis("Vertical") == 0)
                {
                    prevAxis = 0;
                }


                if(Input.GetKeyDown(BackKey)) yield break;

                switch (MenuSelectCount)
                {
                    case (int)SelectCorsor.Oshinagaki:
                        // おしながきを選択
                        if (Input.GetKeyDown(KetteiKey))
                        {
                            if (GameObject.Find("SoundManager"))
                                SoundManager.instance.SEPlay("決定SE");

                            use_Icon[nowSelect].Step.SetActive(true);
                            OshinagakiAnimSetBool(Oshinagaki_anim_paramator, true);
                            SetIsPauseMenu(false);
                            StartCoroutine(C_Oshinagaki());
                        }

                        break;

                    case (int)SelectCorsor.Option:
                        // オプションを選択
                        if (Input.GetKeyDown(KetteiKey))
                        {
                            //StartCoroutine(Animator_UpdateModeChange(AnimatorUpdateMode.UnscaledTime));
                            if (GameObject.Find("SoundManager"))
                                SoundManager.instance.SEPlay("決定SE");
                            AnimSetBool(UI_anim_paramator, true);
                            SetIsPauseMenu(false);
                            StartCoroutine(C_Option());
                        }
                        break;

                    case (int)SelectCorsor.Retry:
                        // リトライを選択した時の処理を書く
                        if (Input.GetKeyDown(KetteiKey))
                        {
                            Time.timeScale = 1.0f;
                            SoundManager.instance.SEPlay("決定SE");
                            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(SceneManager.GetActiveScene().name);
                            yield return new WaitForSecondsRealtime(3);
                            yield break;
                        }
                        break;

                    case (int)SelectCorsor.StageSelect:
                        // ステージセレクトを選択した時の処理を書く
                        if (Input.GetKeyDown(KetteiKey))
                        {
                            Time.timeScale = 1.0f;
                            SoundManager.instance.SEPlay("決定SE");
                            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("StageSelect");
                            yield break;
                        }
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

    IEnumerator C_Option()
    {
        yield return new WaitForSecondsRealtime(C_Option_WaitTime);

        Slider nowslider = BGM_Slider;
        SetIsOption_c(true);

        while (true)
        {
            // 上
            if (Input.GetKeyDown(UpArrow) || (Input.GetAxis("Vertical") > 0.3f && prevAxis == 0))
            {
                SoundManager.instance.SEPlay("選択SE");
                OptionSelectCount--;
                prevAxis = Input.GetAxis("Vertical");
                if (OptionSelectCount < 0) OptionSelectCount = 1;
            }
            // 下
            if(Input.GetKeyDown(DownArrow) || (Input.GetAxis("Vertical") < -0.3f && prevAxis == 0))
            {
                SoundManager.instance.SEPlay("選択SE");
                OptionSelectCount++;
                prevAxis = Input.GetAxis("Vertical");
                if (OptionSelectCount > 1) OptionSelectCount = 0;
            }
            // 入力無し
            if (Input.GetAxis("Vertical") == 0)
            {
                prevAxis = 0;
            }

            switch (OptionSelectCount)
            {
                case 0:
                    nowslider = BGM_Slider;
                    break;

                case 1:
                    nowslider = SE_Slider;
                    break;
            }

            var value = Input.GetAxis("Horizontal");
            if(value > 0.3f && slider_nowcoolframe >= slider_coolfrate)
            {
                if (GameObject.Find("SoundManager"))
                    SoundManager.instance.SEPlay("音量調整SE");
                nowslider.value += slider_rate;

                if (nowslider == BGM_Slider)
                    SoundManager.instance.ChangeBGMVolume(nowslider.value);
                else
                    SoundManager.instance.ChangeSEVolume(nowslider.value);

                slider_nowcoolframe = 0;
            }
            if(value < -0.3f && slider_nowcoolframe >= slider_coolfrate)
            {
                if (GameObject.Find("SoundManager"))
                    SoundManager.instance.SEPlay("音量調整SE");
                nowslider.value -= slider_rate;

                if(nowslider == BGM_Slider)
                    SoundManager.instance.ChangeBGMVolume(nowslider.value);
                else
                    SoundManager.instance.ChangeSEVolume(nowslider.value);

                slider_nowcoolframe = 0;
            }
            slider_nowcoolframe += 1;

            // ポーズメニューへ戻る
            if (Input.GetKeyDown(BackKey))
            {
                AnimSetBool(UI_anim_paramator, false);
                SetIsOption_c(false);
                SoundManager.instance.SEPlay("戻るSE");
                yield return new WaitForSecondsRealtime(C_Option_WaitTime);
                SetIsPauseMenu(true);
                OptionSelectCount = 0;
                yield break;
            }


            yield return null;
        }
    }

    IEnumerator C_Oshinagaki()
    {
        nowSelect = 0;
        usecount = 0;
        for (int i = 0; i < use_Icon.Length; i++)
        {
            if (use_Icon[i].isUse == false)
            {
                break;
            }
            // アルファ値リセット
            GameObject pa = use_Icon[i].Step;
            Image[] com = pa.GetComponentsInChildren<Image>();
            foreach (Image component in com)
            {
                component.color = new Color(255, 255, 255, 255);
            }
            usecount++;
        }
        Debug.Log(usecount);
        GameObject parent = use_Icon[nowSelect].Step;
        Image[] components = parent.GetComponentsInChildren<Image>();
        //foreach (Image component in components) 
        //{
        //    component.color = new Color(1, 1, 1, 0);
        //}
        yield return new WaitForSecondsRealtime(1.3f);
        StartCoroutine(Alphakasan(parent));


        while (true)
        {

            // おしながき処理
            use_Icon[nowSelect].Step.SetActive(true);

            // 次へ行く
            if(Input.GetKeyDown(DownArrow))
            {
                use_Icon[nowSelect].Step.SetActive(false);
                nowSelect++;
                if (nowSelect > usecount - 1)
                {
                    nowSelect = 0;
                }
            }
            // 戻る
            if (Input.GetKeyDown(UpArrow))
            {
                use_Icon[nowSelect].Step.SetActive(false);
                nowSelect--;
                if (nowSelect < 0)
                {
                    nowSelect = usecount - 1;
                }
            }

            // ループ処理



            // ポーズメニューへ戻る
            if (Input.GetKeyDown(BackKey))
            {
                //StartCoroutine(Alphagensui(use_Icon[nowSelect].Step));
                OshinagakiAnimSetBool(Oshinagaki_anim_paramator, false);
                SoundManager.instance.SEPlay("戻るSE");
                yield return new WaitForSecondsRealtime(C_Option_WaitTime);
                use_Icon[nowSelect].Step.SetActive(false);
                SetIsPauseMenu(true);
                OptionSelectCount = 0;
                yield break;
            }
            yield return null;
        }
    }
    IEnumerator Alphagensui(GameObject parent)
    {
        Image[] components = parent.GetComponentsInChildren<Image>();

        Debug.Log(components.Length);
        while (true)
        {
            for(int i = 0; i < components.Length; i++) 
            {
                var inc = 0.1f;
                components[i].color -= new Color(0, 0, 0, inc); 
            }
            if (components[components.Length - 1].color.a < 0.0)
            {
                yield break;
            }
            yield return null;
        }
        
    }

    IEnumerator Alphakasan(GameObject parent)
    {
        Image[] components = parent.GetComponentsInChildren<Image>();

        while (true)
        {
            foreach (Image component in components)
            {
                var inc = 0.1f;
                component.color += new Color(0, 0, 0, inc);
                
                if (component.color.a > 1)
                {
                    yield break;
                }
            }
            yield return null;
        }
        
    }
}


