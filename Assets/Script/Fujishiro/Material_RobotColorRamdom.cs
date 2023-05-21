using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_RobotColorRamdom : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer skinnedmeshRenderer;

    [SerializeField, ReadOnly] float rand_;
    // Start is called before the first frame update
    void Start()
    {
        rand_ = Random.Range(0.0f, 1.0f);

        skinnedmeshRenderer.material.SetFloat("_Hue", rand_);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rand_ = Random.Range(0.0f, 1.0f);

            skinnedmeshRenderer.material.SetFloat("_Hue", rand_);
        }
    }
}
