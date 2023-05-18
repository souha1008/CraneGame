using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class StageIcon : MonoBehaviour
{
    private Image image;

    [SerializeField]
    private Sprite activeSprite;

    [SerializeField]
    private Sprite inactiveSprite;

    [SerializeField]
    private Image state;

    [SerializeField]
    private TextMeshProUGUI world;

    [SerializeField]
    private TextMeshProUGUI stage;

    [SerializeField]
    private Sprite stateSprite;

    void Awake()
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = inactiveSprite;
    }

    /// <summary>
    /// 選択
    /// </summary>
    public void Activate()
    {
        image.sprite = activeSprite;
    }
    
    /// <summary>
    /// 選択解除
    /// </summary>
    public void Inactivate()
    {
        image.sprite = inactiveSprite;
    }

    public void SetParam(int _world, int _stage, bool _state)
    {
        world.text = (_world + 1).ToString();
        stage.text = (_stage + 1).ToString();

        if (_state)
        {
            state.sprite = stateSprite;
        }
        else
        {
            state.color = new Color(0,0,0,0);
        }
    }
}
