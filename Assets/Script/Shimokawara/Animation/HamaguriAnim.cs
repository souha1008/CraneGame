using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamaguriAnim : MonoBehaviour
{

    public GameObject Uwabuta;
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
                Uwabuta.transform.localRotation = Quaternion.Euler(0, -15, 90.0f);
            }

        }
        else
        {
            //Debug.Log("アタッチ確認ミス");
        }
    }
}
