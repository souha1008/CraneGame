using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    [SerializeField]
    private StageSprite icon;
    
    private List<StageSprite> sprites = new List<StageSprite>();

    private int stageIndex = 0;

    [SerializeField]
    private Vector2 pivotPos;
    [SerializeField]
    private float offsetX;

    private bool active = false;

    void Update()
    {
        if (!active) return;

        if (Input.GetKeyDown(KeyCode.RightArrow) && stageIndex+1 < Co.Const.STAGE_NUM)
        {
            sprites[stageIndex].Inactivate();
            ++stageIndex;
            sprites[stageIndex].Activate();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && stageIndex > 0)
        {
            sprites[stageIndex].Inactivate();
            --stageIndex;
            sprites[stageIndex].Activate();
        }
    }

    public void CreateButton()
    {
        for(int i = 0; i < Co.Const.STAGE_NUM; ++i)
        {
            var obj = Instantiate(icon);
            obj.transform.SetParent(transform, false);
            obj.GetComponent<RectTransform>().anchoredPosition
             = new Vector2(pivotPos.x + offsetX * i , pivotPos.y);

             sprites.Add(obj);
             obj.Inactivate();
        }
    }

    public void Activate()
    {
        active = true;
        sprites[stageIndex].Activate();
    }

    public void Inactivate()
    {
        sprites[stageIndex].Inactivate();
        active = false;
    }
}
