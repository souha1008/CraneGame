using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_ColorTransfer : MonoBehaviour
{
    [Header("遷移変化させたいオブジェクトを入れる")]
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;

    [SerializeField][Range(0f, 1f)] public float[] Transfer = {1.0f, 0.0f };
    [SerializeField] public string[] SG_name = {"_Transfer_1st", "_Transfer_2nd" };

    [SerializeField, ReadOnly] bool isScorch = false;
    [SerializeField, ReadOnly] float trans_time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Transfer.Length; i++)
        {
            if (meshRenderer != null)
                meshRenderer.material.SetFloat(SG_name[i], Transfer[i]);

            if (skinnedMeshRenderer != null)
                skinnedMeshRenderer.material.SetFloat(SG_name[i], Transfer[i]);
        }

        if(isScorch)
        {
            Transfer[0] -= Time.deltaTime * trans_time;

            if(meshRenderer != null)
            meshRenderer.material.SetFloat(SG_name[0], Transfer[0]);

            if (skinnedMeshRenderer != null)
                skinnedMeshRenderer.material.SetFloat(SG_name[0], Transfer[0]);

            if(Transfer[0] <= 0.0f)
            {
                Transfer[0] = 0f;
                isScorch = false;
                trans_time = 0;
            }
        }
    }

    public void Scorch_Object(float time)
    {
        isScorch = true;
        trans_time = time;
    }

}
