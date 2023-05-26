using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetUI : MonoBehaviour
{
    public static GameSetUI instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isTrue()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

}
