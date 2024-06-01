using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Character Info", menuName ="ScriptableObjects/Char Info")]
public class CharInfo : ScriptableObject
{
    [Header("Character Info")]
    public string charName;
    public int LVL;
    public int HP;
    public int maxHP;
    public int MP;
    public int maxMP;
    public int ATK;
    public int DEF;
    public int SPD;
    public bool isPlayer = true;

    [Header("Character Assets")]
    public Sprite characterArt;
    public Sprite charIcon;
    public RuntimeAnimatorController animatorController;
    public GameObject characterPrefab;

    [Header("Animation Settings")]
    public float attackAnimLength;

    [Header("Basic Attacks")]
    public string[] basicAttackMessages;

    public bool ThisTakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true;
        }
        return false;
    }
}


