using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro�������ۂɕK�v

public class MyText : MonoBehaviour
{
    TextMeshProUGUI text;
    int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "9999";
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<TextMeshPro>().text = "999";
    }
}
