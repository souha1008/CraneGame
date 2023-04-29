using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Buner : MonoBehaviour
{
    
    [SerializeField][Tooltip("�������������p�[�e�B�N���v���n�u")]ParticleSystem Buner;
    [SerializeField][Range(0.0f, 1.0f)] float BunerSize = 0.0f;

    private ParticleSystem newBuner;
    private ParticleSystem.VelocityOverLifetimeModule Effect_VelocityOverLifetime;

    // Start is called before the first frame update
    void Start()
    {
        // �G�t�F�N�g����
        newBuner = Instantiate(Buner);
        newBuner.Play();
        Effect_VelocityOverLifetime = newBuner.velocityOverLifetime;
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

        // �o�[�i�[�T�C�Y��ς���
        float speedModifier = BunerSize;
        Effect_VelocityOverLifetime.speedModifier = speedModifier;
        
    }

    
}