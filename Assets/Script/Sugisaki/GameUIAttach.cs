using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIAttach : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] Attach.AttachType AttachType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attach.AttachType attach = Player2.instance.GetAttach();

        if (attach == AttachType) 
        {
            if (isActive)
            {
                this.enabled = true;
            }
            else
            {
                this.enabled = false;
            }
        }
        else
        {
            if (!isActive)
            {
                this.enabled = true;
            }
            else
            {
                this.enabled = false;
            }
        }
    }
}
