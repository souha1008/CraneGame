using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(FoodsSupportInterFace))]
#endif


public class Karaage : FoodsSupportInterFace
{

    public GameObject Effect;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        Effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("‚È‚ñ‚©‚ ‚½‚Á‚½");
        if(other.GetComponent<LemonJIru>())
        {
            isClear = true;
            Effect.SetActive(true);
        }
    }
}
