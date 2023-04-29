using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessManager : MonoBehaviour
{
    public static SuccessManager instance;
    [SerializeField] GameObject UI_Object;


    private void Awake()
    {
        if(instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UI_Object.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Success_UIActive()
    {
        UI_Object.SetActive(true);
    }
}
