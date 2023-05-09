using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpriteManager : MonoBehaviour
{
    [SerializeField]
    private StageSprite stageSprite;
    
    private List<StageSprite> sprites = new List<StageSprite>();

    private int stageIndex = 0;

    [SerializeField]
    private Vector2 pivotPos;
    [SerializeField]
    private float offsetX;

    private StageSelectManager parent;
    public StageSelectManager Parent
    {
        set => parent = value;
    }

    private bool active = false;
    public bool Active
    {
        get => active;
        set => active = value;
    }

    private RectTransform rtf;
    private float param = 0;
    private Vector2 lastPos;
    private Vector2 tgtPos;


    void Awake()
    {
        rtf = gameObject.GetComponent<RectTransform>();
    }

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
            var obj = Instantiate(stageSprite);
            obj.transform.SetParent(transform, false);
            obj.GetComponent<RectTransform>().anchoredPosition
             = new Vector2(pivotPos.x + offsetX * i , pivotPos.y);

             sprites.Add(obj);
             obj.Inactivate();
        }
    }

    public void Activate(bool first = false)
    {
        lastPos = rtf.anchoredPosition;
        
        if (!first) SlideIn();
        else
        {
            active = true;
            sprites[stageIndex].Activate();
        }
    }

    public void Inactivate(Vector2 _pos)
    {
        sprites[stageIndex].Inactivate();
        lastPos = rtf.anchoredPosition;
        active = false;
        tgtPos = _pos;
        SlideOut();
    }

    private void SlideIn()
    {
        rtf.anchoredPosition = Vector2.Lerp(lastPos, Vector2.zero, param);

        if (param >= 1)
        {
            param = 0;
            active = true;
            sprites[stageIndex].Activate();
            parent.Active = true;
        }
        else
        {
            param += 0.01f;
            Invoke("SlideIn", 0.01f);
        }
    }

    private void SlideOut()
    {
        rtf.anchoredPosition = Vector2.Lerp(lastPos, tgtPos, param);

        if (param >= 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            param += 0.01f;
            Invoke("SlideOut", 0.01f);
        }
    }
}
