using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieManager : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private RectTransform image;

    [SerializeField]
    private int waittime = 10;

    bool wait = false;

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
        else if (image.anchoredPosition.y <= 0)
        {
            wait = true;
            StartCoroutine(Wait());
        }
    }

    private void SceneChange()
    {
        camera.gameObject.name = new string("Main Camera");
        GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("TitleTest");
        this.enabled = false;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(waittime);

        SceneChange();

        yield break;
    }
}
