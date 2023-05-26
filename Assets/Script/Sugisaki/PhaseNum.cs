using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProを扱う際に必要

public class PhaseNum : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField] int MaxPhase;  // 最大フェーズ数
    private int Phase;  // 現在フェーズ

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Phase = CookMoveManager.instance.GetFazeNum();
        if (Phase + 1 < MaxPhase)
            Phase = MaxPhase - 1;
        text.text = Phase + 1 + "     " + MaxPhase;
    }
}
