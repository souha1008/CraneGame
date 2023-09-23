using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutCatCatchReal : TutModule
{
    [SerializeField]
    private Transform arm;
    [SerializeField]
    private float limitAngle = 65;

    [SerializeField]
    private RawImage image;

    void Start()
    {
        image.gameObject.SetActive(true);
    }

    void Update()
    {
        if (arm.rotation.z >= limitAngle * 0.01f)
        {
            image.gameObject.SetActive(false);
            Fin();
        }
    }
}
