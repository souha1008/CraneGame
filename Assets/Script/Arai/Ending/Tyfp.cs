using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Tyfp : MonoBehaviour
{
    private Image tyfp;

    private Color zero = new Color(1, 1, 1, 0);

    private float param = 0;

    [SerializeField]
    private float waittime = 1;

    private bool sta = false;
    private bool fin = false;

    private ReadIsFade fade;

    void Start()
    {
        tyfp = gameObject.GetComponent<Image>();
        fade = GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>();
    }

    void Update()
    {
        if (!sta && !fade.GetIsFade())
        {
            sta = true;
            StartCoroutine(Fade());
        }
        if (fin && Input.anyKeyDown)
        {
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("StageSelect");
        }
    }

    private IEnumerator Fade()
    {
        var wait = new WaitForEndOfFrame();

        while(true)
        {
            tyfp.color = Color.Lerp(zero, Color.white, param);
            param += 0.0016f;

            if (tyfp.color.a >= 1)
                break;
            else
                yield return wait;
        }

        fin = true;
        yield break;
    }
}
