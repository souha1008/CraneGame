using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCatcher : MonoBehaviour
{
    [SerializeField]
    private List<TutorialPonter> pointers;

    [SerializeField, ReadOnly]
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Submit"))
        {
            foreach(var pointer in pointers)
            {
               pointer.Releasing();
            }
            index = 0;
        }
    }

    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject == pointers[index].gameObject)
        {
            collisionInfo.gameObject.GetComponent<TutorialPonter>().Getting();

            if (++index == pointers.Count)
            {
                Debug.Log("MAX");
            }
        }
    }
}
