using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroTween : MonoBehaviour
{   
    public TextMeshProUGUI text;
    public CanvasGroup canvasGroup;
    public SceneNavigation sceneNavigation;

    void Awake()
    {
        GameObject rootObj = this.gameObject;
        text = rootObj.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        canvasGroup = rootObj.transform.Find("Text").GetComponent<CanvasGroup>();

        sceneNavigation = GameObject.Find("SceneManager").GetComponent<SceneNavigation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        TweenIntro();
    }

    void TweenIntro()
    {
        canvasGroup.alpha = 0;
        LeanTween.alphaCanvas(canvasGroup, 1, 0.5f).setEaseOutCirc().setIgnoreTimeScale(true).setOnComplete(() =>
        {
           LeanTween.alphaCanvas(canvasGroup, 0, 0.5f).setDelay(3f).setEaseInCirc().setIgnoreTimeScale(true).setOnComplete(() => 
           {
                sceneNavigation.LoadScene(1);
           }); 
        });
    }
}