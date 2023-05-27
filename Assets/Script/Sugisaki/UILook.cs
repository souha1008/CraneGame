using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILook : MonoBehaviour
{
    [SerializeField] GameObject UIEmpty;

    // Start is called before the first frame update
    void Start()
    {
        UIEmpty.SetActive(true);
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
