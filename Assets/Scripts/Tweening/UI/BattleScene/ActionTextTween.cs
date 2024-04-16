using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionTextTween : MonoBehaviour
{
    private GameObject thisObj;
    private Transform thisObjTransform;
    private CanvasGroup actionTextMainCG;
    private CanvasGroup actionTextBGCG;
    private Image actionTextBGColor;
    private TextMeshProUGUI actionTextTMP;
    private Transform actionLineTrans;
    
    void Start()
    {
        thisObj = this.gameObject;
        thisObjTransform = thisObj.GetComponent<Transform>();
        actionTextMainCG = thisObj.GetComponent<CanvasGroup>();
        actionTextBGCG = thisObj.transform.Find("ActionBG").gameObject.GetComponent<CanvasGroup>();
        actionTextBGColor = thisObj.transform.Find("ActionBG").gameObject.GetComponent<Image>();
        actionTextTMP = thisObj.transform.Find("ActionText").gameObject.GetComponent<TextMeshProUGUI>();
        actionLineTrans = thisObj.transform.Find("ActionLine").gameObject.GetComponent<Transform>();
        thisObj.SetActive(false);
    }

    public void PlayerAction()
    {
        LeanTween.cancel(thisObj);
        LeanTween.cancel(actionTextMainCG.gameObject);
        LeanTween.cancel(actionLineTrans.gameObject);
        LeanTween.cancel(actionTextBGCG.gameObject);

        thisObjTransform.localPosition = new Vector2(0, 480);
        actionTextMainCG.alpha = 0;
        actionLineTrans.localScale = new Vector3(0, 1, 1);
        actionTextBGCG.alpha = 0;
        actionTextBGColor.color = new Color32(0, 145, 227, 255);

        LeanTween.moveLocalY(thisObjTransform.gameObject, 490, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(actionTextBGCG, 1, 0.2f).setEaseOutCubic().setDelay(0.2f).setIgnoreTimeScale(true);
        LeanTween.scaleX(actionLineTrans.gameObject, 1, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(actionTextMainCG, 0.7f, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true).setOnComplete(() =>
        {
            LeanTween.alphaCanvas(actionTextBGCG, 0.5f, 1.3f).setEaseInCubic().setDelay(0.2f).setIgnoreTimeScale(true).setOnComplete(() => 
            {
                LeanTween.alphaCanvas(actionTextMainCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
                LeanTween.alphaCanvas(actionTextBGCG, 0, 0.2f).setEaseInCubic().setIgnoreTimeScale(true);
                LeanTween.scaleX(actionLineTrans.gameObject, 0.7f, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
                LeanTween.alphaCanvas(actionTextBGCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true).setOnComplete(() => 
                {
                    thisObj.SetActive(false);
                });
            });
        });
    }

    public void EnemyAction()
    {
        LeanTween.cancel(thisObj);
        LeanTween.cancel(actionTextMainCG.gameObject);
        LeanTween.cancel(actionLineTrans.gameObject);
        LeanTween.cancel(actionTextBGCG.gameObject);

        thisObjTransform.localPosition = new Vector2(0, 480);
        actionTextMainCG.alpha = 0;
        actionLineTrans.localScale = new Vector3(0, 1, 1);
        actionTextBGCG.alpha = 0;
        actionTextBGColor.color = new Color32(160, 0, 0, 255);

        LeanTween.moveLocalY(thisObjTransform.gameObject, 490, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(actionTextBGCG, 1, 0.2f).setEaseOutCubic().setDelay(0.2f).setIgnoreTimeScale(true);
        LeanTween.scaleX(actionLineTrans.gameObject, 1, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true);
        LeanTween.alphaCanvas(actionTextMainCG, 0.7f, 0.3f).setEaseOutCubic().setIgnoreTimeScale(true).setOnComplete(() =>
        {
            LeanTween.alphaCanvas(actionTextBGCG, 0.5f, 1.3f).setEaseInCubic().setDelay(0.2f).setIgnoreTimeScale(true).setOnComplete(() => 
            {
                LeanTween.alphaCanvas(actionTextMainCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
                LeanTween.alphaCanvas(actionTextBGCG, 0, 0.2f).setEaseInCubic().setIgnoreTimeScale(true);
                LeanTween.scaleX(actionLineTrans.gameObject, 0.7f, 0.3f).setEaseInCubic().setIgnoreTimeScale(true);
                LeanTween.alphaCanvas(actionTextBGCG, 0, 0.3f).setEaseInCubic().setIgnoreTimeScale(true).setOnComplete(() => 
                {
                    thisObj.SetActive(false);
                });
            });
        });
    }
}
