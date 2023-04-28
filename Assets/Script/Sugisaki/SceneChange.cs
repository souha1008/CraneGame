using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string sceneName;

    [SerializeField] GameObject FadeInObject;

    readonly float waitTime = 1.0f;

    public bool isFade;

    private float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > waitTime) 
        {
            isFade = false;
        }

        if (Input.GetKeyDown(KeyCode.Return) && !isFade)
        {
            LoadScene(sceneName);

            time = 0.0f;
        }
    }

    public void LoadScene(string scene)
    {
        StartCoroutine(nameof(scene));
    }

    IEnumerator Load()
    {
        isFade = true;

        GameObject cameraObject = GameObject.Find("Main Camera");

        Vector3 position = cameraObject.transform.position;
        Quaternion rotate = cameraObject.transform.rotation;

        position.z = position.z + 1.0f;
        Instantiate(FadeInObject, position, rotate);

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneName);
    }
}
