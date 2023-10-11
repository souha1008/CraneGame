using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightManager : MonoBehaviour
{
    static public SpotLightManager instans;

    public GameObject[] LightArray;

    public bool[] isCandle = new bool[5];

    // Start is called before the first frame update
    void Start()
    {
        instans = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightChange (bool B)
    {
        if(B)
        {
            LightOn();
        }
        else
        {
            LightOff();
        }
    }

    void LightOn ()
    {
        for(int i = 0; i < LightArray.Length; i++)
        {
            if (LightArray[i] == null)
                LightArray[i].SetActive(true);
        }
    }

    void LightOff()
    {
        for (int i = 0; i < LightArray.Length; i++)
        {
            if (LightArray[i] == null)
                LightArray[i].SetActive(false);
        }
    }
}
