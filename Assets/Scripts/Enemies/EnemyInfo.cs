using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "Enemy Info", menuName ="ScriptableObjects/Enemy Info")]
public class EnemyInfo : ScriptableObject
{
    [Header("Enemy Stats")]
    public string enemyName;
    public int enemyLevel;
    public int maxHP;
    public int HP;
    public int ATK;
    public int DEF;
    public int expToGive;
    public bool isEnemy = true;

    [Header("Enemy Assets")]
    public RuntimeAnimatorController animatorController;
    public GameObject enemyPrefab;

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
