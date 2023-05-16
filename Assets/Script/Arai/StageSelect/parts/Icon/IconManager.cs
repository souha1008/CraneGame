using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    [SerializeField]
    private StageIcon icon;
    
    private List<StageIcon> icons = new List<StageIcon>();

    private int worldIndex = 0;
    private int stageIndex = 0;

    [SerializeField, Range(0, 5)]
    private int stageIndexLimit = 0;

    [SerializeField]
    private Vector2 offset;

    private const int XNUM = 3;

    private bool active = false;

    void Update()
    {
        if (!active) return;

        if (/*Input.GetButtonDown("Submit")*/ Input.GetMouseButton(0))
        {
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("ResultTest");
            return;
        }

        // 下入力
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveCursor(XNUM);
        }
        // 上入力
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveCursor(-XNUM);
        }
        // 右入力
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveCursor(1);
        }
        // 左入力
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveCursor(-1);
        }
    }

    /// <summary>
    /// アイコン生成
    /// </summary>
    /// <param name="_worldindex">ワールド番号</param>
    public void CreateIcons(int _worldindex)
    {
        worldIndex = _worldindex;
        
        for(int i = 0; i < Co.Const.STAGE_NUM; ++i)
        {
            var obj = Instantiate(icon);
            obj.transform.SetParent(transform, false);
            obj.GetComponent<RectTransform>().anchoredPosition
             = new Vector2(offset.x * (int)(i % XNUM - 1) , -offset.y * (int)(i / XNUM));

            icons.Add(obj);
            obj.Inactivate();

//            obj.GetComponent<StageIcon>().SetParam(worldIndex, i, true);
        }
    }

    /// <summary>
    /// 活性化
    /// </summary>
    public void Activate()
    {
        stageIndex = 0;
        active = true;
        icons[stageIndex].Activate();
    }

    /// <summary>
    /// 非活性化
    /// </summary>
    public void Inactivate()
    {
        icons[stageIndex].Inactivate();
        active = false;
    }

    /// <summary>
    /// カーソル移動
    /// </summary>
    /// <param name="_indexvol">移動量</param>
    private void MoveCursor(int _indexvol)
    {
        // 範囲外ブロック
        if (stageIndex + _indexvol < 0 || stageIndex + _indexvol > stageIndexLimit)
         return;

        icons[stageIndex].Inactivate();
        stageIndex += _indexvol;
        icons[stageIndex].Activate();
    }
}
