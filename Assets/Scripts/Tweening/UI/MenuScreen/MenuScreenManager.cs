using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenManager : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject pauseMenuMainObj;
    public GameObject inGameObj;

    [Header("Character Screen Tweens")]
    public LineTween lineTween;
    public CharacterIconsTween characterIconsTween;
    public CharacterInfoTween characterInfoTween;

    [Header("Pause Main Objects")]
    public BGImage bGImage;
    public TopButtonsTween topButtonsTween;
    public ActionButtonsTween actionButtonsTween;

    [Header("Buttons")]
    public Button pauseMenuBackBtn;
    public Button inGameMenuBtn;

    public void CloseMenu()
    {
        StartCoroutine(CloseMenuIEnum());
    }

    public void OpenMenu()
    {
        StartCoroutine(OpenMenuIEnum());
    }

    IEnumerator CloseMenuIEnum()
    {
        lineTween.LineClose();
        characterIconsTween.MenuClose();
        characterInfoTween.MenuClose();
        bGImage.MenuClose();
        topButtonsTween.MenuClose();
        actionButtonsTween.MenuClose();

        inGameMenuBtn.interactable = true;
        yield return new WaitForSecondsRealtime(0.3f);
        pauseMenuMainObj.SetActive(false);
        inGameObj.SetActive(true);
    }

    IEnumerator OpenMenuIEnum()
    {
        pauseMenuMainObj.SetActive(true);
        inGameObj.SetActive(false);

        pauseMenuBackBtn.interactable = true;
        yield return new WaitForSecondsRealtime(0.3f);
    }
}
