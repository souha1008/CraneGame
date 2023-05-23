using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SOUND_STRUCT
{
    [SerializeField] string name;
    [SerializeField] AudioClip audioclip;
};

public class SoundManager : MonoBehaviour
{
    public SoundManager instance;
    [SerializeField] AudioSource audioSource;

    [SerializeField] SOUND_STRUCT[] bgm_s;

    [SerializeField] AudioClip[] BGM_Clip;
    [SerializeField] AudioClip[] SE_Clip;

    [SerializeField] static AudioClip[] audioClips;

    [SerializeField]
    Dictionary<string, int> keyBGM = new Dictionary<string, int>
    {
        {"�^�C�g��BGM", 0},
        {"�X�e�[�W�Z���N�g", 1},
        {"���U���gBGM", 2 },
        {"�Q�[���{��BGM_1", 3 },
        {"�Q�[���{��BGM_2", 4 },
        {"�Q�[���{��BGM_3", 5 },
        {"�Q�[���{��BGM_4", 6 },
    };

    Dictionary<string, int> keySE = new Dictionary<string, int>
    {
        {"�v���X�G�j�[SE", 0},
        {"����SE", 1},
        {"�I��SE", 2 },
        {"���ʒ���SE", 3 },
        {"�߂�SE", 4 },
        {"�X�e�[�W����SE", 5 },
        {"�G���f�B���OSE", 6 },
        {"�|�[�Y�J��SE", 7 },
        {"�|�[�Y����SE", 8 },
        {"�A�[���O�㍶�E�ړ�SE", 9 },
        {"�A�[���㉺�ړ�SE", 10 },
        {"�A�^�b�`�����g�ύXSE", 11 },
        {"��ˏoSE", 12 },
        {"�n���}�[��U��SE", 13 },
        {"�o�[�i�[����SE", 14 },
        {"��������ׂ�SE", 15 },
        {"������SE", 16 },
        {"�n���}�[��U��SE", 17 },
        {"�o�[�i�[����SE", 18 },
        {"SE", 20 },
    };

    
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BGMPlay(string playTitle)
    {
        audioSource.clip = BGM_Clip[keyBGM[playTitle]];

        audioSource.Play();
    }
    public void BGMPlay(string playTitle, bool isloop)
    {
        audioSource.clip = BGM_Clip[keyBGM[playTitle]];
        audioSource.loop = isloop;

        audioSource.Play();
    }
    public void BGMPlay(string playTitle, bool isloop, float volume)
    {
        audioSource.clip = BGM_Clip[keyBGM[playTitle]];
        audioSource.loop = isloop;
        audioSource.volume = volume;

        audioSource.Play();
    }

    public void SEPlay(string playTitle)
    {
        audioSource.PlayOneShot(SE_Clip[keySE[playTitle]]);
    }
}
