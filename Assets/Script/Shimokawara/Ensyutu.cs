using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ensyutu : MonoBehaviour
{
    static public Ensyutu instance;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = EnsyutuManager.instance.PlayerPos;

        float OPtoP_Angle = Mathf.Atan2(EnsyutuManager.instance.OPtoP.y, EnsyutuManager.instance.OPtoP.x);
        float ThisAngle_DO = OPtoP_Angle / Mathf.PI * 180 ;
        transform.localEulerAngles = new Vector3(ThisAngle_DO, -90, 0);

        float SizeMulti = Mathf.Min(1, Vector3.Distance(EnsyutuManager.instance.OPtoP, Vector3.zero) / 1);

        transform.localScale = new Vector3(4 * SizeMulti, 4 * SizeMulti, 4 * SizeMulti);
    }

    void FixedUpdate()
    {
        

        

    }
}
