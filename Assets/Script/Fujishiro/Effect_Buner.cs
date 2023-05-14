using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Effect_Buner : MonoBehaviour
{
    // StartSizeとStartSpeedをいじれば小さくなるかも

    [SerializeField][Tooltip("Fire01のパーティクル")] ParticleSystem Fire01;
    [SerializeField][Tooltip("Fire01のパーティクル")] ParticleSystem Glow01;
    [SerializeField][Tooltip("Fire01のパーティクル")] ParticleSystem Dist01;
    [SerializeField][Range(0.0f, 1.0f)] float BunerSize = 0.0f;

    [Header("Fire01関連")]
    [SerializeField] Vector2 Fire01_Init_StartSpeed = new Vector2(15f, 7f);
    [SerializeField] float Fire01_Init_StartSize = 0.8f;
    [SerializeField] float Fire01_Offset_StartSize = 0.6f;

    [Header("Glow01関連")]
    [SerializeField] Vector2 Glow01_Init_StartSize = new Vector2(2.5f, 2.0f);
    [SerializeField] Vector2 Glow01_Offset_StartSize = new Vector2(1f, 0.8f);

    [Header("Dist01関連")]
    [SerializeField] Vector2 Dist01_Init_StartSpeed = new Vector2(6, 7);
    [SerializeField] Vector2 Dist01_Init_StartSize = new Vector2(1.5f, 1.5f);
    [SerializeField] Vector2 Dist01_Offset_StartSpeed = new Vector2(2.7f, 1.25f);
    [SerializeField] Vector2 Dist01_Offset_StartSize = new Vector2(0.1f, 0.7f);

    // メインモジュール変数
    private ParticleSystem.MainModule Fire01_MainModule;
    private ParticleSystem.MainModule Glow01_MainModule;
    private ParticleSystem.MainModule Dist01_MainModule;

    // Start is called before the first frame update
    void Start()
    {
        // パーティクル情報取得
        Fire01_MainModule = Fire01.main;
        Glow01_MainModule = Glow01.main;
        Dist01_MainModule = Dist01.main;
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

        Fire_Change();
        Glow_Change();
        Dist_Change();


    }

    void Fire_Change()
    {
        // StartSpeed変更
        Vector2 particle = new Vector2(BunerSize * Fire01_Init_StartSpeed.x, BunerSize * Fire01_Init_StartSpeed.y);
        var startspeed = Fire01_MainModule.startSpeed;
        startspeed.constantMin = particle.x;
        startspeed.constantMax = particle.y;
        Fire01_MainModule.startSpeed = startspeed;

        // StartSize変更 (Vector2のxを使う)
        particle.x = (BunerSize * Fire01_Init_StartSize) + Fire01_Offset_StartSize;
        if (particle.x > Fire01_Init_StartSize) particle.x = Fire01_Init_StartSize;
        var startsize = Fire01_MainModule.startSize;
        startsize = particle.x;
        Fire01_MainModule.startSize = startsize;
    }

    void Glow_Change()
    {
        // StartSize変更
        Vector2 particle;
        particle = new Vector2(BunerSize * Glow01_Init_StartSize.x + Glow01_Offset_StartSize.x,
            BunerSize * Glow01_Init_StartSize.y + Glow01_Offset_StartSize.y);

        if(particle.x > Glow01_Init_StartSize.x) particle.x = Glow01_Init_StartSize.x;
        if(particle.y > Glow01_Init_StartSize.y) particle.y = Glow01_Init_StartSize.y;

        if(particle.x <= Glow01_Offset_StartSize.x) particle.x = 0;
        if(particle.y <= Glow01_Offset_StartSize.y) particle.y = 0;

        var startsize = Glow01_MainModule.startSize;
        startsize.constantMin = particle.x;
        startsize.constantMax = particle.y;
        Glow01_MainModule.startSize = startsize;

    }

    void Dist_Change()
    {
        // StartSpeed変更
        Vector2 particle = new Vector2(BunerSize * Dist01_Init_StartSpeed.x + Dist01_Offset_StartSpeed.x,
            BunerSize * Dist01_Init_StartSpeed.y + Dist01_Offset_StartSpeed.y);
        var startspeed = Dist01_MainModule.startSpeed;
        startspeed.constantMin = particle.x; 
        startspeed.constantMax = particle.y;
        Dist01_MainModule.startSpeed = startspeed;


        // StartSize変更
        particle = new Vector2(BunerSize * Dist01_Init_StartSize.x + Dist01_Offset_StartSize.x,
            BunerSize * Dist01_Init_StartSize.y + Dist01_Offset_StartSize.y);

        if(particle.x > Dist01_Init_StartSize.x) particle.x = Dist01_Init_StartSize.x;
        if(particle.y > Dist01_Init_StartSize.y) particle.y = Dist01_Init_StartSize.y;

        if(particle.x <= Dist01_Offset_StartSize.x) particle.x = 0;
        if(particle.y <= Dist01_Offset_StartSize.y) particle.y = 0;

        var startsize = Dist01_MainModule.startSize;
        startsize.constantMin = particle.x; 
        startsize.constantMax = particle.y;
        Dist01_MainModule.startSize = startsize;
    }
    
}
