using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class worldNumUI : StageSelectUI
{
    [SerializeField]
    private Image numImage;

    [SerializeField]
    private Numbers numbers;

    public override void Activate(int _worldindex)
    {
        base.Activate(_worldindex);

        // ワールド番号でスプライトを変更
        numImage.sprite = numbers.numbers[_worldindex + 1];
    }
}
