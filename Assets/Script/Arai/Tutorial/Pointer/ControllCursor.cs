using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllCursor : MonoBehaviour
{
    RectTransform pos;

    Vector2 defpos;

    [SerializeField]
    private PointerCatcher catcher;

    void Start()
    {
        pos = GetComponent<RectTransform>();

        defpos = pos.anchoredPosition;
    }

    void Update()
    {
        var hol = Input.GetAxis("RightX");
        var ver = Input.GetAxis("RightY");

        pos.anchoredPosition = new Vector2(defpos.x + hol * 300, defpos.y - ver * 300);

        float length = Mathf.Sqrt(hol * hol + ver * ver);


        if (length <= 0.7f)
        {
            if (length <= 0.1f)
                catcher.ResetPointers(true);
            else
                catcher.ResetPointers();
        }
    }
}
