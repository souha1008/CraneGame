using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : ResultObject
{
    [SerializeField]
    private GameObject[] animals = new GameObject[Co.Const.WORLD_NUM];

    void Start()
    {
        Instantiate(animals[GameObject.Find("Datas").GetComponent<ScoreData>().WorldIndex], transform);
    }

    public void Bad()
    {
        var child = transform.GetChild(0);

        int animNum = child.childCount;

        for(int i = 0; i < animNum; ++i)
        {
            //child.GetChild(i).gameObject.GetComponent<Animator>().Play("w");
            var a = child.GetChild(i).gameObject.GetComponent<Animator>();
        }
    }
}
