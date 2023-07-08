using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllCursor : MonoBehaviour
{
    RectTransform pos;

    Vector2 defpos;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<RectTransform>();

        defpos = pos.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var ver = Input.GetAxis("Vertical");
        var hol = Input.GetAxis("Horizontal");

        pos.anchoredPosition = new Vector2(defpos.x + hol * 300, defpos.y + ver * 300);
    }
}
