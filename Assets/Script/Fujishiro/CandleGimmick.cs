using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CandleGimmick : MonoBehaviour
{
    [SerializeField] Light obj_candle;

    [SerializeField] float Max_Intensity = 30.0f;
    [SerializeField] float Rate_Intensity = 1.0f;

    [Header("デバッグ用")]
    [SerializeField] bool debug = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(debug)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                CandleLighting();
            }
        }
    }

    void CandleLighting()
    {
        StartCoroutine(lighting());
    }

    IEnumerator lighting()
    {
        while(true)
        {
            obj_candle.intensity += Rate_Intensity;

            if(obj_candle.intensity > Max_Intensity )
            {
                yield break;
            }

            yield return null;
        }

    }
}
