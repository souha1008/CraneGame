using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILook : MonoBehaviour
{
    [SerializeField] GameObject UIEmpty;

    static public UILook Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
        UIEmpty.SetActive(true);

        EnableUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EnableUI();
        }
    }

    public void AbleUI()
    {
        UIEmpty.SetActive(true);
    }

    public void EnableUI()
    {
        UIEmpty.SetActive(false);
    }
}
