using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Character Info", menuName ="ScriptableObjects/Char Info")]
public class CharInfo : ScriptableObject
{
    public string charName;
    public int LVL;
    public int HP;
    public int maxHP;
    public int MP;
    public int maxMP;
    public int ATK;
    public int DEF;
    public int SPD;
}
