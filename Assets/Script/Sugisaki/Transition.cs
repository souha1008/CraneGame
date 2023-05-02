using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private Animator animator;

    private GameObject cameraObject;

    readonly float waitTime = 1.9f;

    public float stopTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        DontDestroyOnLoad(gameObject);
        StartCoroutine(nameof(Trans));
    }
    // Update is called once per frame
    void Update()
    {
        cameraObject = GameObject.Find("Main Camera");
        
        Vector3 position = cameraObject.transform.position;
        Quaternion rotate = cameraObject.transform.rotation;
        Vector3 scale = cameraObject.transform.localScale;

        //position.z = position.z + 1.0f;

        gameObject.transform.position = position;
        gameObject.transform.rotation = rotate;
        gameObject.transform.localScale = scale;
    }

    IEnumerator Trans()
    {
        yield return new WaitForSeconds(waitTime / 2 + 0.03f);

        StartCoroutine((nameof(WaitAnim)));

        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }

    IEnumerator WaitAnim()
    {
        animator.SetFloat("speed", 0.0f);

        yield return new WaitForSeconds(stopTime);

        animator.SetFloat("speed", 1.0f);
    }

    void TransAnim()
    {
        Debug.Log("trans");
        StartCoroutine((nameof(WaitAnim)));
    }
}
