using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookTut : MonoBehaviour
{
    [System.Serializable]
    struct Cook
    {
        public int phaseNum;
        public Sprite[] sprites;
    }

    [SerializeField]
    private Image image01, image02, bg;

    [SerializeField]
    private List<Cook> cooks = new List<Cook>();

    private bool flip = true;

    [SerializeField]
    private float imageChangeSpeed, imageShowTime;
    
    [SerializeField, ReadOnly]
    
    private float param = 0;

    private float addparam;

    private int countMax, count = 0;

    [SerializeField, ReadOnly]
    private int index = 0;

    private IEnumerator routine;

    private bool activate = false;
    private string bgmtitle;
    private bool once = false;

    void Start()
    {
        addparam = 1 / imageChangeSpeed * 0.16f;

        routine = MyUpdate();
        
        image01.color = new Color(1,1,1,0);
        image02.color = new Color(1,1,1,0);
        bg.color = new Color(1,1,1,0);

        bgmtitle = GameObject.FindAnyObjectByType<BGMPlayer>().selectplayTitle;
    }

    void Update()
    {
        if (!once)
        {
            if (SoundManager.instance.CheckPlayBGM(bgmtitle))
                once = true;
        }
        else
        {
            // if フェーズ切り替わり
            if (!activate && CookMoveManager.instance.GetFazeNum() == cooks[index].phaseNum)
            {
                WakeUp();
                activate = true;
            }
            else if (activate && CookMoveManager.instance.GetFazeNum() != cooks[index].phaseNum)
            {
                ShutDown();
                activate = false;
                if (index == cooks.Count)
                    this.gameObject.SetActive(false);
            }
        }
    }

    private void WakeUp()
    {
        image01.sprite = cooks[index].sprites[0];
        image01.color = new Color(1,1,1,1);
        image02.color = new Color(1,1,1,0);
        bg.color = new Color(1,1,1,1);

        if (cooks[index].sprites.Length != 1)
        {
            image02.sprite = cooks[index].sprites[1];
            countMax = cooks[index].sprites.Length;
            ++count;
            StartCoroutine(routine);
        }
    }

    private void ShutDown()
    {
        StopCoroutine(routine);
        routine = null;
        routine = MyUpdate();
        
        image01.color = new Color(1,1,1,0);
        image02.color = new Color(1,1,1,0);
        bg.color = new Color(1,1,1,0);
        
        ++index;
        param = 0;
        count = 0;
    }

    private IEnumerator MyUpdate()
    {
        WaitForSecondsRealtime change = new WaitForSecondsRealtime(1 / imageChangeSpeed * 0.16f);
        WaitForSecondsRealtime show   = new WaitForSecondsRealtime(imageShowTime);

        bool fin;

        while(true)
        {
            fin = false;
            yield return show;

            while(true)
            {
                if (flip)
                    fin = Fade01();
                else
                    fin = Fade02();

                if (fin)
                    break;
                else
                    yield return change;
            }
        }

        yield break;
    }

    private bool Fade01()
    {
        param += addparam;
        if (param >= 1f)
        {
            param = 1f;
        }

        image01.color = new Color(1,1,1,1-param);
        image02.color = new Color(1,1,1,param);

        if (param >= 1f)
        {
            Debug.Log("01消えた");

            flip = !flip;

            if (++count >= countMax)
                count = 0;
            
            image01.sprite = cooks[index].sprites[count];

            return true;
        }
        return false;
    }

    private bool Fade02()
    {
        param -= addparam;
        if (param <= 0f)
        {
            param = 0f;
        }

        image01.color = new Color(1,1,1,1-param);
        image02.color = new Color(1,1,1,param);

        if (param <= 0f)
        {
            Debug.Log("02消えた");

            flip = !flip;

            if (++count >= countMax)
                count = 0;
            
            image02.sprite = cooks[index].sprites[count];

            return true;
        }
        return false;
    }
}
