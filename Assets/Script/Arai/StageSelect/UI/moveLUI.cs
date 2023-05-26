using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLUI : StageSelectUI
{
    public override void Activate(int _worldindex, int _indexmax)
    {
        if (_worldindex != 0)
            base.Activate(_worldindex, _indexmax);
        else
            base.Inactivate();
    }
}
