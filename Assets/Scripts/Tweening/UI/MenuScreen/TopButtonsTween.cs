using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopButtonsTween : MonoBehaviour
{
    public Transform topButtonsTrans;
    public CanvasGroup topButtonsCG;

    void OnEnable()
    {
        topButtonsTrans.localPosition = new Vector2(0, -20);
        topButtonsCG.alpha = 0;
        LeanTween.moveLocalY(topButtonsTrans.gameObject, 0, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(topButtonsCG, 1, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
    }

    void OnDisable()
    {
        LeanTween.cancel(topButtonsTrans.gameObject);
        LeanTween.cancel(topButtonsCG.gameObject);
    }

    public void MenuClose()
    {
        LeanTween.cancel(topButtonsTrans.gameObject);
        LeanTween.cancel(topButtonsCG.gameObject);
        topButtonsTrans.localPosition = new Vector2(0, transform.localPosition.y);
        topButtonsCG.alpha = topButtonsCG.alpha;
        LeanTween.moveLocalY(topButtonsTrans.gameObject, transform.localPosition.y, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(topButtonsCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
    }
}
