using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class StageSprite : MonoBehaviour
{
    private Image image;

    void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void Activate()
    {
        image.color = Color.red;
    }
    
    public void Inactivate()
    {
        image.color = Color.blue;
    }
}
