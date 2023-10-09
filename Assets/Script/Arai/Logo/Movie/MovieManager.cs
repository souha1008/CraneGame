using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Debug Multiplier"))
        {
            if(wait) StopCoroutine(Wait());
            SceneChange();
        }
        else if (once && image.anchoredPosition.y <= 0)
        {
            wait = true;
            StartCoroutine(Wait());
        }
        else once = true;
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
}
