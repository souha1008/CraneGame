using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamaguriAnim : MonoBehaviour
{

    public GameObject Uwabuta;

    int AnimCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Hamaguri>())
        {
            if (this.gameObject.GetComponent<Hamaguri>().Open)
            {
                switch (AnimCnt)
                {
                    case 0:
                        Uwabuta.transform.localRotation = Quaternion.Euler(0, 110, 90.0f);
                        break;

                    case 1:
                        Uwabuta.transform.localRotation = Quaternion.Euler(0, 65, 90.0f);
                        break;

                    case 2:
                        Uwabuta.transform.localRotation = Quaternion.Euler(0, 20, 90.0f);
                        break;

                    default:
                        Uwabuta.transform.localRotation = Quaternion.Euler(0, -15, 90.0f);
                        break;



                }
                AnimCnt++;
            }            
        }
        else
        {
            //Debug.Log("アタッチ確認ミス");
        }
    }
}
