using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCoroutine : MonoBehaviour
{
    [SerializeField] public bool mPaused = false;

    [SerializeField][Tooltip("��������|�[�Y������")] KeyCode pauseKey = KeyCode.P;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(pauseKey) && mPaused == true)
        {
            mPaused = true;
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
            CallCoroutine();
        }
        
    }

    private void Update()
    {
    }

    void CallCoroutine()
    {
        StartCoroutine("PauseStart");
    }

    IEnumerator PauseStart()
    {
        Debug.Log("�|�[�Y��");
        StartCoroutine("PauseMenu");
        yield return new WaitUntil(() => Input.GetKeyDown(pauseKey));

        Debug.Log("�|�[�Y����");
        StopCoroutine("PauseMenu");
        mPaused = false;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 1.0f;
    }
    IEnumerator PauseMenu()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("��");
            }
            yield return null;
        }
    }
}
