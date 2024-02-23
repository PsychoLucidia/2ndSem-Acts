using System.Collections;
using System.Collections.Generic;
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
        LeanTween.moveLocalX(attachedObj.gameObject, 0, 0.5f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(attachObjCG, 1, 0.5f).setEaseOutCubic().setIgnoreTimeScale(true);
    }
}
