using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonsHandler : MonoBehaviour
{
    [Header("Components")]
    public CanvasGroup buttonHandlerAlpha;
    public Transform buttonHandlerTransform;
    public BattleManager battleManager;

    void OnEnable()
    {
        ShowButtons();
    }

    public void ShowButtons()
    {
        buttonHandlerAlpha.alpha = 0f;
        buttonHandlerAlpha.interactable = true;
        LeanTween.alphaCanvas(buttonHandlerAlpha, 1f, 0.5f).setEaseOutCubic().setIgnoreTimeScale(true);
    }

    public void HideButtons()
    {
        buttonHandlerAlpha.alpha = 1f;
        buttonHandlerAlpha.interactable = false;
        LeanTween.alphaCanvas(buttonHandlerAlpha, 0f, 0.3f).setEaseInCubic().setIgnoreTimeScale(true).setOnComplete(() => 
        {
            this.gameObject.SetActive(false);
        });
    }

    public void SelectAction(int action)
    {
        switch (action)
        {
            case 0:
                HideButtons();
                battleManager.PlayerAttack();
                break;
            case 1:
                HideButtons();
                battleManager.PlayerHeal();
                break;
            default:
                break;    
        }

    }

}
