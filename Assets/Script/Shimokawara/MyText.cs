using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProÇàµÇ§ç€Ç…ïKóv

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
