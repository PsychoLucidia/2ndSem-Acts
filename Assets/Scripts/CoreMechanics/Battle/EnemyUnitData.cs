using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitData : MonoBehaviour
{
    [Header("References")]
    public EnemyManager enemyManager;
    public BattleManager battleManager;
    public LifebarController lifebar;
    public Animator animator;

    [Header("Data")]
    public string charName;
    public int HP;
    public int MaxHP;
    public int MP;
    public int MaxMP;

    public int LVL;

    public int ATK;
    public int DEF;
    public int SPD;

    [Header("Animation Data")]
    public float attackAnimLength;
    public RuntimeAnimatorController animController;

    [Header("Messages")]
    public string[] basicAttackMessages;

    [Header("Booleans")]
    public bool isPlayer;
    public bool isEnemy;

    void Awake()
    {
        GameObject initObj2 = GameObject.Find("EnemyManager");
        enemyManager = initObj2.GetComponent<EnemyManager>();

        GameObject initObj3 = GameObject.Find("BattleManager");
        battleManager = initObj3.GetComponent<BattleManager>();

        isEnemy = enemyManager.enemyInfo[0].isEnemy;
        battleManager.AttachEnemy(this);

        ComponentReference();
        LifebarSetData();
        SetDataToLifebar();
        SetAnimController();
    }

    void ComponentReference()
    {
        charName = enemyManager.enemyInfo[0].enemyName;
        HP = enemyManager.enemyInfo[0].HP;
        MaxHP = enemyManager.enemyInfo[0].maxHP;
        LVL = enemyManager.enemyInfo[0].enemyLevel;
        ATK = enemyManager.enemyInfo[0].ATK;
        DEF = enemyManager.enemyInfo[0].DEF;
        attackAnimLength = enemyManager.enemyInfo[0].attackAnimLength;
        basicAttackMessages = enemyManager.enemyInfo[0].basicAttackMessages;

        animController = enemyManager.enemyInfo[0].animatorController;
    }

    void SetDataToLifebar()
    {
        if (isEnemy)
        {
            lifebar.isEnemy = isEnemy;
        }

        lifebar.charName = charName;
        lifebar.currentHP = HP;
        lifebar.maxHP = MaxHP;
        lifebar.currentMP = MP;
        lifebar.maxMP = MaxMP;
        lifebar.currentLVL = LVL;
        
    }

    void LifebarSetData()
    {
        GameObject initObj = GameObject.Find("MainCanvas");
        Transform enemies = initObj.transform.Find("Enemies");
        lifebar = enemies.transform.Find("Enemy1").GetComponent<LifebarController>();
    }

    void SetAnimController()
    {
        Transform prefab = this.gameObject.transform.Find("Sprite");
        animator = prefab.transform.GetComponent<Animator>();
        animator.runtimeAnimatorController = this.animController;
        battleManager.AttachAnimator(animator, isPlayer, isEnemy);
    }

    void Update()
    {
        SetDataToLifebar();
    }

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

    public bool ThisHeal(float heal)
    {
        HP += Mathf.RoundToInt(heal);

        if (HP <= 0)
        {
            HP = 0;
            return true;
        }
        return false;
    }
}
