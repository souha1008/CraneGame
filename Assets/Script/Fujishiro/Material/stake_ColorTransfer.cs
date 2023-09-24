using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stake_ColorTransfer : MonoBehaviour
{
    [Header("遷移変化させたいオブジェクトを入れる")]
    [SerializeField] MeshRenderer[] meshRenderer;

    float nowparam = 0;

    bool trans_inc = false;
    bool trans_dec = false;
    float speed = 0;
    string trans_param_name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < meshRenderer.Length; i++)
        {
            if (meshRenderer[0] != null)
                meshRenderer[i].material.SetFloat(trans_param_name, nowparam);
        }


        if (trans_inc)
        {
            nowparam += speed;

            for (int i = 0; i < meshRenderer.Length; i++)
            {
                if (meshRenderer[0] != null)
                    meshRenderer[i].material.SetFloat(trans_param_name, nowparam);
            }

            if (nowparam > 1)
                trans_inc = false;
        }

        if (trans_dec)
        {
            nowparam -= speed;

            for (int i = 0; i < meshRenderer.Length; i++)
            {
                if (meshRenderer[0] != null)
                    meshRenderer[i].material.SetFloat(trans_param_name, nowparam);
            }

            if (nowparam < 0)
                trans_dec = false;

        }
    }

    public void ZeroToOne(float speedf, string sg_name = "_Transfer_1st", float init = 0)
    {
        speed = speedf;
        trans_param_name = sg_name;
        nowparam = init;

        trans_inc = true;
    }

    public void OneToZero(float speedf, string sg_name = "_Transfer_1st", float init = 1)
    {
        speed = speedf;
        trans_param_name = sg_name;
        nowparam = init;

        trans_dec = true;
    }
}
