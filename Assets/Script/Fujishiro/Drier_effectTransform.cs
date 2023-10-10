using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drier_effectTransform : MonoBehaviour
{
    public static Drier_effectTransform instance;

    [SerializeField] GameObject Drier_effect;
    [SerializeField] GameObject Fire_effect;

    [SerializeField][Range(0f, 1.0f)] float debug;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayDrier(float tuyosa)
    {
        if (tuyosa <= 0f)
        {
            Fire_effect.SetActive(false);
            Drier_effect.SetActive(false);
        }
        if (tuyosa > 0 && tuyosa < 0.85f)
        {
            Fire_effect.SetActive(false);
            Drier_effect.SetActive(true);
        }
        if(tuyosa >= 0.85f)
        {
            Drier_effect.SetActive(false);
            Fire_effect.SetActive(true);
        }
    }
}
