using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCoroutine : MonoBehaviour
{
    [SerializeField] bool mPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mPaused)
        {
            Time.timeScale = 0;
            CallCoroutine();
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            mPaused = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("��");
        }
    }

    void CallCoroutine()
    {
        StartCoroutine("PauseStart");
    }

    IEnumerator PauseStart()
    {
        Debug.Log("�|�[�Y��");
        StartCoroutine("PauseMenu");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.O));
        Debug.Log("�|�[�Y����");
        StopCoroutine("PauseMenu");
        mPaused = false;
        Time.timeScale = 1.0f;
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
