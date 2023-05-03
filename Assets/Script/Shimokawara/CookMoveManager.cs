using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMoveManager : MonoBehaviour
{

    public GameObject[] GameStage;//�ŏ��͖{��Ə�
    public int FazeTime = 20;

    public int FPS_Time = 0;

    static int SYATTA_TIME = 20;
    static int STOP_TIME = 14;
    public GameObject Syatta;
    float SyattaMax;
    float SyattaMin = 1.385f;

    bool SyattaSleep = false;
    int SleepCnt = 0;

    int FazeNum = 0;
    public int MAX_FAZE_NUM;

    ScoreData m_ScoreData;

    // Start is called before the first frame update
    void Start()
    {
        m_ScoreData = GameObject.Find("Datas").GetComponent<ScoreData>();
        SyattaMax = Syatta.transform.localPosition.y;
        FPS_Time = 0;
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR
        if(Input.GetButtonDown("Jump"))
        {
            FPS_Time = FazeTime * 60 - SYATTA_TIME;
            //NextScene();
            //Debug.Log("�Ă΂ꂽ");
        }
#endif
    }

    private void FixedUpdate()
    {
        SleepCnt++;
        if(SleepCnt > STOP_TIME)
        {
            SyattaSleep = false;
        }

        if(FazeNum >= MAX_FAZE_NUM)
        {
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("ResultTest");
        }
        else
        {
            if (!SyattaSleep)
            {
                FPS_Time++;//���ԉ��Z
            }
        }


        

        if(FPS_Time > FazeTime * 60)
        {
            SyattaSleep = true;
            SleepCnt = 0;

            NextScene();
            FPS_Time = 0;

            Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, SyattaMin, Syatta.transform.localPosition.z);
        }
        //�O��N�t���[���ňړ��A�j���[�V����
        else if(Mathf.Abs(( FazeTime * 60 / 2) - FPS_Time)  > (FazeTime * 60 / 2) - SYATTA_TIME /*- STOP_TIME / 2*/)
        {
            if (FazeNum < MAX_FAZE_NUM)
            {
                float tempCnt = (FazeTime * 60 / 2) - Mathf.Abs((FazeTime * 60 / 2) - FPS_Time);//0�ւ̎��ԋ���
                float Wariai = tempCnt / SYATTA_TIME;//����

                float PosY = Wariai * (SyattaMax - SyattaMin) + SyattaMin;
                Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, PosY, Syatta.transform.localPosition.z);
            }
        }

        else
        {
            Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, SyattaMax, Syatta.transform.localPosition.z);
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
                if(Foods[i].GetComponent<CircleFoodsInterFace>().isClear)
                {
                    m_ScoreData.SetScore(FazeNum, m_ScoreData.GetScore(FazeNum) + 100);
                }
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


        FazeNum++;
    }
}

    
