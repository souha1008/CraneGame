using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PhaseScore : MonoBehaviour
{
    private Image image;
    private Color color;

    private float alpha = 0;
    
    [SerializeField]
    private float alphaRatio = 0.01f;

    private Vector2 defaultPosition;
    [SerializeField]
    private Vector2 offsetPosition;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();

        color = image.color;
        image.color = new Color(color.r, color.g, color.b, alpha);

        defaultPosition = image.rectTransform.anchoredPosition;
        image.rectTransform.anchoredPosition = defaultPosition - offsetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        alpha += alphaRatio;
        image.rectTransform.anchoredPosition = defaultPosition - offsetPosition * (1 - alpha);
        image.color = new Color(color.r, color.g, color.b, alpha);

        if (alpha >= color.a)
        {
            image.color = color;
            Destroy(this);
        }
    }
}
