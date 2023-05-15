using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_RobotColorGaming : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer skinnedmeshRenderer;

    [SerializeField] float change_rate = 1;
    [SerializeField, ReadOnly] float range;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        range += change_rate / 10000;

        skinnedmeshRenderer.material.SetFloat("_Hue", range);

        if (range > 1.0f) range = 0.0f;
    }

}
