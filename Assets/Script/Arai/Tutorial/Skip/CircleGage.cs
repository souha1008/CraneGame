using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleGage : MonoBehaviour
{
    [SerializeField]
    private string ButtonName = "Debug Multiplier";

    private Image image;

    [SerializeField, ReadOnly]
    private float param = 0;

    [SerializeField]
    private float speed = 0.05f;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.fillAmount = param;
    }

    void Update()
    {
        if (Input.GetButton(ButtonName))
        {
            if ((param += speed) >= 1)
            {
                Debug.Log("fin");
                param = 0;
            }
        }
        else
        {
            if (param > 0)
            {
                param = 0;
            }
        }
        image.fillAmount = param;
    }
}
