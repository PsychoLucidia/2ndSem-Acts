using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CharStatView : MonoBehaviour
{
    public CharacterInfoTween characterInfoTween;
    public CharacterArtTween characterArtTween;
    public CharManager charManager;

    public TextMeshProUGUI textName;
    public TextMeshProUGUI textHP;
    public TextMeshProUGUI textMP;
    public TextMeshProUGUI textLVL;
    public TextMeshProUGUI textATK;
    public TextMeshProUGUI textDEF;
    public TextMeshProUGUI textSPD;
    public Image charImage;

    private bool IsStarted = false;

    void Start()
    {
        InitCharStatData();
        IsStarted = true;
        charImage.preserveAspect = true;
    }

    void OnEnable()
    {
        if (IsStarted)
        {
            InitCharStatData();
        }
    }

    public void SetStatData(CharInfo charInfo)
    {
        characterInfoTween.ChangeInfoTween();
        characterArtTween.ChangeArtTween();
        textName.text = charInfo.charName;
        textHP.text = charInfo.HP.ToString() + " / " + charInfo.maxHP.ToString();
        textMP.text = charInfo.MP.ToString() + " / " + charInfo.maxMP.ToString();
        textLVL.text = charInfo.LVL.ToString();
        textATK.text = charInfo.ATK.ToString();
        textDEF.text = charInfo.DEF.ToString();
        textSPD.text = charInfo.SPD.ToString();
        charImage.sprite = charInfo.characterArt;
    }

    public void InitCharStatData() //Display the first data in the Character Manager array
    {
        CharInfo initDataDisplay = charManager.charInfo[0]; //Get the data of the first array
        textName.text = initDataDisplay.charName;
        textHP.text = initDataDisplay.HP.ToString() + " / " + initDataDisplay.maxHP.ToString();
        textMP.text = initDataDisplay.MP.ToString() + " / " + initDataDisplay.maxMP.ToString();
        textLVL.text = initDataDisplay.LVL.ToString();
        textATK.text = initDataDisplay.ATK.ToString();
        textDEF.text = initDataDisplay.DEF.ToString();
        textSPD.text = initDataDisplay.SPD.ToString();
        charImage.sprite = initDataDisplay.characterArt;

    }

}
