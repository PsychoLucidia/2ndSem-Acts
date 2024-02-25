using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonsTween : MonoBehaviour
{
    public CanvasGroup actBtnCG;

    void OnEnable()
    {
        actBtnCG.alpha = 0;
        LeanTween.alphaCanvas(actBtnCG, 1, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
    }

    void OnDisable()
    {
        LeanTween.cancel(actBtnCG.gameObject);
    }

    public void MenuClose()
    {
        LeanTween.cancel(actBtnCG.gameObject);
        actBtnCG.alpha = actBtnCG.alpha;
        LeanTween.alphaCanvas(actBtnCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
    }
}
