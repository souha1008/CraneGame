using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string sceneName;

    [SerializeField] GameObject FadeInObject;
    [SerializeField] GameObject readIsFade;

    readonly float waitTime = 1.0f;

    [SerializeField] float Changewait;

    public bool isFade;
    // Start is called before the first frame update
    void Start()
    {
        isFade = false;
        readIsFade.GetComponent<ReadIsFade>().SetIsFade(isFade);
    }

    // Update is called once per frame
    void Update()
    {
        isFade = readIsFade.GetComponent<ReadIsFade>().GetIsFade();

        if (Input.GetKeyDown(KeyCode.Return) && !isFade)
        {
            LoadScene(sceneName);
        }
    }

    public void LoadScene(string scene)
    {
        sceneName = scene;
        if (!isFade)
            StartCoroutine(nameof(Load));
    }

    IEnumerator Load()
    {
        isFade = true;
        readIsFade.GetComponent<ReadIsFade>().SetIsFade(isFade);

        GameObject cameraObject = GameObject.Find("Main Camera");

        Vector3 position = cameraObject.transform.position;
        Quaternion rotate = cameraObject.transform.rotation;

        position.y = position.y - 1.0f;
        position.z = position.z + 10.0f;
        rotate.y = rotate.y + 180.0f;
        Instantiate(FadeInObject, position, rotate);

        yield return new WaitForSeconds(waitTime+Changewait);

        SceneManager.LoadScene(sceneName);
    }
}
