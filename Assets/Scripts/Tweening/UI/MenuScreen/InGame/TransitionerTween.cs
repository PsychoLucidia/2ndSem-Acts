using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransitionerTween : MonoBehaviour
{
    public CanvasGroup transitionerCG;
    public CanvasGroup textCG;
    public TextMeshProUGUI textTMP;

    bool firstRun = false;

    void Awake()
    {
        GameObject rootObj = this.gameObject;
        transitionerCG = rootObj.transform.Find("BlackPanel").GetComponent<CanvasGroup>();
        textCG = rootObj.transform.Find("Text").GetComponent<CanvasGroup>();
        textTMP = rootObj.transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {

    }

    void OnEnable()
    {
        if (!firstRun)
        {
            TransitionTween(0, null);
            firstRun = true;
        }
    }

    public void TransitionTween(int option, string thisText)
    {
        switch (option)
        {
            case 0:
                transitionerCG.alpha = 1f;
                textCG.alpha = 0f;
                LeanTween.alphaCanvas(transitionerCG, 0f, 1f).setEaseOutCubic().setIgnoreTimeScale(true).setOnComplete(() => 
                {
                    this.gameObject.SetActive(false);
                });
                break;
            case 1:
                transitionerCG.alpha = 0f;
                textCG.alpha = 0f;
                textTMP.text = thisText;
                LeanTween.alphaCanvas(transitionerCG, 1f, 0.5f).setEaseInCubic().setIgnoreTimeScale(true).setOnComplete(() => 
                {
                    LeanTween.alphaCanvas(textCG, 1f, 0.5f).setEaseOutCubic().setIgnoreTimeScale(true).setOnComplete(() => 
                    {
                        LeanTween.alphaCanvas(textCG, 0f, 0.5f).setDelay(1.5f).setEaseInCubic().setIgnoreTimeScale(true);
                    });
                });
                break;
        }
    }
}
