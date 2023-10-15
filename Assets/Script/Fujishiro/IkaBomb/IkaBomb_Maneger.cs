using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class IkaBomb_Maneger : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] Sprite_sumi;

    [SerializeField] float alpha_value;
    [SerializeField] bool UseSumi;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Sprite_sumi.Length; i++)
        {
            Sprite_sumi[i].color = new Color(0, 0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ���X�ɖn�������Ȃ��Ȃ�
        if (UseSumi)
        {
            for (int i = 0; i < Sprite_sumi.Length; i++)
            {
                var color = Sprite_sumi[i].color;
                color.a -= alpha_value / 10000;
                Sprite_sumi[i].color = color;
            }
            if (Sprite_sumi[0].color.a < 0)
            {
                UseSumi = false;
            }
        }
    }

    public void Bomb(Collider other)
    {
        if (other.gameObject.tag == "AttachKnife")
        {
            UseSumi = true;
            // �i�C�t��������������
            for (int i = 0; i < Sprite_sumi.Length; i++)
            {
                Sprite_sumi[i].color = new Color(1, 1, 1, 5);
                SoundManager.instance.SEPlay("インクSE");
            }

        }
    }
}
