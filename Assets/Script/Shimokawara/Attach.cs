using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{

    public enum AttachType
    { 
        CRANE,
        KNIFE,
        HAMMER,
        FIRE,
            TYPE_MAX

    };

    public AttachType type;

    private void Start()
    {
        type = AttachType.CRANE;
    }

    // Start is called before the first frame update

    public virtual void CustomInit()
    {

    }

    public virtual void CustomUninit()
    {

    }

    //public void CustomStart()
    //{
        
    //}


    public virtual void CustomUpdate()
    {

    }

    // Update is called once per frame
    public virtual void CustomFixedUpdate()
    {
        
    }


}
