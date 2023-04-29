using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    public Player2 player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isChange)
        {
            switch (player.ChangeCnt)
            {
                case 0:
                    break;


                default:
                    break;
            }

        }
    }
}
