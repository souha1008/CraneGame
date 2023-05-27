using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ARM_MOVE
{
    MOVE,
    STOP,
    SLOW
}

public class CreanHitObj : MonoBehaviour
{
    public int Size = 0;



    public ARM_MOVE Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = ARM_MOVE.MOVE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<CircleFoodsInterFace>())
        {
            if(other.GetComponent<CircleFoodsInterFace>().FoodsArmState == CircleFoodsInterFace.FOODS_ARM_STATE.GLAB)
            {
                if(other.GetComponent<CircleFoodsInterFace>().m_ChachAction == ChachAction.HARD)
                {
                    Move = ARM_MOVE.STOP;
                    Size = (int)other.transform.localScale.x;
                }
                if (other.GetComponent<CircleFoodsInterFace>().m_ChachAction == ChachAction.SOFT)
                {
                    Move = ARM_MOVE.SLOW;
                }

            }
        }
    }
}
