using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshPro�������ۂɕK�v

public class PhaseNum : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField] int MaxPhase;  // �ő�t�F�[�Y��
    private int Phase;  // ���݃t�F�[�Y

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Phase = CookMoveManager.instance.GetFazeNum();
        text.text = Phase + "     " + MaxPhase;
    }
}
