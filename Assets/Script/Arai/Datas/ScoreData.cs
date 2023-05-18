using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    private static ScoreData datas;

    [SerializeField]
    private int worldindex;
    public int WorldIndex
    {
        get => worldindex;
        set => worldindex = value;
    }

    [SerializeField]
    private int stageindex;
    public int StageIndex
    {
        get => stageindex;
        set => stageindex = value;
    }

    [SerializeField]
    private int[] score = new int[Co.Const.FAZE_NUM];
    
    private int[] maxScore = new int[Co.Const.FAZE_NUM];

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
    public void SetScore(int _index, int _score)
    {
        score[_index] = _score;
    }

    /// <summary>
    /// スコア取得
    /// </summary>
    /// <param name="_index">フェーズ数</param>
    /// <returns>スコア値</returns>
    public int GetScore(int _index)
    {
        return score[_index];
    }

    /// <summary>
    /// 合計スコア取得
    /// </summary>
    /// <returns>スコア値</returns>
    public int GetAddScore()
    {
        int score = 0;

        foreach(var value in this.score)
        {
            score += value;
        }

        return score;
    }
}
