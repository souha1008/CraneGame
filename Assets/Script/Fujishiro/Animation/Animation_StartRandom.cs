using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_StartRandom : MonoBehaviour
{
    //[Header("ここに開始位置をランダムにさせたいAnimatorを入れてね")]
    //[SerializeField]
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(_animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f, 1f));  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
