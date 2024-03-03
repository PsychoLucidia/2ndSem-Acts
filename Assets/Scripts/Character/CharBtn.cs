using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharBtn : MonoBehaviour
{
    
    public TextMeshProUGUI btnCharName;
    public TextMeshProUGUI btnLvl;
    public Image btnIcon;

    // Set the data of the character buttons
    public void CharSetData(CharInfo charData)
    {
        btnCharName.text = charData.charName;
        btnLvl.text = charData.LVL.ToString();
        btnIcon.sprite = charData.charIcon;
    }
}
