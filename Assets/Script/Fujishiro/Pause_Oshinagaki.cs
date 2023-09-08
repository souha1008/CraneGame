using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Oshinagaki_Icon
{
    public bool isUse;
    public Image Icon;
    public GameObject Step;
}


public class Pause_Oshinagaki : MonoBehaviour
{
    static public Pause_Oshinagaki instance;

    [SerializeField] public Oshinagaki_Icon[] oshinagaki_Icon;

    [Header("�g��Ȃ��Ƃ��̐F")]
    [SerializeField] Color notUseColor = Color.gray;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        for(int i = 0; i < oshinagaki_Icon.Length; i++)
        {
            // �g��Ȃ��Ȃ�F�����Ȃ�
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
                // �g��Ȃ��Ȃ�F�����Ȃ�
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
