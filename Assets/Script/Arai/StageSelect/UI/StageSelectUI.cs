using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    virtual public void Activate(int _worldindex, int _indexmax)
    {
        gameObject.SetActive(true);
    }

    virtual public void Inactivate()
    {
        gameObject.SetActive(false);
    }
}
