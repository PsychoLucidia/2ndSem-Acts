using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTextHandler : MonoBehaviour
{
    public ActionTextTween actionTextTween;
    public Transform actionTextTweenObjTrans;
    public GameObject actionTextTweenObj;

    void Awake()
    {
        actionTextTweenObjTrans = this.gameObject.transform.Find("ActionTextHandler");
        actionTextTweenObj = GameObject.Find("ActionTextHandler");
        actionTextTween  = actionTextTweenObjTrans.GetComponent<ActionTextTween>();
    }

    public void PlayerAction(string actionText)
    {
        actionTextTweenObj.SetActive(true);
        actionTextTween.PlayerAction(actionText);
    }

    public void EnemyAction(string actionText)
    {
        actionTextTweenObj.SetActive(true);
        actionTextTween.EnemyAction(actionText);
    }
}
