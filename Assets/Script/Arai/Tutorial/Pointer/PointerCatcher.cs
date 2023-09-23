using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCatcher : MonoBehaviour
{
    [SerializeField]
    private List<TutorialPonter> pointers;

    [SerializeField, ReadOnly]
    private int index = 0;

    private bool clear = false;
    public bool Clear
    {
        get => clear;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!clear)
        {
            Vector2 thispos = this.GetComponent<RectTransform>().anchoredPosition;

            var pointer = pointers[index].GetComponent<RectTransform>();
            Vector2 poinpos = pointer.anchoredPosition;
            Vector2 poinsca = pointer.sizeDelta;
            
            Vector2 width  = new Vector2(poinpos.x - poinsca.x, poinpos.x + poinsca.x);
            Vector2 height = new Vector2(poinpos.y - poinsca.y, poinpos.y + poinsca.y);

            if (thispos.x >= width.x  && thispos.x <= width.y &&
                thispos.y >= height.x && thispos.y <= height.y)
            {
                pointer.GetComponent<TutorialPonter>().Getting();

                if (++index == pointers.Count)
                {
                    clear = true;
                    Debug.Log("MAX");
                }
            }

        }
    }

    public void ResetPointers(bool _zero = false)
    {
        if (clear) return;

        if (!_zero && index <= 1) return;

        if (!_zero) Debug.Log("index01");

        foreach(var pointer in pointers)
        {
           pointer.Releasing();
        }
        index = 0;
    }
}
