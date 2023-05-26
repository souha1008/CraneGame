using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTex1 : MonoBehaviour
{
    private Animator animator;

    [SerializeField] GameObject readIsFade;

    readonly float waitTime = 3.8f;

    public float stopTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(readIsFade);
        StartCoroutine(nameof(Trans));
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Trans()
    {
        yield return new WaitForSeconds(waitTime / 2);

        StartCoroutine((nameof(WaitAnim)));

        yield return new WaitForSeconds(waitTime);

        readIsFade.GetComponent<ReadIsFade>().SetIsFade(false);
        Destroy(gameObject);
    }

    IEnumerator WaitAnim()
    {
        animator.SetFloat("speed", 0.0f);

        yield return new WaitForSeconds(stopTime);

        animator.SetFloat("speed", 1.0f);
    }
}