using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGImage : MonoBehaviour
{
    public CanvasGroup imageCG;

    // Function to handle the enabling of the object, setting the alpha to 0 and then animating the alpha to 1 using LeanTween.
    void OnEnable()
    {
        imageCG.alpha = 0;
        LeanTween.alphaCanvas(imageCG, 1, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true);
    }

    // Function called when the behaviour becomes disabled or inactive.
    void OnDisable()
    {
        LeanTween.cancel(imageCG.gameObject);
    }

    public void MenuClose() // Activated when the back button in the pause screen is pressed only when the character screen is active
    {
        LeanTween.cancel(imageCG.gameObject);
        imageCG.alpha = imageCG.alpha;
        LeanTween.alphaCanvas(imageCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
    }
}
