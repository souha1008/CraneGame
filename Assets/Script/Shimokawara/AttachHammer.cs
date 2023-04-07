using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Attach))]
#endif

public class AttachHammer : Attach
{
    // Start is called before the first frame update

    // Update is called once per frame
    public override void CustomInit()
    {

    }
}
