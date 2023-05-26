using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private Animator animator;

    [SerializeField] GameObject readIsFade;

    readonly float waitTime = 1.9f;

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
        Camera cameraObject;

        //cameraObject = GameObject.Find("Main Camera");
        cameraObject = Camera.main;
        
        Vector3 position = cameraObject.transform.position;
        Quaternion rotate = cameraObject.transform.rotation;
        
        position.y = position.y - 1.0f;
        position.z = position.z + 10.0f;
        rotate.x = cameraObject.transform.localEulerAngles.x;
        rotate.y = rotate.y + 180.0f;

        gameObject.transform.position = position;
        gameObject.transform.rotation = rotate;
    }

    IEnumerator Trans()
    {
        yield return new WaitForSeconds(waitTime / 2 + 0.03f);

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
