using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : MonoBehaviour
{
    [System.Serializable]
    public class MoveTF
    {
        public Vector2 position;
        public Vector2 size;
    }

    public enum BADGE
    {
        MISS,
        SPEED,
        MAX
    }

    [SerializeField]
    private MoveTF[] moveTFs = new MoveTF[(int)BADGE.MAX];

    private RectTransform rtf;

    [SerializeField, Range(1, 50)]
    private float moveSpeed = 10;

    [SerializeField]
    private float waittime = 0;

    void Awake()
    {
        rtf = gameObject.GetComponent<RectTransform>();
        SetMove(Badge.BADGE.SPEED);
    }

    public void SetMove(BADGE _type)
    {
        StartCoroutine(Move(_type));
    }

    private IEnumerator Move(BADGE _type)
    {
        yield return new WaitForSeconds(waittime);

        var cam = GameObject.Find("Main Camera");

        var nowTf = new MoveTF();
        nowTf.position = rtf.anchoredPosition;
        nowTf.size     = rtf.sizeDelta;

        var tgtTf = moveTFs[(int)_type];

        float param = 0;

        var wff = new WaitForEndOfFrame();

        while(param < 1)
        {
            rtf.anchoredPosition = Vector2.Lerp(nowTf.position, tgtTf.position, param);
            rtf.sizeDelta        = Vector2.Lerp(nowTf.size, tgtTf.size, param);

            param += 0.001f * moveSpeed;

            yield return wff;
        }

        yield break;
    }
}
