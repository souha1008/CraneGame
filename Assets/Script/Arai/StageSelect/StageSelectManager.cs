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
    private Sprite bgflame;
    
    [SerializeField, Header("UI")]
    private Image worldText;

    [SerializeField]
    private Image moveL;

    [SerializeField]
    private Image moveR;

    private List<Image> UIs = new List<Image>();

    [SerializeField, Header("Manager")]
    private WorldManager worldManager;
    private WorldManager manager;

    [SerializeField]
    private IconManager iconManager;

    private int worldIndex = 0;
    private int stageIndex = 0;

    private bool active = true;

    void Start()
    {
        CreateSelectWorld(Vector2.zero);
        CreateUI();
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
                Inactivate();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (worldIndex > 0)
            {
                --worldIndex;
                CreateSelectWorld(new Vector2(-1920, 0));
                Inactivate();
            }
        }
    }

    private void CreateSelectWorld(Vector2 pos)
    {
        // 管理者
        var obj = Instantiate(worldManager, canvas.transform);
        obj.GetComponent<RectTransform>().anchoredPosition = pos;
        obj.Parent = this;
        obj.transform.SetAsFirstSibling();

        // 背景
        var bgobj = Instantiate(bgbase, obj.transform);
        bgobj.sprite = bg[worldIndex];
        var flame = Instantiate(bgbase, obj.transform);
        flame.name = "flame";
        flame.sprite = bgflame;

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

    private void CreateUI()
    {
        worldText   = Instantiate(worldText, canvas.transform);
        moveL       = Instantiate(moveL, canvas.transform);
        moveR       = Instantiate(moveR, canvas.transform);

        UIActive(false);
        UIActive(true);
    }

    private void UIActive(bool _active)
    {
        worldText.gameObject.SetActive(_active);

        if (!_active || (_active && worldIndex != 0))
            moveL.gameObject.SetActive(_active);
            
        if (!_active || (_active && worldIndex != Co.Const.WORLD_NUM - 1))
            moveR.gameObject.SetActive(_active);
    }

    public void Activate()
    {
        UIActive(active = true);
    }
    public void Inactivate()
    {
        UIActive(active = false);
    }
}
