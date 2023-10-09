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

        public static readonly float TUT_WAITTIME_DEF = 2.0f;

        public static readonly int TUT_NUM = 4;
        public static readonly int[] TUT_WORLD_NUM = new int[4]{0,0,1,1};
        public static readonly int[] TUT_STAGE_NUM = new int[4]{0,2,0,2};
        public static readonly string[] TUT_STAGE_NAME = new string[4]{"Tutrial01","Tutrial02","Tutrial03","Tutrial04"};
    }
}
