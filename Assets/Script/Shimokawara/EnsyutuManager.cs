using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnsyutuManager : MonoBehaviour
{
    public Vector3 PlayerPos;
    public Vector3 PlayerOldPos;
    public Vector3 OPtoP;

    static public EnsyutuManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //PlayerPos = PlayerOldPos = Player.instance.transform.position;
        OPtoP = PlayerPos - PlayerOldPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerOldPos = PlayerPos;
        PlayerPos = Player2.instance.transform.position;

        if (Vector3.Distance(PlayerPos, PlayerOldPos) < 0.2f)
        {
            //Ensyutu.instance.gameObject.SetActive(false);
        }
        else
        {
            //Ensyutu.instance.gameObject.SetActive(true);
        }

        //Debug.Log(Vector3.Distance(PlayerPos, PlayerOldPos));
        OPtoP = PlayerPos - PlayerOldPos;
    }
}
