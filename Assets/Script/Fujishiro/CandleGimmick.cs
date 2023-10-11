using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CandleGimmick : MonoBehaviour
{
    public static CandleGimmick instance;

    [SerializeField] Light obj_candle;

    [SerializeField] float Max_Intensity = 30.0f;
    [SerializeField] float Rate_Intensity = 1.0f;

    [Header("デバッグ用")]
    [SerializeField] bool debug = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // ライトの明るさが0以上であれば減衰
        if(obj_candle.intensity > 0)
        {
            obj_candle.intensity -= Rate_Intensity;
        }

        if(debug)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                CandleLighting();
            }
        }
    }

    public void CandleLighting()
    {
        StartCoroutine(lighting());
    }

    IEnumerator lighting()
    {
        while(true)
        {
            obj_candle.intensity = Max_Intensity;

            if(obj_candle.intensity >= Max_Intensity )
            {
                yield break;
            }

            yield return null;
        }

    }
}
