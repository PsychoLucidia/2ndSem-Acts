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

    public void SelectAction(int action)
    {
        switch (action)
        {
            case 0:
                buttonHandlerAlpha.alpha = 0f;
                buttonHandlerAlpha.interactable = false;
                LeanTween.alphaCanvas(buttonHandlerAlpha, 0f, 0.5f).setEaseInCubic().setIgnoreTimeScale(true);

                battleManager.PlayerAttack();
                break;
            case 1:
                break;
            default:
                break;    
        }
    }

}
