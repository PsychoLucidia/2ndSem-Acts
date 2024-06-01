using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifebarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject charHPMP;
    [SerializeField] private Transform charHPMPTrans;
    [SerializeField] private Vector2 charHPMPPos;

    [Header("Images")]
    [SerializeField] private Image hpBar;
    [SerializeField] private Image hpBarBack;
    [SerializeField] private Image mpBar;
    [SerializeField] private Image mpBarBack;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI mpText;
    [SerializeField] private TextMeshProUGUI lvlText;

    [Header("Stats")]
    public string charName;
    public float currentHP;
    public float maxHP;
    public float currentMP;
    public float maxMP;
    public float currentLVL;

    [Header("Character Type")]
    public bool isPlayer;
    public bool isEnemy;

    void Awake()
    {
        
    }

    public void StartAsPlayer(CharManager charManager, int charIndex, bool isPlayer, bool isEnemy)
    {
        this.isPlayer = isPlayer;
        this.isEnemy = isEnemy;
        currentHP = charManager.charInfo[charIndex].HP;
        maxHP = charManager.charInfo[charIndex].maxHP;
        currentMP = charManager.charInfo[charIndex].MP;
        maxMP = charManager.charInfo[charIndex].maxMP;
    }

    public void StartAsEnemy(EnemyManager enemyManager, int enemyIndex, bool isPlayer, bool isEnemy)
    {
        this.isPlayer = isPlayer;
        this.isEnemy = isEnemy;
        currentHP = enemyManager.enemyInfo[enemyIndex].HP;
        maxHP = enemyManager.enemyInfo[enemyIndex].maxHP;
        currentLVL = enemyManager.enemyInfo[enemyIndex].enemyLevel;
        charName = enemyManager.enemyInfo[enemyIndex].enemyName;
    }

    // Start is called before the first frame update. Upon start, set all the neccessary components needed by the script.
    void Start()
    {
        if (isPlayer)
        {
            charHPMP = this.gameObject;
            charHPMPTrans = charHPMP.GetComponent<Transform>();
            charHPMPPos = charHPMPTrans.localPosition;

            Transform hpMain = charHPMP.transform.Find("HPBG");
            hpBar = hpMain.Find("HPBar").GetComponent<Image>();
            hpBarBack = hpMain.Find("HPBarBack").GetComponent<Image>();
            hpText = hpMain.Find("HPText").GetComponent<TextMeshProUGUI>();

            Transform mpMain = charHPMP.transform.Find("MPBG");
            mpBar = mpMain.Find("MPBar").GetComponent<Image>();
            mpBarBack = mpMain.Find("MPBarBack").GetComponent<Image>();
            mpText = mpMain.Find("MPText").GetComponent<TextMeshProUGUI>();            
        }

        if (isEnemy)
        {
            charHPMP = this.gameObject;
            charHPMPTrans = charHPMP.GetComponent<Transform>();
            charHPMPPos = charHPMPTrans.localPosition;

            Transform hpMain = charHPMP.transform.Find("HPBG");
            hpBar = hpMain.Find("HPBar").GetComponent<Image>();
            hpBarBack = hpMain.Find("HPBarBack").GetComponent<Image>();
            lvlText = charHPMP.transform.Find("LVLText").GetComponent<TextMeshProUGUI>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Clamp currentHP and currentMP between 0 and maxHP and maxMP.
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        currentMP = Mathf.Clamp(currentMP, 0, maxMP);

        if (isEnemy)
        {
            lvlText.text = "Lv. " + currentLVL.ToString() + " | " + charName;
        }

    }

    void FixedUpdate()
    {
        if (charHPMP != null)
        {
            SetHP();
            
            if (isPlayer)
            {
                SetMP();
            }
            
            SetText();
        }
    }

    public void SetHP()
    {
        float hpFFill = hpBar.fillAmount;
        float hpBFill = hpBarBack.fillAmount;
        float hpRatio = currentHP / maxHP;

        if (hpRatio < hpFFill)
        {
            if (isPlayer)
            {
                StartCoroutine(DamageShake());
            }
            LeanTween.cancel(hpBarBack.gameObject);
            LeanTween.cancel(hpBar.gameObject);

            hpBar.fillAmount = hpRatio;
            hpBarBack.color = new Color32(255, 100, 0, 255);

            LeanTween.value(hpBarBack.gameObject, hpBFill, hpRatio, 1f).setEaseOutCubic().setIgnoreTimeScale(true).setOnUpdate(TweenHPBack);
        }

        if (hpRatio > hpBFill)
        {
            LeanTween.cancel(hpBarBack.gameObject);
            LeanTween.cancel(hpBar.gameObject);

            hpBarBack.fillAmount = hpRatio;
            hpBarBack.color = new Color32(0, 195, 0, 255);

            LeanTween.value(hpBar.gameObject, hpFFill, hpRatio, 0.7f).setIgnoreTimeScale(true).setOnUpdate(TweenHP);
        }
    }

    public void SetMP()
    {
        float mpFFill = mpBar.fillAmount;
        float mpBFill = mpBarBack.fillAmount;
        float mpRatio = currentMP / maxMP;
        
        if (mpRatio < mpFFill)
        {
            LeanTween.cancel(mpBarBack.gameObject);
            LeanTween.cancel(mpBar.gameObject);

            mpBar.fillAmount = mpRatio;
            mpBarBack.color = new Color32(112, 183, 255, 255);

            LeanTween.value(mpBarBack.gameObject, mpBFill, mpRatio, 1f).setEaseOutCubic().setIgnoreTimeScale(true).setOnUpdate(TweenMPBack);
        }

        if (mpRatio > mpBFill)
        {
            LeanTween.cancel(mpBarBack.gameObject);
            LeanTween.cancel(mpBar.gameObject);

            mpBarBack.fillAmount = mpRatio;
            mpBarBack.color = new Color32(182, 219, 255, 255);

            LeanTween.value(mpBar.gameObject, mpFFill, mpRatio, 0.7f).setIgnoreTimeScale(true).setOnUpdate(TweenMP);
        }
    }

    public void SetText()
    {
        if (isPlayer)
        {
            hpText.text = currentHP.ToString() + " / " + maxHP.ToString();
            mpText.text = currentMP.ToString() + " / " + maxMP.ToString();
        }
    }

    void TweenHPBack(float value)
    {
        hpBarBack.fillAmount = value;
    }
    
    void TweenHP(float value)
    {
        hpBar.fillAmount = value;
    }

    void TweenMPBack(float value)
    {
        mpBarBack.fillAmount = value;
    }

    void TweenMP(float value)
    {
        mpBar.fillAmount = value;
    }

    IEnumerator DamageShake()
    {
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-10f, 10f), 15f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-10f, 10f), -15f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-8f, 8f), 10f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-7f, 7f), -10f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-6f, 6f), 6f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-5f, 5f), -6f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-4f, 4f), 4f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-3f, 3f), -4f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-2f, 2f), 2f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos + new Vector2(Random.Range(-1f, 1f), -2f);
        yield return new WaitForSecondsRealtime(0.03f);
        charHPMPTrans.localPosition = charHPMPPos;
        yield break;
    }

    public void TakeDMG(int dmg)
    {
        currentHP -= dmg;
    }

    public void TakeHeal()
    {
        currentHP += 10f;
    }

    public void ConsumeMP()
    {
        currentMP -= 10f;
    }

    public void RestoreMP()
    {
        currentMP += 10f;
    }
}
