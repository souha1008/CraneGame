using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    private Image logo;

    private float param = 0;

    [SerializeField]
    private float waittime = 1;

    void Start()
    {
        logo = gameObject.GetComponent<Image>();
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        var wait = new WaitForEndOfFrame();

        while(true)
        {
            logo.color = Color.Lerp(Co.Const.CLEAR, Color.white, param);
            param += 0.0016f;

            if (logo.color.a >= 1)
                break;
            else
                yield return wait;
        }
        
        yield return new WaitForSeconds(waittime);

        GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("TitleTest");
        yield break;
    }
}
