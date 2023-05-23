using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_ColorTransfer : MonoBehaviour
{
    [Header("遷移変化させたいオブジェクトを入れる")]
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField][Range(0f, 1f)] public float[] Transfer;
    [SerializeField] public string[] SG_name = {"_Transfer_1st", "_Transfer_2nd" };
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Transfer.Length; i++)
        {
            meshRenderer.material.SetFloat(SG_name[i], Transfer[i]);
        }
    }
}
