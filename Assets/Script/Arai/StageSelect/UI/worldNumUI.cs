using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class worldNumUI : StageSelectUI
{
    [SerializeField]
    private TextMeshProUGUI world;

    public override void Activate(int _worldindex, int _indexmax)
    {
        base.Activate(_worldindex, _indexmax);

        // ワールド番号でスプライトを変更
        world.text = (_worldindex + 1).ToString();
    }
}
