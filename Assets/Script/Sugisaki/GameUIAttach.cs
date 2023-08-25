using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIAttach : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] Attach.AttachType AttachType;
    [SerializeField] GameObject[] gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attach.AttachType attach = Player2.instance.GetAttach();

        int length = gameObjects.Length;

        if (attach == AttachType) 
        {
            if (isActive)
            {
                for (int i = 0; i < length; i++)
                {
                    if (gameObjects[i])
                        gameObjects[i].SetActive(true);
                }
                    
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (gameObjects[i])
                        gameObjects[i].SetActive(false);
                }
                   
            }
        }
        else
        {
            if (!isActive)
            {
                for (int i = 0; i < length; i++)
                {
                    if (gameObjects[i])
                        gameObjects[i].SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (gameObjects[i])
                        gameObjects[i].SetActive(false);
                }
            }
        }
    }
}
