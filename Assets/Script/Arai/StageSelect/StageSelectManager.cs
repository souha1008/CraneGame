using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private StageSprite stageSprite;

    [SerializeField]
    private List<Sprite> bg;

    [SerializeField]
    private Image bgbase;

    [SerializeField]
    private StageSpriteManager ssManager;

    private StageSpriteManager nowManager;

    private int worldIndex = 0;
    private int stageIndex = 0;

    [SerializeField]
    private Vector2 pivotPos;
    [SerializeField]
    private float offsetX;

    private bool active = true;
    public bool Active
    {
        set => active = value;
    }

    void Start()
    {
        CreateSelectWorld(Vector2.zero);
        nowManager.Active = true;
    }

    void Update()
    {
        if (!active) return;

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (worldIndex+1 < Co.Const.WORLD_NUM)
            {
                nowManager.Active = false;
                CreateSelectWorld(new Vector2(1920, 0));
                ++worldIndex;
                active = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (worldIndex > 0)
            {
                nowManager.Active = false;
                CreateSelectWorld(new Vector2(-1920, 0));
                --worldIndex;
                active = false;
            }
        }
    }

    private void CreateSelectWorld(Vector2 pos)
    {
        // 画面生成
        //var bgobj = Instantiate(bg);

        var mng = Instantiate(ssManager);
        mng.transform.SetParent(canvas.transform, false);
        mng.GetComponent<RectTransform>().anchoredPosition = pos;
        mng.CreateButton();
        mng.Parent = this;


        if (nowManager)
        {
            nowManager.Inactivate(new Vector2(-pos.x, pos.y));
            mng.Activate();
        }
        else
            mng.Activate(true);

        nowManager = mng;
    }
}
