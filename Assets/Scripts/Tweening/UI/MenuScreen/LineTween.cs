using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class LineTween : MonoBehaviour
{
    public Transform lineObj;
    public CanvasGroup lineObjCG;

    void OnEnable()
    {
        lineObj.localPosition = new Vector2(20, 0);
        lineObjCG.alpha = 0;
        LeanTween.moveLocalX(lineObj.gameObject, 0, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(lineObjCG, 1, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
    }

    public void LineClose()
    {
        LeanTween.cancel(lineObj.gameObject);
        LeanTween.cancel(lineObjCG.gameObject);
        lineObj.localPosition = new Vector2(transform.localPosition.x, 0);
        lineObjCG.alpha = lineObjCG.alpha;
        LeanTween.moveLocalX(lineObj.gameObject, 20, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(lineObjCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
    }
}
