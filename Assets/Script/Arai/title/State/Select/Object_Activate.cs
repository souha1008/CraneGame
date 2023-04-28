using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Activate : MonoBehaviour
{
    virtual public void Method(Select_Object _obj)
    {
        _obj.Move(Co.Const.TITLEOBJ_MOVEVOLUM);
    }
}
