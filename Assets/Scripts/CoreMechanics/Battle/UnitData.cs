using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    [Header("References")]
    public CharManager charManager;
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
        GameObject initObj = GameObject.Find("CharacterManager");
        charManager = initObj.GetComponent<CharManager>();

        GameObject initObj3 = GameObject.Find("BattleManager");
        battleManager = initObj3.GetComponent<BattleManager>();

        isPlayer = charManager.charInfo[0].isPlayer;

        ComponentReference();
        LifebarSetData();
        SetDataToLifebar();
        SetAnimController();
    }

    void ComponentReference()
    {
        charName = charManager.charInfo[0].charName;
        HP = charManager.charInfo[0].HP;
        MaxHP = charManager.charInfo[0].maxHP;
        MP = charManager.charInfo[0].MP;
        MaxMP = charManager.charInfo[0].maxMP;
        LVL = charManager.charInfo[0].LVL;
        ATK = charManager.charInfo[0].ATK;
        DEF = charManager.charInfo[0].DEF;
        SPD = charManager.charInfo[0].SPD;
        attackAnimLength = charManager.charInfo[0].attackAnimLength;
        basicAttackMessages = charManager.charInfo[0].basicAttackMessages;

        animController = charManager.charInfo[0].animatorController;
    }

    void SetDataToLifebar()
    {
        if (isPlayer)
        {
            lifebar.isPlayer = isPlayer;
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
        Transform characters = initObj.transform.Find("Characters");
        lifebar = characters.transform.Find("Character1").GetComponent<LifebarController>();
    }

    void SetAnimController()
    {
        Transform prefab = this.gameObject.transform.Find("Sprite");
        animator = prefab.gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = this.animController;
        battleManager.AttachAnimator(animator, isPlayer, isEnemy);
    }

    void Start()
    {
        
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
}
