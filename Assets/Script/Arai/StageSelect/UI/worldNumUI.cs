using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class worldNumUI : StageSelectUI
{
    [SerializeField]
    private TextMeshProUGUI world;

    public override void Activate(int _worldindex)
    {
        base.Activate(_worldindex);

        // ワールド番号でスプライトを変更
        world.text = (_worldindex + 1).ToString();
    }
}
