using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconsTween : MonoBehaviour
{
    public Transform attachedObj;
    public CanvasGroup attachObjCG;

    void OnEnable()
    {
        attachedObj.localPosition = new Vector2(-30, 0);
        attachObjCG.alpha = 0;
        LeanTween.moveLocalX(attachedObj.gameObject, 0, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(attachObjCG, 1, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
    }

    public void MenuClose()
    {
        LeanTween.cancel(attachedObj.gameObject);
        LeanTween.cancel(attachObjCG.gameObject);
        attachedObj.localPosition = new Vector2(transform.localPosition.x, 0);
        attachObjCG.alpha = attachObjCG.alpha;
        LeanTween.moveLocalX(attachedObj.gameObject, -30, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(attachObjCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
    }
}
