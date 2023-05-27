using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int worldindex = 0;

    public int stageindex = 0;

    public int[] data = new int [Co.Const.STAGE_NUM * Co.Const.WORLD_NUM];
}
