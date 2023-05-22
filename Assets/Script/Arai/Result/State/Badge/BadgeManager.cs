using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeManager : MonoBehaviour
{
    [SerializeField]
    private Badge badge;

    [SerializeField]
    private float waittime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator ShowBadge()
    {
        var speed = Instantiate(badge, transform);

        yield break;
    }
}
