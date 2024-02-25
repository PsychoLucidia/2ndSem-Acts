using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArtTween : MonoBehaviour
{
    public Transform charArtTrans;
    public CanvasGroup charArtCG;

    void OnEnable()
    {
        charArtTrans.localPosition = new Vector2(-70, 0);
        charArtCG.alpha = 0;
        LeanTween.moveLocalX(charArtTrans.gameObject, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(charArtCG, 1, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
    }

    void OnDisable()
    {
        LeanTween.cancel(charArtTrans.gameObject);
        LeanTween.cancel(charArtCG.gameObject);
    }

    public void ChangeArtTween()
    {
        LeanTween.cancel(charArtTrans.gameObject);
        LeanTween.cancel(charArtCG.gameObject);
        charArtTrans.localPosition = new Vector2(-50, 0);
        charArtCG.alpha = 0;
        LeanTween.moveLocalX(charArtTrans.gameObject, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(charArtCG, 1, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
    }

    public void MenuClose()
    {
        LeanTween.cancel(charArtCG.gameObject);
        charArtCG.alpha = charArtCG.alpha;
        LeanTween.moveLocalX(charArtTrans.gameObject, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(charArtCG, 0, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true);
    }
}
