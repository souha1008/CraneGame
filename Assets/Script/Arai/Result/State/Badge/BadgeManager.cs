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
        var miss = Instantiate(badge, transform);
        miss.SetMove(Badge.BADGE.MISS);

        yield return new WaitForSeconds(waittime);
        
        var speed = Instantiate(badge, transform);
        speed.SetMove(Badge.BADGE.SPEED);

        // 表記をえくされんとに？

        manager.SetState(ResultStateEnum.STATE.WAIT);

        yield break;
    }
}
