using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArtTween : MonoBehaviour //This is the class that handles the character art animation that would be displayed in the character screen
{
    public Transform charArtTrans;
    public CanvasGroup charArtCG;

    void OnEnable()
    {
        charArtTrans.localPosition = new Vector2(-70, 0); //Set the gameobject's position in the canvas
        charArtCG.alpha = 0; //Sets the Canvas Group alpha to 0 to make the object invisible

        //With the use of the library LeanTween, tween the gameobject's postition and canvas alpha to its declared value
        LeanTween.moveLocalX(charArtTrans.gameObject, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(charArtCG, 1, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
    }

    // Stops the tween of the gameobject
    void OnDisable()
    {
        LeanTween.cancel(charArtTrans.gameObject);
        LeanTween.cancel(charArtCG.gameObject);
    }

    //A function called by CharStatView.cs to tween the object upon clicking the character buttons
    public void ChangeArtTween() 
    {
        LeanTween.cancel(charArtTrans.gameObject);
        LeanTween.cancel(charArtCG.gameObject);
        charArtTrans.localPosition = new Vector2(-50, 0);
        charArtCG.alpha = 0;
        LeanTween.moveLocalX(charArtTrans.gameObject, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(charArtCG, 1, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
    }

    //Activated when the back button in the pause screen is pressed only when the character screen is active
    public void MenuClose()
    {
        LeanTween.cancel(charArtCG.gameObject);
        charArtCG.alpha = charArtCG.alpha;
        LeanTween.moveLocalX(charArtTrans.gameObject, 0, 1f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(charArtCG, 0, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true);
    }
}
