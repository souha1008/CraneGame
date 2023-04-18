using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    private Animator animator;

    readonly float waitTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.transform.GetComponent<Animator>();

        DontDestroyOnLoad(gameObject);
        StartCoroutine(nameof(Transition));
    }

    // Update is called once per frame
    void Update()
    {
        //if (isFade)
        {
            animator.SetFloat("speed", -1);
        }
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
