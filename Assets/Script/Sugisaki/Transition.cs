using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] GameObject cameraObject;

    readonly float waitTime = 1.9f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(cameraObject);
        StartCoroutine(nameof(Trans));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Trans()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
