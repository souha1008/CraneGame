using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beltconver_RotateSpeed : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material.SetFloat("_RotateSpeed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
