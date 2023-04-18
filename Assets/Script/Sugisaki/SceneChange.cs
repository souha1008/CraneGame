using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string sceneName = "Test1";

    [SerializeField] GameObject trasnsitionObject;

    readonly float waitTime = 0.5f;

    public bool isFade;

    // Start is called before the first frame update
    void Start()
    {
        isFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(nameof(LoadScene));
        }
    }

    IEnumerator LoadScene()
    {
        Instantiate(trasnsitionObject);

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneName);
    }
}
