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
        var speed = Instantiate(badge, transform);
        speed.SetMove(Badge.BADGE.SPEED);

        yield return new WaitForSeconds(waittime);

        var miss = Instantiate(badge, transform);
        miss.SetMove(Badge.BADGE.MISS);

        // 表記をえくされんとに？

        manager.SetState(ResultStateEnum.STATE.WAIT);

        yield break;
    }
}
