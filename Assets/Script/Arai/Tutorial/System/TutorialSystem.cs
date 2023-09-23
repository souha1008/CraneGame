using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSystem : MonoBehaviour
{
    [SerializeField]
    private TutModule[] modules;

    [SerializeField]
    private int index = 0;

    [SerializeField]
    private CircleFoodsInterFace food;
    public CircleFoodsInterFace Food
    {
        get => food;
    }

    [SerializeField]
    public Image ex;
    
    [SerializeField]
    public Image image;

    [SerializeField]
    private GameObject next;

    [SerializeField]
    private Image ok;

    [SerializeField]
    private Image finish;

    [SerializeField]
    private TutorialObserver observerOBJ;

    private TutorialObserver observer;

    [SerializeField]
    private TutorialManager manager;

    private ReadIsFade sc;
    private bool once = false;

    void Awake()
    {
        foreach(var mod in modules)
        {
            mod.System = this;
        }
    }

    void Start()
    {
        var obj = GameObject.Find("TutorialObserver(Clone)");

        if (!obj)   observer = Instantiate(observerOBJ);
        else        observer = obj.GetComponent<TutorialObserver>();
        
        sc = GameObject.Find("ReadIsFade").GetComponent<ReadIsFade>();
    }

    void Update()
    {
        if (!once && !sc.GetIsFade())
        {
            once = true;

            index = observer.Index;

            modules[index].enabled = true;
            modules[index].Init();

            if (index != 0)
            {
                Debug.Log("no zero");
                manager.TutStart();
            }
        }
    }

    /// <summary>
    /// モジュール変更(なければ終了)
    /// </summary>
    public void ChangeModule()
    {
        if (modules.Length == ++index)
        {
            Finish();
        }
        else
        {
            observer.Index = index;
            modules[index].enabled = true;
            modules[index].Init();
        }
    }

    public void NextActivate(bool _value)
    {
        next.SetActive(_value);
    }


    public void OKActivate(bool _value)
    {
        ok.gameObject.SetActive(_value);
    }

    public void FinishActivate(bool _value)
    {
        finish.gameObject.SetActive(_value);
    }

    public void Finish()
    {
        Debug.Log("modfin");
        Destroy(observer.gameObject);
    }
}
