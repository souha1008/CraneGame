using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("�J�E���g�_�E���f�t�H���g")]
    float DefaultTime = 0.0f;
    
    [SerializeField]
    [Tooltip("�J�E���g�_�E������UI�I�u�W�F�N�g")] Text CountDownText;

    [SerializeField]
    [Tooltip("���Ԃ̉��ɕ\�����������e�L�X�g")]
    string TimeExplanation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownText.text = string.Format(TimeExplanation) + DefaultTime.ToString("00");
        DefaultTime -= Time.deltaTime;

        if(DefaultTime <= 0.0f) DefaultTime = 0.0f;
    }
}
