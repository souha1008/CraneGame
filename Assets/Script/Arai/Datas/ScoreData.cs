using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    private static ScoreData datas;

    [SerializeField]
    private float[] score = new float[Co.Const.FAZE_NUM];
    
    private float[] maxScore = new float[Co.Const.FAZE_NUM];

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
        score[_index] = _score;
    }

    /// <summary>
    /// スコア取得
    /// </summary>
    /// <param name="_index">フェーズ数</param>
    /// <returns>スコア値</returns>
    public float GetScore(int _index)
    {
        return score[_index];
    }

    /// <summary>
    /// 合計スコア取得
    /// </summary>
    /// <returns>スコア値</returns>
    public float GetAddScore()
    {
        float score = 0;

        foreach(var value in this.score)
        {
            score += value;
        }

        return score;
    }
}
