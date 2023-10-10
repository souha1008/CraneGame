using System.Collections;
using System.Collections.Generic;
using Co;
using UnityEngine;
using UnityEngine.UI;

public class TutKniJuuji : TutModule
{
    [SerializeField]
    private RawImage image;

    void Start()
    {
        image.gameObject.transform.parent.gameObject.SetActive(true);
        image.gameObject.transform.parent.GetComponent<Image>().color = Const.CLEAR;
        image.gameObject.SetActive(true);
        image.SetNativeSize();
    }

    void Update()
    {
        var x = Input.GetAxis("JuujiKeyX");
        var y = Input.GetAxis("JuujiKeyY");

        if (x != 0 || y != 0)
        {
            Fin();
        }
    }
}
