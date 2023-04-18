using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Buner : MonoBehaviour
{
    
    [SerializeField][Header("バーナーエフェクトを入れる")] ParticleSystem Buner;
    [SerializeField][Range(0.0f, 1.0f)] float BunerSize = 0.0f;

    private ParticleSystem.VelocityOverLifetimeModule Effect_VelocityOverLifetime;

    // Start is called before the first frame update
    void Start()
    {
        Effect_VelocityOverLifetime = Buner.velocityOverLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            BunerSize += 0.01f;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            BunerSize -= 0.01f;
        }
        if (BunerSize < 0.0f) BunerSize = 0.0f;
        if (BunerSize > 1.0f) BunerSize = 1.0f;

        // バーナーサイズを変える
        float speedModifier = BunerSize;
        Effect_VelocityOverLifetime.speedModifier = speedModifier;
        
    }

    
}
