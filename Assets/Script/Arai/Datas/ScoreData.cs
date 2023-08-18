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
    
    [SerializeField]
    private int[] maxScore = new int[Co.Const.FAZE_NUM];

    [SerializeField]
    private float clearBorder = 0.5f;
    public float ClearBorder
    {
        get => clearBorder;
        set => clearBorder = value;
    }

    [SerializeField]
    private bool speedClear = false;
    public bool SpeedClear
    {
        get => speedClear;
        set => speedClear = value;
    }

    [SerializeField]
    private ResultEnum.RESULT finalResult = ResultEnum.RESULT.MAX;
    public  ResultEnum.RESULT FinalResult
    {
        get => finalResult;
        set => finalResult = value;
    }

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
    /// 最大スコアセット
    /// </summary>
    /// <param name="_index">フェーズ数</param>
    /// <param name="_score">スコア値</param>
    public void SetMaxScore(int _index, int _score)
    {
        maxScore[_index] = _score;
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
    /// 合計スコア割合取得
    /// </summary>
    /// <returns>スコア値</returns>
    public float GetScoreParcent()
    {
        float score = 0, maxscore = 0;

        foreach(var value in this.score)
        {
            score += value;
        }
        foreach(var value in this.maxScore)
        {
            maxscore += value;
        }

        return score / maxscore;
    }

    /// <summary>
    /// ワールド・ステージ番号設定
    /// </summary>
    /// <param name="_world">ワールド番号</param>
    /// <param name="_stage">ステージ番号</param>
    public void SetIndexs(int _world, int _stage)
    {
        worldindex = _world;
        stageindex = _stage;

        ClearScores();
    }

    /// <summary>
    /// スコアリセット
    /// </summary>
    public void ClearScores()
    {
        for(int i = 0; i < Co.Const.FAZE_NUM; ++i)
        {
            score[i]    = 0;
            maxScore[i] = 0;
        }

        speedClear = false;
        finalResult = ResultEnum.RESULT.MAX;
    }

    public void SetBorder(float _value)
    {
        clearBorder = _value;

        GameObject.Find("Meter").GetComponent<PhaseMeter>().SetBorder(_value);
    }
}
