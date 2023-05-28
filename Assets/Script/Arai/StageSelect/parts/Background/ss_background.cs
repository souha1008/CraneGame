using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ss_background : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> bgs = new List<Sprite>();

    [SerializeField] private Image image;

    public void SetBG(int _worldindex)
    {
        image.sprite = bgs[_worldindex];
    }
}
