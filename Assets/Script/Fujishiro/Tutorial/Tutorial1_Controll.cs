using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial1_Controll : MonoBehaviour
{
    [SerializeField] GameObject Tutorial_Canvas;
    [SerializeField] GameObject Sprite_Catcher;
    [SerializeField, ReadOnly]public static bool TutorialEnabled = true;

    private bool si;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>().GetIsFade() == false && TutorialEnabled)
        {
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1) && TutorialEnabled)
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
        Sprite_Catcher.gameObject.SetActive(TutorialEnabled);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PauseTest");
        }
    }
}
