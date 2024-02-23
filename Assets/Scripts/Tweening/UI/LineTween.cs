using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTween : MonoBehaviour
{
    public Transform lineObj;
    public CanvasGroup lineObjCG;

    void OnEnable()
    {
        lineObj.localPosition = new Vector2(20, 0);
        lineObjCG.alpha = 0;
        LeanTween.moveLocalX(lineObj.gameObject, 0, 0.5f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(lineObjCG, 1, 0.5f).setEaseOutCubic().setIgnoreTimeScale(true);
    }
}
