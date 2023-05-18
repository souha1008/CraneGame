using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StageIcon : MonoBehaviour
{
    private Image image;

    [SerializeField]
    private Sprite activeSprite;

    [SerializeField]
    private Sprite inactiveSprite;

    [SerializeField]
    private Image world;

    [SerializeField]
    private Image stage;

    [SerializeField]
    private Image state;

    [SerializeField]
    private Numbers numbers;

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
        world.sprite = numbers.numbers[_world + 1];
        stage.sprite = numbers.numbers[_stage + 1];

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
