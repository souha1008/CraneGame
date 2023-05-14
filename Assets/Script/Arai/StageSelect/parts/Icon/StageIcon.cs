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
}
