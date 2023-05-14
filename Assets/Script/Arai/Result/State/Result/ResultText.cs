using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultText : ResultUI
{
    public void Action(ResultEnum.RESULT _result)
    {
        switch (_result)
        {
            case ResultEnum.RESULT.A:
                break;
            case ResultEnum.RESULT.B:
                break;
            case ResultEnum.RESULT.EXCELLENT:
                break;

            default: break;
        }

        manager.SetState(ResultStateEnum.STATE.WAIT);
    }
}
