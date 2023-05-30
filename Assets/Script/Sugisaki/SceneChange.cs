using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string sceneName;

    private GameObject FadeObject;

    [SerializeField] GameObject FadeInObject;

    [SerializeField] GameObject LastFadeObject;

    readonly float waitTime = 1.0f;

    private float Changewait;

    public bool isFade;
    // Start is called before the first frame update
    void Start()
    {
        FadeObject = FadeInObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (ReadIsFade.instance)
            isFade = ReadIsFade.instance.GetIsFade();

        //if (Input.GetKeyDown(KeyCode.Return) && !isFade)
        //{
        //    LoadScene(sceneName, 1);
        //}
    }

    public void LoadScene(string scene, int checkEnd = 0)
    {
        sceneName = scene;
        if (!isFade)
        {
            Changewait = checkEnd;

            if (Changewait == 1) 
            {
                FadeObject = LastFadeObject;
            }
            else
            {
                FadeObject = FadeInObject;
            }

            StartCoroutine(nameof(Load));
        }
    }

    IEnumerator Load()
    {
        ReadIsFade.instance.SetIsFade(true);

        GameObject cameraObject = GameObject.Find("Main Camera");

        Vector3 position = cameraObject.transform.position;
        Quaternion rotate = cameraObject.transform.rotation;

        position.y = position.y - 1.0f;
        position.z = position.z + 10.0f;
        rotate.y = rotate.y + 180.0f;
        Instantiate(FadeObject, position, rotate);

        yield return new WaitForSeconds(waitTime + Changewait);

        SceneManager.LoadScene(sceneName);
    }
}
