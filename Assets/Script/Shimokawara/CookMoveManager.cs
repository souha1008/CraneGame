using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookMoveManager : MonoBehaviour
{
    public static CookMoveManager instance;


    public enum START_POS
    {
    FRONT,
    CENTER,
    BACK
    }  

    public START_POS StartPos;

    public GameObject[] GameStage;//最初は本作業場
    public int FazeTime = 18000;
    //public int[] FazeTimeArray;

    public int SPEED_CLEAR_TIME;

    public int FPS_Time = 0;

    public int START_STOP_FLAME;

    static int SYATTA_TIME = 20;
    public   int SYATTA_STOP_FLAME = 14;
    public GameObject Syatta;
    float SyattaMax;
    float SyattaMin = 1.385f;

    bool SyattaSleep = true;
    int SleepCnt = 0;

    int FazeNum = 0;
    public int MAX_FAZE_NUM;

    public GameObject ConvayorObj;
    public GameObject ConvayorModel;
    public GameObject PlaneModel;
    public bool[] isConvayor;

    float ConvayorModelPosY;
    MyButton myButton;
    ScoreData m_ScoreData;

    public int[] MAX_SCORE = new int[5];

    public int AllTime = 0;

    bool isSyatta = true;

    // Start is called before the first frame update
    void Start()
    {
        isSyatta = true;
        instance = this;
        myButton = GameObject.FindObjectOfType<MyButton>();
        ConvayorModelPosY = ConvayorModel.transform.localPosition.y;
        SyattaSleep = true;

        SleepCnt = -START_STOP_FLAME;
        m_ScoreData = GameObject.Find("Datas").GetComponent<ScoreData>();
        SyattaMax = Syatta.transform.localPosition.y;
        FPS_Time = 0;
        AllTime = 0;
        CovayorChange(isConvayor[0]);


        for(int i = 0; i < 5; i++)
        {
            //マックススコア
            m_ScoreData.SetMaxScore(i, MAX_SCORE[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR
        if(Input.GetButtonDown("Jump"))
        {
            ChangeSign();
            //NextScene();
            //Debug.Log("呼ばれた");
        }
#endif
    }

    private void FixedUpdate()
    {
        SleepCnt++;
        if(SleepCnt > SYATTA_STOP_FLAME)
        {
            SyattaSleep = false;
        }

        if(FazeNum >= MAX_FAZE_NUM)
        {
            //boolでわたす
            if(SPEED_CLEAR_TIME * 60 > AllTime)
            {
                m_ScoreData.SpeedClear= true;
            }
            else
            {
                m_ScoreData.SpeedClear = false;
            }

            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("ResultTest");
        }
        else
        {
            if (!SyattaSleep)
            {
                FPS_Time++;//時間加算

                
            }
            

        }


        

        if(FPS_Time > FazeTime * 60)
        {
            SyattaSleep = true;
            SleepCnt = 0;

            NextScene();
            SoundManager.instance.SELoopStop();
            //PlayerPosInitialize();
            AllTime += FPS_Time;
            FPS_Time = 0;

            Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, SyattaMin, Syatta.transform.localPosition.z);
        }
        //前後Nフレームで移動アニメーション
        else if(Mathf.Abs((FazeTime * 60 / 2) - FPS_Time)  > (FazeTime * 60 / 2) - SYATTA_TIME /*- STOP_TIME / 2*/)
        {
            isSyatta = true;

            if (FazeNum < MAX_FAZE_NUM)
            {
                float tempCnt = (FazeTime * 60 / 2) - Mathf.Abs((FazeTime * 60 / 2) - FPS_Time);//0への時間距離
                float Wariai = tempCnt / SYATTA_TIME;//割合

                float PosY = Wariai * (SyattaMax - SyattaMin) + SyattaMin;
                Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, PosY, Syatta.transform.localPosition.z);
            }
        }

        else
        {
            isSyatta = false;

            Syatta.transform.localPosition = new Vector3(Syatta.transform.localPosition.x, SyattaMax, Syatta.transform.localPosition.z);

            if (FazeNum == 0)
            {
                GameStartUI.instance.isFalse();
            }
            if (FazeNum == 4)
            {
                GameSetUI.instance.isTrue();
            }
        }
    }

    public void NextScene()
    {
        //DeleateKnife();
        PlayerPosInitialize();
        AddScore();
        MoveObject();
        myButton.ButtonReset();

        FazeNum++;
        if(FazeNum < isConvayor.Length)
        {
            CovayorChange(isConvayor[FazeNum]);
        }
        
    }

    void ConvayorOn()
    {
        ConvayorObj.SetActive(true);
        ConvayorModel.transform.position = new Vector3(ConvayorModel.transform.position.x, ConvayorModelPosY, ConvayorModel.transform.position.z);
        PlaneModel.transform.position = new Vector3(PlaneModel.transform.position.x, ConvayorModelPosY - 20, PlaneModel.transform.position.z);
    }

    void ConvayorOff()
    {
        ConvayorObj.SetActive(false);
        ConvayorModel.transform.position = new Vector3(ConvayorModel.transform.position.x, ConvayorModelPosY - 20, ConvayorModel.transform.position.z);
        PlaneModel.transform.position = new Vector3(PlaneModel.transform.position.x, ConvayorModelPosY , PlaneModel.transform.position.z);
    }
    

    void CovayorChange(bool flag)
    {
        if(flag)
        {
            ConvayorOn();
        }
        else
        {
            ConvayorOff();
        }

    }

    void AddScore()
    {
        GameObject[] Foods = GameObject.FindGameObjectsWithTag("Foods");
        for (int i = 0; i < Foods.Length; i++)//食べ物分
        {
            float thisNearMagni = 999999;//現状の最短距離
            int nearIndex = 0;
            Vector3 PosVector = Vector3.zero;//位置ベクトル

            for (int j = 0; j < GameStage.Length; j++)//ステージ数分
            {
                float Magni = (Foods[i].transform.position - GameStage[j].transform.position).magnitude;
                if (thisNearMagni > Magni)
                {
                    thisNearMagni = Magni;
                    nearIndex = j;
                    PosVector = Foods[i].transform.position - GameStage[j].transform.position;
                }
            }

            if (nearIndex == 0)//消すべき
            {
                if (Foods[i].GetComponent<CircleFoodsInterFace>().isClear)
                {
                    m_ScoreData.SetScore(FazeNum, m_ScoreData.GetScore(FazeNum) + 100);
                }
                //Destroy(Foods[i]);
            }

            //else//次の箇所へ行くべき
            //{
            //    Foods[i].transform.position = GameStage[nearIndex - 1].transform.position + PosVector;
            //}
        }





        GameObject[] FoodsSupport = GameObject.FindGameObjectsWithTag("FoodsSupport");
        for (int i = 0; i < FoodsSupport.Length; i++)//食べ物分
        {
            float thisNearMagni = 999999;//現状の最短距離
            int nearIndex = 0;
            Vector3 PosVector = Vector3.zero;//位置ベクトル

            for (int j = 0; j < GameStage.Length; j++)//ステージ数分
            {
                float Magni = (FoodsSupport[i].transform.position - GameStage[j].transform.position).magnitude;
                if (thisNearMagni > Magni)
                {
                    thisNearMagni = Magni;
                    nearIndex = j;
                    PosVector = FoodsSupport[i].transform.position - GameStage[j].transform.position;
                }
            }

            if (nearIndex == 0)//消すべき
            {
                if(FoodsSupport[i].GetComponent<FoodsSupportInterFace>())
                {
                    if (FoodsSupport[i].GetComponent<FoodsSupportInterFace>().isClear)
                    {
                        m_ScoreData.SetScore(FazeNum, m_ScoreData.GetScore(FazeNum) + 100);
                    }

                }
                
                //Destroy(FoodsSupport[i]);
            }

            //else//次の箇所へ行くべき
            //{
            //    FoodsSupport[i].transform.position = GameStage[nearIndex - 1].transform.position + PosVector;
            //}
        }
    }

    void MoveObject()
    {
        GameObject[] Foods = GameObject.FindGameObjectsWithTag("Foods");
        for (int i = 0; i < Foods.Length; i++)//食べ物分
        {
            float thisNearMagni = 999999;//現状の最短距離
            int nearIndex = 0;
            Vector3 PosVector = Vector3.zero;//位置ベクトル

            for (int j = 0; j < GameStage.Length; j++)//ステージ数分
            {
                float Magni = (Foods[i].transform.position - GameStage[j].transform.position).magnitude;
                if (thisNearMagni > Magni)
                {
                    thisNearMagni = Magni;
                    nearIndex = j;
                    PosVector = Foods[i].transform.position - GameStage[j].transform.position;
                }
            }

            if (nearIndex == 0)//消すべき
            {
                //if (Foods[i].GetComponent<CircleFoodsInterFace>().isClear)
                //{
                //    m_ScoreData.SetScore(FazeNum, m_ScoreData.GetScore(FazeNum) + 100);
                //}
                Destroy(Foods[i]);
            }

            else//次の箇所へ行くべき
            {
                Foods[i].transform.position = GameStage[nearIndex - 1].transform.position + PosVector;
            }
        }





        GameObject[] FoodsSupport = GameObject.FindGameObjectsWithTag("FoodsSupport");
        for (int i = 0; i < FoodsSupport.Length; i++)//食べ物分
        {
            float thisNearMagni = 999999;//現状の最短距離
            int nearIndex = 0;
            Vector3 PosVector = Vector3.zero;//位置ベクトル

            for (int j = 0; j < GameStage.Length; j++)//ステージ数分
            {
                float Magni = (FoodsSupport[i].transform.position - GameStage[j].transform.position).magnitude;
                if (thisNearMagni > Magni)
                {
                    thisNearMagni = Magni;
                    nearIndex = j;
                    PosVector = FoodsSupport[i].transform.position - GameStage[j].transform.position;
                }
            }

            if (nearIndex == 0)//消すべき
            {
                Destroy(FoodsSupport[i]);
            }

            else//次の箇所へ行くべき
            {
                FoodsSupport[i].transform.position = GameStage[nearIndex - 1].transform.position + PosVector;
            }
        }
    }

    void PlayerPosInitialize()
    {
        switch (StartPos)
        {
            case START_POS.FRONT:
                Player2.instance.transform.position = new Vector3(-18.7f, Player2.instance.transform.position.y, -5);
                break;

            case START_POS.CENTER:
                Player2.instance.transform.position = new Vector3(-18.7f, Player2.instance.transform.position.y, 5);
                break;

            case START_POS.BACK:
                Player2.instance.transform.position = new Vector3(-18.7f, Player2.instance.transform.position.y, 15);
                break;
        }

    }

    public void ChangeSign()
    {
        FPS_Time = FazeTime * 60 - SYATTA_TIME;
    }

    public int GetFazeNum()
    {
        return FazeNum;
    }

    public bool GetIsShatta()
    {
        return isSyatta;
    }

    //void DeleateKnife()
    //{
    //    Knife[] knives = GameObject.FindObjectsOfType<Knife>();
    //    for (int i = 0; i < knives.Length; i++)
    //    {
    //        Destroy(knives[i]);
    //    }
    //}

}

    
