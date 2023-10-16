using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovieManager : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private RectTransform image;

    [SerializeField]
    private int waittime = 10;

    private bool wait = false;

    private bool once = false;

    private SoundManager manager;
    private float volume = 0;

    [SerializeField]
    Image skipimage;
    private bool showskip = false;

    void OnDestroy()
    {
        manager.BGM_Volume = volume;
    }

    void Start()
    {
        GameObject.FindAnyObjectByType<BGMPlayer>().BGMPlaying();

        manager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        skipimage.gameObject.SetActive(false);

        volume = manager.BGM_Volume;
        manager.BGM_Volume = 0;
        StartCoroutine(VolumFadeIn());
    }

    void Update()
    {
        if (!showskip && Input.anyKey)
        {
            skipimage.gameObject.SetActive(true);
            showskip = true;
        }
        else
        {
            if (Input.GetButton("Debug Multiplier"))
            {
                if(wait)
                {
                    StopCoroutine(Wait());
                    StopCoroutine(VolumFadeIn());
                    StopCoroutine(VolumFadeOut());
                }
    
                SceneChange();
            }
            else if (once && !wait && image.anchoredPosition.y <= 0)
            {
                wait = true;
                StartCoroutine(Wait());
                StartCoroutine(VolumFadeOut());
            }
            else once = true;
        }
    }

    private void SceneChange(bool _rerode = false)
    {
        if (_rerode)
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        }
        else
        {
            camera.gameObject.name = new string("Main Camera");
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("TitleTest");
            this.enabled = false;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(waittime);

        SceneChange(true);

        yield break;
    }

    private IEnumerator VolumFadeIn()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);

        float targetVol = volume;
        float val = volume / waittime;

        while(true)
        {
            manager.BGM_Volume += val;

            if (manager.BGM_Volume >= targetVol)
                yield break;
            else
                yield return wait;
        }
    }

    private IEnumerator VolumFadeOut()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(1);

        float targetVol = 0;
        float val = volume / waittime;

        while(true)
        {
            manager.BGM_Volume -= val;

            if (manager.BGM_Volume <= targetVol)
                yield break;
            else
                yield return wait;
        }
    }
}
