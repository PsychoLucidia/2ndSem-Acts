using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconsTween : MonoBehaviour //The class that will handle the animation of the character buttons
{
    public Transform attachedObj;
    public CanvasGroup attachObjCG;

    void OnEnable()
    {
        attachedObj.localPosition = new Vector2(-30, 0);
        attachObjCG.alpha = 0;

        //With the use of the library LeanTween, tween the gameobject's postition and canvas alpha to its declared value
        LeanTween.moveLocalX(attachedObj.gameObject, 0, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(attachObjCG, 1, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true);
    }

    public void MenuClose() //Activated when the back button in the pause screen is pressed only when the character screen is active
    {
        LeanTween.cancel(attachedObj.gameObject);
        LeanTween.cancel(attachObjCG.gameObject);
        attachedObj.localPosition = new Vector2(transform.localPosition.x, 0);
        attachObjCG.alpha = attachObjCG.alpha;
        LeanTween.moveLocalX(attachedObj.gameObject, -30, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(attachObjCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
    }
}
