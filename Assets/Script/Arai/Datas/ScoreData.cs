using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    [SerializeField]
    private float[] Score = new float[Co.Const.FAZE_NUM];

    private static ScoreData datas;

    void Awake()
    {
        if (!datas)
        {
            datas = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// スコアセット
    /// </summary>
    /// <param name="_index">フェーズ数</param>
    /// <param name="_score">スコア値</param>
    public void SetScore(int _index, float _score)
    {
        Score[_index] = _score;
    }

    /// <summary>
    /// スコア取得
    /// </summary>
    /// <param name="_index">フェーズ数</param>
    /// <returns>スコア値</returns>
    public float GetScore(int _index)
    {
        return Score[_index];
    }

    /// <summary>
    /// 合計スコア取得
    /// </summary>
    /// <returns>スコア値</returns>
    public float GetAddScore()
    {
        float score = 0;

        foreach(var value in Score)
        {
            score += value;
        }

        return score;
    }
}
