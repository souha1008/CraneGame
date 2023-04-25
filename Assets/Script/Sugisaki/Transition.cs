using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] GameObject cameraObject;

    private Animator animator;

    readonly float waitTime = 1.9f;

    public float stopTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

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
        yield return new WaitForSeconds(waitTime / 2 +0.02f);

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
}
