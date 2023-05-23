using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmnarasu : MonoBehaviour
{
    [SerializeField] string bgm_name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.BGMPlay(bgm_name, true);
        }
    }
}
