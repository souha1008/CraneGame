using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPonter : MonoBehaviour
{
    private Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Getting()
    {
        image.color = new Color(0f, 1f, 1f, 1f);
    }
    public void Releasing()
    {
        image.color = new Color(1f, 0f, 0f, 1f);
    }
}
