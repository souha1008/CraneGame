using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shio : MonoBehaviour
{

    public int HitCnt = 0;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        HitCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttachHummer")
        {
            switch (HitCnt)
            {
                case 0:
                    SoundManager.instance.SEPlay("V_‰–Š˜Ä’@‚«SE");
                    break;
                case 1:
                    SoundManager.instance.SEPlay("‰–Š˜Ä‚«Ó‚¯SE");
                    break;

            }


            HitCnt = Mathf.Min(HitCnt + 1, 2);
            Debug.Log("‰–ƒqƒbƒg");

            
        }
        
        if(HitCnt == 2)
        {
            if (Effect)
            {
                Effect.SetActive(true);
                Effect.gameObject.transform.parent = null;
                Effect = null;
            }

        }
    }
}
