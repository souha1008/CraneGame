using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
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

    private IconManager iconManager;
    public IconManager IconManager
    {
        set => iconManager = value;
    }

    [SerializeField]
    private float movePct = 0.01f;
    
    void Awake()
    {
        rtf = gameObject.GetComponent<RectTransform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Activate(bool first = false)
    {
        lastPos = rtf.anchoredPosition;
        
        if (!first) SlideIn();
        else
        {
            active = true;
            iconManager.Activate();
        }
    }

    public void Inactivate(Vector2 _pos)
    {
        iconManager.Inactivate();
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
            iconManager.Activate();
            parent.Activate();
        }
        else
        {
            param += movePct;
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
            param += movePct;
            Invoke("SlideOut", 0.01f);
        }
    }
}
