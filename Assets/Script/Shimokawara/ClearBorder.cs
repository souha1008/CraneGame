using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBorder : MonoBehaviour
{

    public float Border = 0.0f;

    ScoreData m_ScoreData;
    // Start is called before the first frame update
    void Start()
    {
        m_ScoreData = GameObject.Find("Datas").GetComponent<ScoreData>();

        m_ScoreData.SetBorder(Border);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
