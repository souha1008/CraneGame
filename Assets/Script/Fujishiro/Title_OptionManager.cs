using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_OptionManager : MonoBehaviour
{
    public static Title_OptionManager instance;
    [SerializeField][Tooltip("�������猈�肷��")] KeyCode KetteiKey = KeyCode.Joystick1Button1;
    [SerializeField][Tooltip("��������L�����Z��")] KeyCode BackKey = KeyCode.Joystick1Button0;
    [SerializeField][Tooltip("���L�[")] string DPAD_hori = "JuujiKeyY";

    [SerializeField] GameObject Option_Canvas;
    [SerializeField] Slider BGM_slider;
    [SerializeField] Slider SE_slider;
    [SerializeField] Image TI_BGM;
    [SerializeField] Image TI_SE;


    [SerializeField] Color nowSelectColor;
    [SerializeField] Color notSelectColor = Color.white;



    [SerializeField, ReadOnly] bool isOption = false;
    [SerializeField, ReadOnly] int OptionSelectCount = 0;

    [SerializeField] float slider_rate = 0.1f;
    [SerializeField] float slider_coolfrate = 35;


    private float prevAxis = 0;
    private float DPADAxis = 0;
    private float slider_nowcoolframe;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Option_Canvas.SetActive(false);

        GameObject.Find("Datas").GetComponent<SaveManager>().Load();
        BGM_slider.value = GameObject.Find("Datas").GetComponent<SaveManager>().data.bgmvolum; 
        SE_slider.value = GameObject.Find("Datas").GetComponent<SaveManager>().data.sevolum;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOption && Option_Canvas.activeSelf == false)
        {
            Time.timeScale = 0f;
            Option_Canvas.SetActive(true);
            if (GameObject.Find("SoundManager")) SoundManager.instance.SEPlay("ポーズ開くSE");
            StartCoroutine(C_Option());
        }
    }

    public void Call_Option()
    {
        isOption = true;
    }

    private void LateUpdate()
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

    IEnumerator C_Option()
    {
        Slider nowslider = BGM_slider;

        while(true)
        {
            if ((Input.GetAxis(DPAD_hori) > 0.8f && DPADAxis == 0) || (Input.GetAxis("Vertical") > 0.3f && prevAxis == 0))
            {
                OptionSelectCount--;
                prevAxis = Input.GetAxis("Vertical");
                DPADAxis = Input.GetAxis(DPAD_hori);
                if (GameObject.Find("SoundManager"))
                    SoundManager.instance.SEPlay("選択SE");
                if (OptionSelectCount < 0) OptionSelectCount = 1;
            }

            if ((Input.GetAxis(DPAD_hori) < -0.8f && DPADAxis == 0) || (Input.GetAxis("Vertical") < -0.3f && prevAxis == 0))
            {
                OptionSelectCount++;
                prevAxis = Input.GetAxis("Vertical");
                DPADAxis = Input.GetAxis(DPAD_hori);
                if (GameObject.Find("SoundManager"))
                    SoundManager.instance.SEPlay("選択SE");
                if (OptionSelectCount > 1) OptionSelectCount = 0;
            }

            // ���͖���
            if (Input.GetAxis("Vertical") == 0)
            {
                prevAxis = 0;
            }
            if(Input.GetAxis(DPAD_hori) == 0)
            {
                DPADAxis = 0;
            }

            // �I�v�V�����I���
            if (Input.GetKeyDown(BackKey))
            {
                Option_Canvas.SetActive(false);
                isOption = false;
                SoundManager.instance.SEPlay("戻るSE");
                OptionSelectCount = 0;
                Time.timeScale = 1;
                yield break;
            }

            // ���g���Ă���X���C�_�[�̑I��
            switch (OptionSelectCount)
            {
                case 0:
                    nowslider = BGM_slider;
                    break;

                case 1:
                    nowslider = SE_slider;
                    break;
            }

            if ((Input.GetAxis("JuujiKeyX") >= 0.8f || Input.GetAxis("Horizontal") > 0.3f) && slider_nowcoolframe >= slider_coolfrate)
            {
                if (GameObject.Find("SoundManager"))
                    SoundManager.instance.SEPlay("音量調整SE");
                nowslider.value += slider_rate;

                if (nowslider == BGM_slider)
                    SoundManager.instance.ChangeBGMVolume(nowslider.value);
                else
                    SoundManager.instance.ChangeSEVolume(nowslider.value);

                slider_nowcoolframe = 0;
            }
            if ((Input.GetAxis("JuujiKeyX") <= -0.8f || Input.GetAxis("Horizontal") < -0.3f) && slider_nowcoolframe >= slider_coolfrate)
            {
                if (GameObject.Find("SoundManager"))
                    SoundManager.instance.SEPlay("音量調整SE");
                nowslider.value -= slider_rate;

                if (nowslider == BGM_slider)
                    SoundManager.instance.ChangeBGMVolume(nowslider.value);
                else
                    SoundManager.instance.ChangeSEVolume(nowslider.value);

                slider_nowcoolframe = 0;
            }
            slider_nowcoolframe += 1;


            yield return null;
        }
    }
}
