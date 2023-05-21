using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRUI : StageSelectUI
{
    public override void Activate(int _worldindex)
    {
        if (_worldindex != Co.Const.WORLD_NUM - 1)
            base.Activate(_worldindex);
        else
            base.Inactivate();
    }
}
