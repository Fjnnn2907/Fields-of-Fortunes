using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    public Image Hp;
    public TextMeshProUGUI HPtext;

    private float targetFillAmount;
    public float updateSpeed = 0.5f;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Hp.fillAmount != targetFillAmount)
        {
            Hp.fillAmount = Mathf.MoveTowards(Hp.fillAmount, targetFillAmount, updateSpeed * Time.deltaTime);
        }
    }
    public void SetHealth(int Health, int MaxHealth)
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdateHealthUI(Health, MaxHealth);
    }
    public void UpdateHealthUI(int Health, int MaxHealth)
    {
        targetFillAmount = (float)Health / MaxHealth;
        HPtext.text = Health.ToString() + " / " + MaxHealth.ToString();
    }


}
