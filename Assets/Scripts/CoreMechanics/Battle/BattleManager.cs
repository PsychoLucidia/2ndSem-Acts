using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleManager : MonoBehaviour
{
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

    [Header("GameObjects and Transforms")]
    public GameObject actionButtonsHandlerGO;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerSpawnPoint;
    public Transform enemySpawnPoint;
    
    // Start is called before the first frame update

    void Awake()
    {

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

    void Update()
    {
        
    }

    IEnumerator StartState()
    {
        // enemyLifebar.StartAsEnemy(enemyManager, 0, false, true);
        // playerLifebar.StartAsPlayer(charManager, 0, true, false);

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

    IEnumerator PlayerAttackIE()
    {
        actionTextHandler.PlayerAction(charManager.charInfo[0].basicAttackMessages[0]);

        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("IsAttacking", true);

        yield return new WaitForSeconds(charManager.charInfo[0].attackAnimLength);
        playerAnimator.SetBool("IsAttacking", false);

        bool isDead = enemyManager.enemyInfo[0].ThisTakeDamage(charManager.charInfo[0].ATK);
        enemyLifebar.StartAsEnemy(enemyManager, 0, false, true);


        if (isDead)
        {
            state = BattleState.WON;
        }
        else
        {
            state = BattleState.ENEMYTURN;
        }

        yield break;
    }
}
