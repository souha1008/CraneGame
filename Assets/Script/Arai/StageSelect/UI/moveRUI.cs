using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRUI : StageSelectUI
{
    public override void Activate(int _worldindex, int _indexmax)
    {
        if (_worldindex != _indexmax)
            base.Activate(_worldindex, _indexmax);
        else
            base.Inactivate();
    }
}
