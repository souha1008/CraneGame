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

    [Header("�f�o�b�O�p")]
    [SerializeField] bool debug = false;

    public bool isLight;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // ���C�g�̖��邳��0�ȏ�ł���Ό���
        if(obj_candle.intensity > 0)
        {
            obj_candle.intensity -= Rate_Intensity;
        }
        else
        {
            isLight = false;
            obj_candle.gameObject.SetActive(false);
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
        isLight = true;
        obj_candle.gameObject.SetActive(true);
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
