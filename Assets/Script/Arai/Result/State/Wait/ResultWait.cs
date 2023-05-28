using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultWait : ResultObject
{
    void Start()
    {
        var datas = GameObject.Find("Datas");
        var data = datas.GetComponent<ScoreData>();
        var save = datas.GetComponent<SaveManager>();

        int score = save.data.data[data.WorldIndex * Co.Const.STAGE_NUM + data.StageIndex];

        // カーソル移動フラグ
        bool newstage = true;
        if (data.WorldIndex * Co.Const.STAGE_NUM + data.StageIndex < save.data.worldindex * Co.Const.STAGE_NUM + save.data.stageindex)
            newstage = false;

        if (score < (int)data.FinalResult + 1)
        {
            save.data.data[data.WorldIndex * Co.Const.STAGE_NUM + data.StageIndex] = (int)data.FinalResult + 1;
        }

        // クリアしてたらIndexを進める
        if (newstage && data.FinalResult != ResultEnum.RESULT.BAD)
        {
            // ワールド内最後のステージだったら
            if (data.StageIndex + 1 == Co.Const.STAGE_NUM)
            {
                // 最後のワールドでなければ
                if (data.WorldIndex + 1 != Co.Const.WORLD_NUM)
                {
                    data.SetIndexs(data.WorldIndex + 1, 0);
                }
            }
            else
            {
                data.StageIndex += 1;
            }
            save.data.worldindex = data.WorldIndex;
            save.data.stageindex = data.StageIndex;
        }
        save.Save();
    }

    void Update()
    {
        if (Input.GetKeyDown("joystick button 0") || Input.GetMouseButton(0))
        {
            manager.Sound.SEPlay("戻るSE");
            GameObject.Find("SceneChange").GetComponent<SceneChange>().LoadScene("StageSelect");
        }
    }
}
