using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObserver : MonoBehaviour
{
    private static TutorialObserver observer;

    [SerializeField]
    private int index = 0;
    public int Index
    {
        get => index;
        set => index = value;
    }

    void Start()
    {
        if (!observer)
        {
            observer = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
