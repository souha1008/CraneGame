using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

[System.Serializable]
public struct SOUND_STRUCT
{
    public string name;
    public AudioClip audioClip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource BGMaudioSource;
    [SerializeField] AudioSource SEaudioSource;
    [SerializeField] AudioSource SEloopAudioSource;

    public SOUND_STRUCT[] keyBGM;
    public SOUND_STRUCT[] keySE;

    [SerializeField, ReadOnly] float BGM_Volume = 1;
    [SerializeField, ReadOnly] float SE_Volume = 1;


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

        BGMaudioSource.volume = BGM_Volume;
        SEloopAudioSource.volume = SE_Volume;
        SEaudioSource.volume = SE_Volume;
    }

    // Update is called once per frame
    void Update()
    {
        BGMaudioSource.volume = BGM_Volume;
        SEloopAudioSource.volume = SE_Volume;
        SEaudioSource.volume = SE_Volume;
    }

    public void ChangeBGMVolume(float value)
    {
        BGM_Volume = value;
    }

    public void ChangeSEVolume(float value)
    {
        SE_Volume = value;
    }

    public bool CheckPlayBGM(string playTitle)
    {
        AudioClip searchClip = null;

        for(int i = 0; i < keyBGM.Length; i++)
        {
            if(playTitle == keyBGM[i].name)
            {
                searchClip = keyBGM[i].audioClip;

                if (searchClip == BGMaudioSource.clip)
                {
                    // �T�����N���b�v�ƍĐ����̃N���b�v�������Ȃ�true
                    return true;
                }

                break;
            }
        }

        // ����ȊO�Ȃ�false
        return false;
    }

    public void BGMPlay(string playTitle)
    {   
        for(int i = 0; i < keyBGM.Length; i++)
        {
            if(playTitle == keyBGM[i].name)
            {
                BGMaudioSource.clip = keyBGM[i].audioClip;
                break;
            }
        }
        BGMaudioSource.volume = BGM_Volume;
        BGMaudioSource.Play();
    }
    public void BGMPlay(string playTitle, bool isloop)
    {
        for (int i = 0; i < keyBGM.Length; i++)
        {
            if (playTitle == keyBGM[i].name)
            {
                BGMaudioSource.clip = keyBGM[i].audioClip;
                break;
            }
        }
        BGMaudioSource.loop = isloop;
        BGMaudioSource.volume = BGM_Volume;
        BGMaudioSource.Play();
    }

    public void SEPlay(string playTitle)
    {
        for(int i = 0; i < keySE.Length; i++)
        {
            if (playTitle == keySE[i].name)
            {
                SEaudioSource.volume = SE_Volume;
                SEaudioSource.PlayOneShot(keySE[i].audioClip);
                break;
            }
        }
    }

    public void SEPlay(string playTitle, bool loop)
    {
        for (int i = 0; i < keySE.Length; i++)
        {
            if (playTitle == keySE[i].name)
            {
                SEloopAudioSource.volume = SE_Volume;
                SEloopAudioSource.clip = keySE[i].audioClip;
                SEloopAudioSource.loop = loop;
                SEloopAudioSource.Play();
                
                break;
            }
        }
    }

    public void BGMStop()
    {
        BGMaudioSource.Stop();
    }

    public void SEStop()
    {
        SEaudioSource.Stop();
    }

    public void SELoopStop()
    {
        SEloopAudioSource.Stop();
    }
}
