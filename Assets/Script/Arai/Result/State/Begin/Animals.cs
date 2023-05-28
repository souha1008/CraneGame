using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : ResultObject
{
    [SerializeField]
    private GameObject[] animals = new GameObject[Co.Const.WORLD_NUM];

    [SerializeField]
    private GameObject[] badanimals = new GameObject[Co.Const.WORLD_NUM];

    private ScoreData data;

    public bool test = true;

    void Start()
    {
        if (!test)
        Instantiate(animals[GameObject.Find("Datas").GetComponent<ScoreData>().WorldIndex], transform);
        else
        {
            data = GameObject.Find("Datas").GetComponent<ScoreData>();
        Instantiate(animals[data.WorldIndex], transform);
        }
    }

    public void Bad()
    {
        if (!test)
        {
        var child = transform.GetChild(0);

        int animNum = child.childCount;

        for(int i = 0; i < animNum; ++i)
        {
            child.GetChild(i).gameObject.GetComponent<Animator>().SetBool("Bad", true);
        }
        }
        else
        {
            Destroy(transform.GetChild(0).gameObject);
        Instantiate(badanimals[data.WorldIndex], transform);
        }
    }
}
