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

        switch(_state)
        {
            case 0:
                state.color = new Color(0,0,0,0);
            break;
            case 1:
                state.color = Color.red;
            break;
            case 2:
                state.color = Color.green;
            break;
            case 3:
                state.color = Color.yellow;
            break;
        }
    }
}
