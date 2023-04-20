using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string sceneName = "Test1";
    [SerializeField] GameObject cameraObject;

    [SerializeField] GameObject FadeInObject;
    [SerializeField] GameObject FadeOutObject;

    readonly float waitTime = 1.0f;

    public float stopTime;

    public bool isFade;

    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        isFade = true;

        Vector3 position = cameraObject.transform.position;

        position.z = position.z + 1.0f;

        Instantiate(cameraObject);
        Instantiate(FadeOutObject, position, cameraObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time>waitTime)
        {
            isFade = false;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(nameof(LoadScene));

            time = 0.0f;
        }
    }


    IEnumerator LoadScene()
    {
        isFade = true;

        Vector3 position = cameraObject.transform.position;

        position.z = position.z + 1.0f;

        Instantiate(FadeInObject, position, cameraObject.transform.rotation);

        yield return new WaitForSeconds(waitTime);

        if (time > stopTime)
            SceneManager.LoadScene(sceneName);
    }
}
