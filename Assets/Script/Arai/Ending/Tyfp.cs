using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Tyfp : MonoBehaviour
{
    private Image tyfp;

    private float param = 0;

    [SerializeField]
    private float waittime = 1;

    private bool sta = false;
    private bool fin = false;

    private ReadIsFade fade;

    void Awake()
    {
        tyfp = gameObject.GetComponent<Image>();
        tyfp.color = Co.Const.CLEAR;
        fade = GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>();

        SoundManager.instance.BGMStop();
        SoundManager.instance.SEPlay("エンディング", true);
    }

    void Update()
    {
        if (!sta && !fade.GetIsFade())
        {
            sta = true;
            StartCoroutine(Fade());
        }
        if (fin && Input.GetKeyDown("joystick button 0"))
        {
            //下川原渓吾です。
            SoundManager.instance.SELoopStop();
            //下川原渓吾でした。
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("StageSelect");
        }
    }

    private IEnumerator Fade()
    {
        var wait = new WaitForSecondsRealtime(0.016f);

        while(true)
        {
            tyfp.color = Color.Lerp(Co.Const.CLEAR, Color.white, param);
            param += 0.016f;

            if (tyfp.color.a >= 1)
                break;
            else
                yield return wait;
        }

        fin = true;
        yield break;
    }
}
