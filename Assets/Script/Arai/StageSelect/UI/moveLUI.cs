using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLUI : StageSelectUI
{
    public override void Activate(int _worldindex)
    {
        if (_worldindex != 0)
            base.Activate(_worldindex);
        else
            base.Inactivate();
    }
}
