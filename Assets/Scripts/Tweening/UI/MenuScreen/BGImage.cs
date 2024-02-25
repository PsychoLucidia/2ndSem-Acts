using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGImage : MonoBehaviour
{
    public CanvasGroup imageCG;

    void OnEnable()
    {
        imageCG.alpha = 0;
        LeanTween.alphaCanvas(imageCG, 1, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true);
    }

    void OnDisable()
    {
        LeanTween.cancel(imageCG.gameObject);
    }

    public void MenuClose()
    {
        LeanTween.cancel(imageCG.gameObject);
        imageCG.alpha = imageCG.alpha;
        LeanTween.alphaCanvas(imageCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
    }
}
