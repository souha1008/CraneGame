using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class StageIcon : MonoBehaviour
{
    private Image image;

    [SerializeField]
    private Image state;

    [SerializeField]
    private TextMeshProUGUI world;

    [SerializeField]
    private TextMeshProUGUI stage;

    [SerializeField]
    private Sprite stateSprite;

    [SerializeField]
    private Image select;

    [SerializeField]
    private Sprite[] statesprites = new Sprite[(int)ResultEnum.RESULT.MAX];

    [SerializeField]
    private Sprite unlocksprite;

    void Awake()
    {
        image = gameObject.GetComponent<Image>();
        Inactivate();
    }

    /// <summary>
    /// 選択
    /// </summary>
    public void Activate()
    {
        select.enabled = true;
    }
    
    /// <summary>
    /// 選択解除
    /// </summary>
    public void Inactivate()
    {
        select.enabled = false;
    }

    public void SetParam(int _world, int _stage, int _state)
    {
        world.text = (_world + 1).ToString();
        stage.text = (_stage + 1).ToString();

        if (_state == -1)
        {
            state.sprite = unlocksprite;
            state.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
            state.SetNativeSize();
        }
        else if (_state == 0)
        {
            state.enabled = false;
        }
        else state.sprite = statesprites[_state - 1];
    }
}
