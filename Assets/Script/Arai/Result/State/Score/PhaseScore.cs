using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PhaseScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI clearscore;

    [SerializeField]
    private TextMeshProUGUI missscore;

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

    [SerializeField]
    private Sprite[] images = new Sprite[Co.Const.FAZE_NUM];


    void Awake()
    {
        rt = gameObject.GetComponent<RectTransform>();

        defaultPosition = rt.anchoredPosition;
        rt.anchoredPosition = defaultPosition - offsetPosition;

        clearscore.color = missscore.color = new Color(clearscore.color.r, clearscore.color.g, clearscore.color.b, alpha);
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    void Update()
    {
        alpha += alphaRatio;

        rt.anchoredPosition += offsetPosition * alphaRatio;

        clearscore.color = missscore.color = new Color(clearscore.color.r, clearscore.color.g, clearscore.color.b, alpha);
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

        if (alpha >= 1)
        {
            clearscore.color = missscore.color = new Color(clearscore.color.r, clearscore.color.g, clearscore.color.b, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            Destroy(this);
        }
    }

    public void SetClearScore(int _score)
    {
        clearscore.text = _score.ToString();
    }
    public void SetMissScore(int _score)
    {
        missscore.text = _score.ToString();
    }

    public void SetImage(int _phase)
    {
        image.sprite = images[_phase];
    }
}
