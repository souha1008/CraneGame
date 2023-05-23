using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial_Controll : MonoBehaviour
{
    [SerializeField] GameObject Tutorial_Canvas;
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Tutorial_Canvas.gameObject.SetActive(false);
            Time.fixedDeltaTime = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tutorial_Canvas.gameObject.SetActive(false);
            Time.fixedDeltaTime = 1;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PauseTest");
        }
    }
}
