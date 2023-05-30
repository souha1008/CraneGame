using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial1_Controll : MonoBehaviour
{
    [SerializeField] GameObject Tutorial_Canvas;
    [SerializeField] GameObject Sprite_Catcher;
    [SerializeField, ReadOnly]public static bool TutorialEnabled = true;

    private bool next;

    [SerializeField] GameObject Tutorial_image1;
    [SerializeField] GameObject Tutorial_image2;

    // Start is called before the first frame update
    void Start()
    {
        Tutorial_image1.SetActive(true);
        Tutorial_image2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("ReadIsFade"))
        {
            if (GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>().GetIsFade() == false && TutorialEnabled)
            {
                Time.timeScale = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.JoystickButton1) && TutorialEnabled && next == true)
        {
            TutorialEnabled = false;
            Time.timeScale = 1;
            this.gameObject.SetActive(TutorialEnabled);
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1) && TutorialEnabled && next == false)
        {
            // éüÇ…çsÇ≠
            next = true;
            Tutorial_image1.SetActive(false);
            Sprite_Catcher.gameObject.SetActive(false);
            Tutorial_image2.SetActive(true);
            SoundManager.instance.SEPlay("åàíËSE");

        }
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.Space) && TutorialEnabled && next == true)
        {
            TutorialEnabled = false;
            SoundManager.instance.SEPlay("åàíËSE");
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && TutorialEnabled && next == false)
        {
            // éüÇ…çsÇ≠
            next = true;
            Tutorial_image1.SetActive(false);
            Sprite_Catcher.gameObject.SetActive(false);
            Tutorial_image2.SetActive(true);
            SoundManager.instance.SEPlay("åàíËSE");

        }
#endif

        Tutorial_Canvas.gameObject.SetActive(TutorialEnabled);
        Sprite_Catcher.gameObject.SetActive(TutorialEnabled);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("PauseTest");
        }

        if (GameObject.Find("Tutorial"))
        {
            return;
        }
    }
}
