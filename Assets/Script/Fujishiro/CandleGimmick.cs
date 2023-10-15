using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CandleGimmick : MonoBehaviour
{
    [SerializeField] Light obj_candle;

    [SerializeField] float Max_Intensity;
    [SerializeField] float Rate_Intensity;
    [SerializeField] float WaitTime;

    [Header("�f�o�b�O�p")]
    [SerializeField] bool debug = false;

    public bool isLight;

    // Start is called before the first frame update
    void Start()
    {
        Rate_Intensity = Max_Intensity / WaitTime * 0.167f;
    }

    // Update is called once per frame
    void Update()
    {
        // ���C�g�̖��邳��0�ȏ�ł���Ό���
        //if(obj_candle.intensity > 0)
        //{
        //    obj_candle.intensity -= Rate_Intensity;
        //}
        //else
        //{
        //    isLight = false;
        //    obj_candle.gameObject.SetActive(false);
        //}

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
        if (isLight)
        {
            obj_candle.intensity = Max_Intensity;
        }
        else
        {
            isLight = true;
            obj_candle.gameObject.SetActive(true);
            StartCoroutine(lighting());
        }
    }

    IEnumerator lighting()
    {
        WaitForSecondsRealtime waittime = new WaitForSecondsRealtime(0.167f);

        obj_candle.intensity = Max_Intensity;

        while(true)
        {
            if(obj_candle.intensity <= 0)
            {
                isLight = false;
                obj_candle.gameObject.SetActive(false);
                yield break;
            }
            else
            {
                obj_candle.intensity -= Rate_Intensity;
            }

            yield return waittime;
        }

    }
}
