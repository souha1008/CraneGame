using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    private Image logo;

    private float param = 0;

    [SerializeField]
    private float waittime = 1;

    private bool skip = false;

    [SerializeField]
    private int logowaitframe = 60;

    void Awake()
    {
        logo = gameObject.GetComponent<Image>();
        logo.color = Co.Const.CLEAR;
    }

    void Start()
    {
        StartCoroutine(Fade());
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            skip = true;
        }
    }

    private IEnumerator Fade()
    {
        var wait = new WaitForSecondsRealtime(0.016f);

        while(true)
        {
            logo.color = Color.Lerp(Co.Const.CLEAR, Color.white, param);
            param += 0.016f;

            if (logo.color.a >= 1)
                break;
            else
                if (!skip) yield return wait;
        }
        
        if (!skip)wait.Reset();

        int cnt = 0;
        while(true)
        {
            if ((++cnt) >= logowaitframe)
                break;
            else
                if (!skip) yield return wait;
        }

        if (!skip)wait.Reset();

        while(true)
        {
            logo.color = Color.Lerp(Co.Const.CLEAR, Color.white, param);
            param -= 0.016f;

            if (logo.color.a <= 0)
                break;
            else
                if (!skip) yield return wait;
        }

        logo.color = new Color(1f, 1f, 1f, 0f);

        SceneManager.LoadScene("kurentei_cut_02");
        yield break;
    }
}
