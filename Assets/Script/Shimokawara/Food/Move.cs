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

    [Header("�u���b�N�̓�������")]
    [SerializeField] DIRECTION Direction;
    [Header("�u���b�N�̕Г�����(�t���[��)")]
    [SerializeField] float TimeRenge;
    [Header("�u���b�N�̕Г��ړ���")]
    [SerializeField] float MoveRenge;
    //[Header("�����̂���x���肩�ǂ���")]
    //[SerializeField] bool DoOnce;
    [Header("�������ǂ���")]
    public    bool isMove = false;

    Vector3 MoveDirection;//��������
    float FlameMove;//1F�̈ړ���
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

            //���W�ړ�
            transform.position += (MoveDirection * FlameMove);

            //�܂�Ԃ�
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
