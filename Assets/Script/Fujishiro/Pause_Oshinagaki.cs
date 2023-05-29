using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
struct Oshinagaki_Icon
{
    public bool isUse;
    public Image Icon;
}


public class Pause_Oshinagaki : MonoBehaviour
{
    [SerializeField] Oshinagaki_Icon[] oshinagaki_Icon;

    [Header("使わないときの色")]
    [SerializeField] Color notUseColor = Color.gray;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < oshinagaki_Icon.Length; i++)
        {
            // 使わないなら色をつけない
            if(oshinagaki_Icon[i].isUse == false)
            {
                oshinagaki_Icon[i].Icon.color = notUseColor;
            }
            else
            {
                oshinagaki_Icon[i].Icon.color = Color.white;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (GetComponent<PauseCoroutine>().GetIsPauseMenu() == true)
        {
            for (int i = 0; i < oshinagaki_Icon.Length; i++)
            {
                // 使わないなら色をつけない
                if (oshinagaki_Icon[i].isUse == false)
                {
                    oshinagaki_Icon[i].Icon.color = notUseColor;
                }
                else
                {
                    oshinagaki_Icon[i].Icon.color = Color.white;
                }
            }
        }
    }
}
