using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadIsFade : MonoBehaviour
{
    public static ReadIsFade instance;

    private bool isFade;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //isFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetIsFade()
    {
        return isFade;
    }

    public void SetIsFade(bool Fade)
    {
        isFade = Fade;
    }
}
