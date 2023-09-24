using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Co
{
    public class Const : ScriptableObject
    {
        public static readonly short FAZE_NUM = 5;    // フェーズ数

        public static readonly float SCORE_SPEED_MAG = 0.001f;

        public static readonly float TITLEOBJ_OFFSET_Y = 1;
        public static readonly float TITLEOBJ_MOVEVOLUM = 0.05f;

        public static readonly int WORLD_NUM = 4;
        public static readonly int STAGE_NUM = 5;

        public static readonly Color CLEAR = new Color(1, 1, 1, 0);
    }
}
