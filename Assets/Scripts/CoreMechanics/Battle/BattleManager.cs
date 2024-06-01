using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleManager : MonoBehaviour
{
    [Header("Scene Manager")]
    public SceneNavigation sceneNavigation;
    public TransitionerTween transitionerTween;

    [Header("Action Manager")]
    public ActionButtonsHandler actionButtonsHandler;
    public ActionTextHandler actionTextHandler;

    [Header("Lifebars")]
    public LifebarController playerLifebar;
    public LifebarController enemyLifebar;

    [Header("Managers")]
    public CharManager charManager;
    public EnemyManager enemyManager;

    [Header("Animators")]
    public Animator playerAnimator;
    public Animator enemyAnimator;

    [Header("States")]
    public BattleState state;

    [Header("Units")]
    public UnitData player;
    public EnemyUnitData enemy;

    [Header("GameObjects and Transforms")]
    public GameObject actionButtonsHandlerGO;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;
    
    // Start is called before the first frame update

    void Awake()
    {
        sceneNavigation = GameObject.Find("SceneManager").GetComponent<SceneNavigation>();

        GameObject rootObj = GameObject.Find("MainCanvas");
        transitionerTween = rootObj.transform.Find("Transitioner").GetComponent<TransitionerTween>();
    }

    void Start()
    {
        StartCoroutine(StartState());
        state = BattleState.START;
    }

    void InstantiatePrefabs()
    {
        Instantiate(playerPrefab, playerSpawnPoint);
        Instantiate(enemyPrefab, enemySpawnPoint);
    }

    public void AttachAnimator(Animator animator, bool isThisPlayer, bool isThisEnemy)
    {
        if (isThisPlayer)
        {
            playerAnimator = animator;
        }

        if (isThisEnemy)
        {
            enemyAnimator = animator;
        }
    }

    public void AttachUnit(UnitData unit)
    {
        player = unit;
    }

    public void AttachEnemy(EnemyUnitData unit)
    {
        enemy = unit;
    }

    void Update()
    {
        
    }

    IEnumerator StartState()
    {
        enemyLifebar.StartAsEnemy(enemyManager, 0, false, true);
        playerLifebar.StartAsPlayer(charManager, 0, true, false);

        InstantiatePrefabs();

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
        yield break;
    }

    void PlayerTurn()
    {
        actionButtonsHandlerGO.SetActive(true);

    }

    void EnemyTurn()
    {
        int enemyChoice = Random.Range(0, 2);
        switch (enemyChoice)
        {
            case 0:
                StartCoroutine(EnemyAttack());
                break;
            case 1:
                StartCoroutine(EnemyHeal());
                break;
        }
    }

    public void OnPlayerAction(int action)
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        actionButtonsHandler.SelectAction(action);
    }

    public void PlayerAttack()
    {
        StartCoroutine(PlayerAttackIE());
    }

    public void PlayerHeal()
    {
        StartCoroutine(PlayerHealIE());
    }

    IEnumerator EnemyAttack()
    {
        actionTextHandler.EnemyAction(enemyManager.enemyInfo[0].basicAttackMessages[0]);

        yield return new WaitForSeconds(0.5f);
        enemyAnimator.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(enemyManager.enemyInfo[0].attackAnimLength);
        enemyAnimator.SetBool("IsAttacking", false);

        bool isDead = player.ThisTakeDamage(enemyManager.enemyInfo[0].ATK);

        if (isDead)
        {
            playerAnimator.SetBool("IsDead", true);
            state = BattleState.LOST;

            yield return new WaitForSeconds(1.7f);
            transitionerTween.gameObject.SetActive(true);
            transitionerTween.TransitionTween(1, "You were Defeated");

            yield return new WaitForSeconds(3f);
            sceneNavigation.LoadScene(1);
        }
        else
        {
            playerAnimator.SetBool("IsHit", true);
            yield return new WaitForSeconds(0.01f);
            playerAnimator.SetBool("IsHit", false);
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        




    }

    IEnumerator EnemyHeal()
    {
        actionTextHandler.EnemyAction(enemyManager.enemyInfo[0].basicAttackMessages[1]);

        yield return new WaitForSeconds(0.5f);
        bool isDead = enemy.ThisHeal((enemyManager.enemyInfo[0].DEF * 0.5f) + (enemyManager.enemyInfo[0].ATK * 0.5f));

        if (isDead)
        {
            playerAnimator.SetBool("IsDead", true);
            state = BattleState.LOST;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

        yield break;
    }
    
    IEnumerator PlayerAttackIE()
    {
        actionTextHandler.PlayerAction(charManager.charInfo[0].basicAttackMessages[0]);

        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(charManager.charInfo[0].attackAnimLength);
        playerAnimator.SetBool("IsAttacking", false);
        bool isDead = enemy.ThisTakeDamage(charManager.charInfo[0].ATK);


        if (isDead)
        {
            enemyAnimator.SetBool("IsDead", true);
            state = BattleState.WON;

            yield return new WaitForSeconds(1.7f);
            transitionerTween.gameObject.SetActive(true);
            transitionerTween.TransitionTween(1, "Battle Over");

            yield return new WaitForSeconds(3f);
            sceneNavigation.LoadScene(1);
        }
        else
        {
            enemyAnimator.SetBool("IsHit", true);
            yield return new WaitForSeconds(0.01f);
            enemyAnimator.SetBool("IsHit", false);
            yield return new WaitForSeconds(1f);
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }

        yield break;
    }

    IEnumerator PlayerHealIE()
    {
        actionTextHandler.PlayerAction(charManager.charInfo[0].basicAttackMessages[1]);

        yield return new WaitForSeconds(0.5f);

        bool isDead = player.ThisHeal((charManager.charInfo[0].DEF * 0.5f) + (charManager.charInfo[0].ATK * 0.5f));

        if (isDead)
        {
            state = BattleState.WON;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }
        
        yield break;
    }

}
