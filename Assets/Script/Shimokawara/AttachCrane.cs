using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Attach))]
#endif

public class AttachCrane : Attach
{
    // Start is called before the first frame update

    static public AttachCrane instance;
    public GameObject Crane;

    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public override void CustomInit()
    {
       // Crane.GetComponent<Collider>().enabled = true;
        Crane.SetActive(true);
    }

    public override void CustomUninit()
    {
        //Crane.GetComponent<Collider>().enabled = false;
        // Debug.Log("ÇÅÇéÇéÇâÇéÇâÇîÇîÇè");
        Debug.Log(Crane);
        Crane.SetActive(false);
    }
}
