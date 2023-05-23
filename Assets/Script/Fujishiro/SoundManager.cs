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
        {"タイトルBGM", 0},
        {"ステージセレクト", 1},
        {"リザルトBGM", 2 },
        {"ゲーム本編BGM_1", 3 },
        {"ゲーム本編BGM_2", 4 },
        {"ゲーム本編BGM_3", 5 },
        {"ゲーム本編BGM_4", 6 },
    };

    Dictionary<string, int> keySE = new Dictionary<string, int>
    {
        {"プレスエニーSE", 0},
        {"決定SE", 1},
        {"選択SE", 2 },
        {"音量調整SE", 3 },
        {"戻るSE", 4 },
        {"ステージ決定SE", 5 },
        {"エンディングSE", 6 },
        {"ポーズ開くSE", 7 },
        {"ポーズ閉じるSE", 8 },
        {"アーム前後左右移動SE", 9 },
        {"アーム上下移動SE", 10 },
        {"アタッチメント変更SE", 11 },
        {"包丁射出SE", 12 },
        {"ハンマー空振りSE", 13 },
        {"バーナー噴射SE", 14 },
        {"おもちゃ潰しSE", 15 },
        {"卵落下SE", 16 },
        {"ハンマー空振りSE", 17 },
        {"バーナー噴射SE", 18 },
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
