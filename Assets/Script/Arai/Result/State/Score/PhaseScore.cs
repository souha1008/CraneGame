using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PhaseScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;

    [SerializeField]
    private Image image;
    
    [SerializeField]
    private Vector2 offsetPosition;
    
    [SerializeField]
    private float alphaRatio = 0.01f;

    private RectTransform rt;
    private Vector2 defaultPosition;
    private float alpha = 0;

    private ShowScore ss;
    public ShowScore SS
    {
        set => ss = value;
    }

    void Awake()
    {
        rt = gameObject.GetComponent<RectTransform>();

        defaultPosition = rt.anchoredPosition;
        rt.anchoredPosition = defaultPosition - offsetPosition;

        score.color = new Color(score.color.r, score.color.g, score.color.b, alpha);
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    void Update()
    {
        alpha += alphaRatio;

        rt.anchoredPosition += offsetPosition * alphaRatio;

        score.color = new Color(score.color.r, score.color.g, score.color.b, alpha);
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

        if (alpha >= 1)
        {
            score.color = new Color(score.color.r, score.color.g, score.color.b, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            ss.SE();
            Destroy(this);
        }
    }

    public void SetScore(int _score)
    {
        score.text = _score.ToString();
    }
}
