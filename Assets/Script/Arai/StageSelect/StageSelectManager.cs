using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject empty;

    [SerializeField]
    private ss_background background;
    
    [SerializeField, Header("UI")]
    private List<StageSelectUI> uis = new List<StageSelectUI>();

    [SerializeField, Header("Icon")]
    private IconManager iconManager;
    private List<IconManager> iconManagers = new List<IconManager>();
    private GameObject imManager;

    [SerializeField]
    private float distanceX = 3840;

    [SerializeField, Range(0, 3)]
    private int worldIndexLimit = 0;
    private int worldIndex = 0;

    private bool active = true;

    void Start()
    {
        // 背景
        background = Instantiate(background, canvas.transform);
        background.SetBG(worldIndex);

        // UI
        var obj = Instantiate(empty, canvas.transform);
        obj.name = "UIs";

        for(int i = 0; i < uis.Count; ++i)
        {
            uis[i] = Instantiate(uis[i], obj.transform);
            uis[i].Activate(worldIndex);
        }

        // アイコン
        imManager = Instantiate(empty, canvas.transform); 
        imManager.name = "iconManagers";

        for (int i = 0; i < Co.Const.WORLD_NUM; ++i)
        {
            iconManagers.Add(Instantiate(iconManager, imManager.transform));
            iconManagers[i].GetComponent<RectTransform>().anchoredPosition
             = new Vector2(i * distanceX, 100);
            iconManagers[i].CreateIcons(i);
        }
        iconManagers[worldIndex].Activate();
    }

    void Update()
    {
        if (!active) return;

        if (Input.GetKeyDown(KeyCode.D) && worldIndex < worldIndexLimit)
        {
            Inactivate(1);
        }
        else if (Input.GetKeyDown(KeyCode.A) && worldIndex > 0)
        {
            Inactivate(-1);
        }
    }

    private void Activate()
    {
        foreach (var ui in uis)
        {
            ui.Activate(worldIndex);
        }

        iconManagers[worldIndex].Activate();
        active = true;
    }

    private void Inactivate(int _way)
    {
        foreach (var ui in uis)
        {
            ui.Inactivate();
        }

        iconManagers[worldIndex].Inactivate();

        worldIndex += _way;

        active = false;
        StartCoroutine(MoveIcons(_way));
    }

    private IEnumerator MoveIcons(int _way)
    {
        WaitForSeconds ws = new WaitForSeconds(0.001f);

        Vector2 defpos = imManager.transform.localPosition;
        Vector2 tgtpos = new Vector2(imManager.transform.localPosition.x - distanceX * _way, 0);
        float param = 0;

        while(true)
        {
            imManager.transform.localPosition = Vector2.Lerp(defpos, tgtpos, param);

            if (param >= 0.49f && param <= 0.51f)
            {
                background.SetBG(worldIndex);
            }

            if (param >= 1)
            {
                Activate();
                yield break;
            }
            else
            {
                param += 0.01f;
                yield return ws;
            }
        }
    }
}
