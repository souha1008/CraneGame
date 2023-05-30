using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeManager : ResultUI
{
    [SerializeField]
    private Badge badge;

    [SerializeField]
    private float waittime;

    void Start()
    {
        StartCoroutine(ShowBadge());
    }

    private IEnumerator ShowBadge()
    {
        var data = GameObject.Find("Datas").GetComponent<ScoreData>();
        bool ex = false;

        if (data.SpeedClear)
        {
            var speed = Instantiate(badge, transform);
            speed.SetMove(Badge.BADGE.SPEED);
            manager.Sound.SEPlay("ボーナス獲得SE");

            ex = true;
            yield return new WaitForSecondsRealtime(waittime);
        }

        if (data.GetScoreParcent() >= 1)
        {
            var miss = Instantiate(badge, transform);
            miss.SetMove(Badge.BADGE.MISS);
            manager.Sound.SEPlay("ボーナス獲得SE");
        }
        else ex = false;

        // 表記をえくせれんとに
        if (ex)
        {
            yield return new WaitForSecondsRealtime(waittime);

            transform.parent.gameObject.transform.Find("ResultText(Clone)").GetComponent<ShowResult>().Excellent();
        }

        manager.SetState(ResultStateEnum.STATE.WAIT);

        yield break;
    }
}
