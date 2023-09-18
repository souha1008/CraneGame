using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Move : MonoBehaviour
{
    enum DIRECTION
    {
        Right,
        Left,
        Up,
        Down,
        RightUp,
        RightDown,
        LeftUp,
        LeftDown
    }

    [Header("ブロックの動く向き")]
    [SerializeField] DIRECTION Direction;
    [Header("ブロックの片道時間(フレーム)")]
    [SerializeField] float TimeRenge;
    [Header("ブロックの片道移動量")]
    [SerializeField] float MoveRenge;
    //[Header("動くのが一度きりかどうか")]
    //[SerializeField] bool DoOnce;
    [Header("動くかどうか")]
    public    bool isMove = false;

    Vector3 MoveDirection;//動く方向
    float FlameMove;//1Fの移動量
    int FCnt;

    // Start is called before the first frame update
    void Start()
    {
        FlameMove = MoveRenge / TimeRenge;
        FCnt = 0;
        VelDirection();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        
        if(isMove)
        {

            //座標移動
            transform.position += (MoveDirection * FlameMove);

            //折り返し
            FCnt++;
            if (FCnt >= TimeRenge)
            {
                FCnt = 0;
                MoveDirection *= -1;
            }
        }

    }

    void VelDirection()
    {
        switch (Direction)
        {
            case DIRECTION.Right:
                MoveDirection = Vector3.right;
                break;

            case DIRECTION.Left:
                MoveDirection = Vector3.left;
                break;

            case DIRECTION.Up:
                MoveDirection = Vector3.forward;
                break;

            case DIRECTION.Down:
                MoveDirection = new Vector3(0, 0, -1);
                break;

            case DIRECTION.RightUp:
                MoveDirection = new Vector3(1, 0, 1);
                break;

            case DIRECTION.RightDown:
                MoveDirection = new Vector3(1, 0, -1);
                break;

            case DIRECTION.LeftUp:
                MoveDirection = new Vector3(-1, 0, 1);
                break;

            case DIRECTION.LeftDown:
                MoveDirection = new Vector3(-1, 0, -1);
                break;
        }
    }

}
