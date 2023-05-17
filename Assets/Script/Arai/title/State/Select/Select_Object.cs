using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Select_Object : MonoBehaviour
{
    [SerializeField]
    private UnityEvent pushed;
    [SerializeField]
    private Object_Activate activate;
    [SerializeField]
    private Object_Activate inactivate;

    private Object_Activate nowEvent = null;
    private float parameter = 0;

    private Vector3 defPosition;

    void Start()
    {
        defPosition = gameObject.transform.localPosition;
    }

    void Update()
    {
        if (nowEvent)
        {
            nowEvent.Method(this);
        }
    }

    /// <summary>
    /// 押された動作
    /// </summary>
    public void PushAction()
    {
        pushed.Invoke();
    }

    /// <summary>
    /// 活性化
    /// </summary>
    public void Activate()
    {
        nowEvent = activate;
    }

    /// <summary>
    /// 非活性化
    /// </summary>
    public void InActivate()
    {
        nowEvent = inactivate;
    }

    public void Move(float _param)
    {
        bool fin = false;
        
        parameter += _param;
        if (parameter <= 0)
        {
            parameter = 0;
            fin = true;
        }
        else if (parameter >= 1)
        {
            parameter = 1;
            fin = true;
        }

        gameObject.transform.localPosition = defPosition + new Vector3(0, Co.Const.TITLEOBJ_OFFSET_Y * parameter, 0);

        if (fin) nowEvent = null;
    }

    public void FinishEvent()
    {
        nowEvent = null;
    }
}
