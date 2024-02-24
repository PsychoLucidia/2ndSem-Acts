using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharBtn : MonoBehaviour
{
    
    public TextMeshProUGUI btnCharName;
    public TextMeshProUGUI btnLvl;

    public void CharSetData(CharInfo charData)
    {
        btnCharName.text = charData.charName;
        btnLvl.text = charData.LVL.ToString();
    }
}
