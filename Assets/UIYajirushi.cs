using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIYajirushi : MonoBehaviour
{
    public Vector3 Direction;
    //public GameObject Player;
    float Distance = 2.0f;
    static public UIYajirushi instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Direction = new Vector3 (1,0,0);
       // Player = GameObject.Find("Capsule"); 
    }


    void Update()
    {
        //LeftStick = new Vector2(0, 0);

#if true
        //入力時のみ更新
        if (Player.instance.LeftStick != Vector2.zero)
        {
            Direction = Player.instance.LeftStick;
        }
#else
                    if (Input.GetKey("a"))
                    {
                        LeftStick.x -= 1;
                    }
                    if (Input.GetKey("d"))
                    {
                        LeftStick.x += 1;
                    }
                    if (Input.GetKey("w"))
                    {
                        LeftStick.y += 1;
                    }
                    if (Input.GetKey("s"))
                    {
                        LeftStick.y -= 1;
                    }
#endif

        Direction = Direction.normalized;

        float Z_CenterRadian = Mathf.Atan2(Direction.y, Direction.x);

        //度にする
        float Z_CenterAngle = Z_CenterRadian / Mathf.PI * 180 -90;

        transform.localEulerAngles = new Vector3(0, 0, Z_CenterAngle);

        transform.position = Player.instance.transform.position + Direction * Distance;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        

    }
}
