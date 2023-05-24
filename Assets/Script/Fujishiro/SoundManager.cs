using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct SOUND_STRUCT
{
    public string name;
    public AudioClip audioClip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource audioSource;

    [SerializeField] SOUND_STRUCT[] keyBGM;
    [SerializeField] SOUND_STRUCT[] keySE;


    // Start is called before the first frame update
    public void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BGMPlay(string playTitle)
    {   
        for(int i = 0; i < keyBGM.Length; i++)
        {
            if(playTitle == keyBGM[i].name)
            {
                audioSource.clip = keyBGM[i].audioClip;
                break;
            }
        }
        
        audioSource.Play();
    }
    public void BGMPlay(string playTitle, bool isloop)
    {
        for (int i = 0; i < keyBGM.Length; i++)
        {
            if (playTitle == keyBGM[i].name)
            {
                audioSource.clip = keyBGM[i].audioClip;
                break;
            }
        }
        audioSource.loop = isloop;

        audioSource.Play();
    }
    public void BGMPlay(string playTitle, bool isloop, float volume)
    {
        for (int i = 0; i < keyBGM.Length; i++)
        {
            if (playTitle == keyBGM[i].name)
            {
                audioSource.clip = keyBGM[i].audioClip;
                break;
            }
        }
        audioSource.loop = isloop;
        audioSource.volume = volume;

        audioSource.Play();
    }

    public void SEPlay(string playTitle)
    {
        for(int i = 0; i < keySE.Length; i++)
        {
            if (playTitle == keySE[i].name)
            {
                audioSource.PlayOneShot(keySE[i].audioClip);
                break;
            }
        }
    }

    public void SEPlay(string playTitle, float volume)
    {
        audioSource.volume = volume;
        for (int i = 0; i < keySE.Length; i++)
        {
            if (playTitle == keySE[i].name)
            {
                audioSource.PlayOneShot(keySE[i].audioClip);
                break;
            }
        }
    }
}
