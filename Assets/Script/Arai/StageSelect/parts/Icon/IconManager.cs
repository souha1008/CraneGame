using System.Collections;
using System.Collections.Generic;
using Co;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    [SerializeField]
    private StageIcon icon;
    
    private List<StageIcon> icons = new List<StageIcon>();

    private int worldIndex = 0;
    private int stageIndex = 0;

    [SerializeField, Range(0, 4)]
    private int stageIndexLimit = 0;

    [SerializeField]
    private Vector2 offset;

    /// <summary>
    /// アイコン生成
    /// </summary>
    /// <param name="_worldindex">ワールド番号</param>
    public void CreateIcons(int _worldindex, SaveManager _save)
    {
        worldIndex = _worldindex;

        // 選択可能範囲を変更
        if (worldIndex < _save.data.worldindex)
        {
            stageIndexLimit = Co.Const.STAGE_NUM - 1;
        }
        else if (worldIndex == _save.data.worldindex)
        {
            stageIndexLimit = _save.data.stageindex;
        }
        else
        {
            stageIndexLimit = 0;
        }

        for(int i = 0; i < Co.Const.STAGE_NUM; ++i)
        {
            var obj = Instantiate(icon);
            obj.transform.SetParent(transform, false);
            obj.GetComponent<RectTransform>().anchoredPosition
             = new Vector2(offset.x * (int)(i - 2) , 0);

            icons.Add(obj);
            obj.Inactivate();

            if (i <= stageIndexLimit)
            {
                obj.GetComponent<StageIcon>().SetParam(worldIndex, i, _save.data.data[worldIndex * Co.Const.STAGE_NUM + i]);
            }
            else
            {
                
                obj.GetComponent<StageIcon>().SetParam(worldIndex, i, -1);
            }
        }
    }

    /// <summary>
    /// 活性化
    /// </summary>
    public void Activate(int _stageindex = 0)
    {
        stageIndex = _stageindex;
        icons[stageIndex].Activate();
    }

    /// <summary>
    /// 非活性化
    /// </summary>
    public void Inactivate()
    {
        icons[stageIndex].Inactivate();
    }

    /// <summary>
    /// カーソル移動
    /// </summary>
    /// <param name="_indexvol">移動量</param>
    public bool MoveCursor(int _indexvol)
    {
        // 範囲外ブロック
        if (stageIndex + _indexvol < 0 || stageIndex + _indexvol > stageIndexLimit)
         return false;

        icons[stageIndex].Inactivate();
        stageIndex += _indexvol;
        icons[stageIndex].Activate();
        return true;
    }

    public void Pushed()
    {
        var dataobj = GameObject.Find("Datas");
        var data = dataobj.GetComponent<ScoreData>();
        data.SetIndexs(worldIndex, stageIndex);

        bool tut = false;
        for (int i = 0; i < Const.TUT_NUM; ++i)
        {
            if (Const.TUT_WORLD_NUM[i] == worldIndex &&
                Const.TUT_STAGE_NUM[i] == stageIndex &&
                stageIndexLimit == stageIndex)
                {
                    Debug.Log("First");
                    GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene(Const.TUT_STAGE_NAME[i]);
                    tut = true;
                }
        }
        
        if (!tut)
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene((worldIndex + 1) + "-" + (stageIndex + 1));

        SoundManager.instance.BGMStop();
        return;
    }
}
