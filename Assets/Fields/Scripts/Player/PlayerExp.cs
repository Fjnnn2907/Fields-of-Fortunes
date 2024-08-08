using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public static PlayerExp Instance { get; private set; }

    [SerializeField] Image expBar;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject levelUpEffect;
    private float targetFillAmount;
    public float updateSpeed = 0.5f;

    private int currentExp;
    private int currentLevel;
    private int expToNextLevel;
    private Transform playerPos;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        currentExp = 0;
        currentLevel = 1;
        expToNextLevel = CalculateExpToNextLevel(currentLevel);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateExpUI();
    }
    private void Update()
    {
        if (expBar.fillAmount != targetFillAmount)
        {
            expBar.fillAmount = Mathf.MoveTowards(expBar.fillAmount, targetFillAmount, updateSpeed * Time.deltaTime);
        }
    }
    public void AddExp(int exp)
    {
        currentExp += exp;
        if (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
        UpdateExpUI();
    }

    private void LevelUp()
    {
        
        currentExp -= expToNextLevel;
        currentLevel++;
        PlayerManger.Instance.maxHealth += 250; //((int)(PlayerManger.Instance.maxHealth * 0.1f));
        PlayerManger.Instance.currentHealth = PlayerManger.Instance.maxHealth;
        PlayerAttack.Instance.Damege += ((int)(PlayerAttack.Instance.Damege * 0.2f));
        PotentialManager.Instance.SetPotential(2);
        SetPlayerPos();
        expToNextLevel = CalculateExpToNextLevel(currentLevel);
        UpdateExpUI();
        SetSkillCount();
    }

    private int CalculateExpToNextLevel(int level)
    {
        
        return level * 100;
    }

    private void UpdateExpUI()
    {
        targetFillAmount = (float)currentExp / expToNextLevel;
        levelText.text = currentLevel.ToString();
    }

    public void SetEXP(int exp, int maxExp)
    {
        currentExp = exp;
        expToNextLevel = maxExp;
        UpdateExpUI();
    }

    public void SetSkillCount()
    {
        if(currentLevel >= 2) SkillManager.Instance.skillCount[0].SetActive(true);
        if(currentLevel >= 4) SkillManager.Instance.skillCount[1].SetActive(true);
    }

    public void SetPlayerPos()
    { 
        Instantiate(levelUpEffect, playerPos.position, Quaternion.identity);
    }
    public int getCurrentEXP()
    {
        return currentExp;
    }
}