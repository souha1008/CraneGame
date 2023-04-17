using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneSelect : MonoBehaviour
{
    [SerializeField]
    private string SceneName;

    public void Next()
    {
        SceneManager.LoadScene(SceneName);
    }
}
