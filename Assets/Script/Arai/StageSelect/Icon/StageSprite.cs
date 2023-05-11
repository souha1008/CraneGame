using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StageSprite : MonoBehaviour
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

    public void Activate()
    {
        image.sprite = activeSprite;
    }
    
    public void Inactivate()
    {
        image.sprite = inactiveSprite;
    }
}
