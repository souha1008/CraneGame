using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleGage : MonoBehaviour
{
    [SerializeField]
    private string ButtonName = "Cancel";

    private Image image;

    [SerializeField, ReadOnly]
    private float param = 0;

    [SerializeField]
    private float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.fillAmount = param;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(ButtonName))
        {
            if ((param += speed) >= 1)
            {
                Debug.Log("fin");
                Destroy(this);
            }
        }
        else
        {
            if ((param -= speed) < 0)
            {
                param = 0;
            }
        }
        image.fillAmount = param;
    }
}
