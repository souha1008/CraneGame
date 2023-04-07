using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KansetsuBuraBuraB : MonoBehaviour
{
    public GameObject BuraBuraA;
    float Distance;

    public float GLAVITY;

    Vector2 Vel;

    // Start is called before the first frame update
    void Start()
    {
        Distance = (this.transform.position - BuraBuraA.transform.position).magnitude;
        Vel = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 OldPos = transform.position;
        Vel.y -= GLAVITY;

        this.transform.position += new Vector3(Vel.x, Vel.y, 0);

        Vector3 AngleVector = this.transform.position - BuraBuraA.transform.position;
        AngleVector.z = 0;
        if (AngleVector.magnitude > Distance)
        {
            AngleVector = AngleVector.normalized;

            Vector3 NewPosVector = AngleVector * Distance;

            this.transform.position = BuraBuraA.transform.position + NewPosVector;

            Vel = (this.transform.position - OldPos) /** 1.1f*/;
            //Debug.Log("ŠO");
        }
        else
        {

            this.transform.position = new Vector3(transform.position.x,
                transform.position.y,
                BuraBuraA.transform.position.z);
            //Debug.Log("‚È‚©");
        }
        
    }
}
