using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial2_Controll : MonoBehaviour
{
    [SerializeField] GameObject Tutorial_Canvas;
    [SerializeField, ReadOnly] public static bool TutorialEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TutorialEnabled)
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && TutorialEnabled)
        {
            TutorialEnabled = false;
            SoundManager.instance.SEPlay("Œˆ’èSE");
            Time.timeScale = 1;
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space) && TutorialEnabled)
        {
            TutorialEnabled = false;
            SoundManager.instance.SEPlay("Œˆ’èSE");
            Time.timeScale = 1;
        }
#endif

        Tutorial_Canvas.gameObject.SetActive(TutorialEnabled);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PauseTest");
        }
    }
}
