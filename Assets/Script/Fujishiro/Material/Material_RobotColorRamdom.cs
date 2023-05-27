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

        skinnedmeshRenderer.material.SetVector("_Luminance",
    new Vector4(Random.Range(-0.25f, 0),
    Random.Range(-0.25f, 0),
    Random.Range(-0.25f, 0), 0));
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rand_ = Random.Range(0.0f, 1.0f);

            skinnedmeshRenderer.material.SetFloat("_Hue", rand_);


            skinnedmeshRenderer.material.SetVector("_Luminance",
                new Vector4(Random.Range(-0.25f, 0),
                Random.Range(-0.25f, 0),
                Random.Range(-0.25f, 0), 0));
        }
#endif
    }
}
