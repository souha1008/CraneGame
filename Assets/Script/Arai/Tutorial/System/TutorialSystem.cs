using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSystem : MonoBehaviour
{
    [SerializeField]
    private TutModule[] modules;

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

    void Awake()
    {
        foreach(var mod in modules)
        {
            mod.System = this;
        }
    }

    void Start()
    {
        modules[index].enabled = true;
        modules[index].Init();
    }

    void Update()
    {

    }

    /// <summary>
    /// モジュール変更(なければ終了)
    /// </summary>
    public void ChangeModule()
    {
        if (modules.Length == ++index)
        {
            Debug.Log("modfin");
        }
        else
        {
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
}
