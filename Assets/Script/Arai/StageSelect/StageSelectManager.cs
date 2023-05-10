using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private List<Sprite> bg;

    [SerializeField]
    private Image bgbase;

    [SerializeField]
    private WorldManager worldManager;
    private WorldManager manager;

    [SerializeField]
    private IconManager iconManager;

    private int worldIndex = 0;
    private int stageIndex = 0;

    private bool active = true;
    public bool Active
    {
        set => active = value;
    }

    void Start()
    {
        CreateSelectWorld(Vector2.zero);
        manager.Active = true;
    }

    void Update()
    {
        if (!active) return;

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (worldIndex+1 < Co.Const.WORLD_NUM)
            {
                ++worldIndex;
                CreateSelectWorld(new Vector2(1920, 0));
                active = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (worldIndex > 0)
            {
                --worldIndex;
                CreateSelectWorld(new Vector2(-1920, 0));
                active = false;
            }
        }
    }

    private void CreateSelectWorld(Vector2 pos)
    {
        var obj = Instantiate(worldManager, canvas.transform);
        obj.GetComponent<RectTransform>().anchoredPosition = pos;
        obj.Parent = this;

        // 画面生成
        // 背景
        var bgobj = Instantiate(bgbase, obj.transform);
        bgobj.sprite = bg[worldIndex];

        // アイコン
        var icon = Instantiate(iconManager, obj.transform);
        icon.CreateButton();

        obj.IconManager = icon;
        if (manager)
        {
            manager.Inactivate(new Vector2(-pos.x, pos.y));
            obj.Activate();
        }
        else
        {
            obj.Activate(true);
        }
        manager = obj;
    }
}
