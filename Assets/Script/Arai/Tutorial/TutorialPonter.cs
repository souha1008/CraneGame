using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPonter : MonoBehaviour
{
    private Image image;
    private BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        coll  = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Getting()
    {
        image.color = new Color(0f, 1f, 1f, 1f);
        coll.enabled = false;
    }
    public void Releasing()
    {
        image.color = new Color(1f, 0f, 0f, 1f);
        coll.enabled = true;
    }
}
