using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMoveManager : MonoBehaviour
{

    public GameObject[] GameStage;//�ŏ��͖{��Ə�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            NextScene();
            Debug.Log("�Ă΂ꂽ");
        }
    }



    public void NextScene()
    {
        GameObject[] Foods = GameObject.FindGameObjectsWithTag("Foods");
        for(int i = 0; i < Foods.Length;i++)//�H�ו���
        {
            float thisNearMagni = 999999;//����̍ŒZ����
            int nearIndex = 0;
            Vector3 PosVector = Vector3.zero;//�ʒu�x�N�g��

            for(int j =0; j < GameStage.Length; j++)//�X�e�[�W����
            {
                float Magni = (Foods[i].transform.position - GameStage[j].transform.position).magnitude;
                if (thisNearMagni > Magni )
                {
                    thisNearMagni = Magni;
                    nearIndex = j;
                    PosVector = Foods[i].transform.position - GameStage[j].transform.position;
                }
            }

            if(nearIndex == 0)//�����ׂ�
            {
                Destroy(Foods[i]);
            }

            else//���̉ӏ��֍s���ׂ�
            {
                Foods[i].transform.position = GameStage[nearIndex - 1].transform.position + PosVector;
            }
        }





        GameObject[] FoodsSupport = GameObject.FindGameObjectsWithTag("FoodsSupport");
        for (int i = 0; i < FoodsSupport.Length; i++)//�H�ו���
        {
            float thisNearMagni = 999999;//����̍ŒZ����
            int nearIndex = 0;
            Vector3 PosVector = Vector3.zero;//�ʒu�x�N�g��

            for (int j = 0; j < GameStage.Length; j++)//�X�e�[�W����
            {
                float Magni = (FoodsSupport[i].transform.position - GameStage[j].transform.position).magnitude;
                if (thisNearMagni > Magni)
                {
                    thisNearMagni = Magni;
                    nearIndex = j;
                    PosVector = FoodsSupport[i].transform.position - GameStage[j].transform.position;
                }
            }

            if (nearIndex == 0)//�����ׂ�
            {
                Destroy(FoodsSupport[i]);
            }

            else//���̉ӏ��֍s���ׂ�
            {
                FoodsSupport[i].transform.position = GameStage[nearIndex - 1].transform.position + PosVector;
            }
        }
    }
}
