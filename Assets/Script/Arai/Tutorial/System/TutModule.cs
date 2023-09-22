using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutModule : MonoBehaviour
{
    [SerializeField, Header("自分用")]
    protected Sprite myex;
    
    [SerializeField]
    protected Sprite myimage;

    [SerializeField]
    protected float waittime = Co.Const.TUT_WAITTIME_DEF;

    protected TutorialSystem system;
    public  TutorialSystem System
    {
        set => system = value;
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void Init()
    {
        // 各ImageにSpriteをセット
        if (myex)
        {
            system.ex.gameObject.SetActive(true);
            system.ex.sprite = myex;
            system.ex.SetNativeSize();
        }
        else
        {
            system.ex.gameObject.SetActive(false);
        }
        if (myimage)
        {
            system.image.gameObject.SetActive(true);
            system.image.sprite = myimage;
        }
        else
        {
            system.image.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 動作終了
    /// </summary>
    protected void CallFin()
    {
        system.ChangeModule();
    }

    private IEnumerator Finish()
    {
        var time = new WaitForSecondsRealtime(waittime);

        system.OKActivate(true);

        yield return time;

        system.OKActivate(false);

        CallFin();

        yield break; 
    }

    /// <summary>
    /// OK表示
    /// </summary>
    protected void Fin()
    {
        StartCoroutine(Finish());
        this.enabled = false;
    }
}
