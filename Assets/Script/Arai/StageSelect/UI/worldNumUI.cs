using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class worldNumUI : StageSelectUI
{
    [SerializeField]
    private Image numImage;

    public override void Activate(int _worldindex)
    {
        base.Activate(_worldindex);

        // ワールド番号でスプライトを変更
        numImage.color = new Color(_worldindex % 2, _worldindex / 2, 1 - _worldindex / 2,1);
    }
}
