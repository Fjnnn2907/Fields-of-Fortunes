using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyHealthh : MonoBehaviour
{
    public static EnemyHealthh Instance { get; private set; }
    public GameObject healthCanvas;
    public Image Hp;
    public TextMeshProUGUI HPtext;

    private float targetFillAmount;
    public float updateSpeed = 0.5f;

   // private bool showUI = false;

    private void Awake()
    {
        Instance = this;
    }
    //private void Start()
    //{
    //    healthCanvas.SetActive(false);
    //}
    private void Update()
    {
        if (Hp.fillAmount != targetFillAmount)
        {
            Hp.fillAmount = Mathf.MoveTowards(Hp.fillAmount, targetFillAmount, updateSpeed * Time.deltaTime);
            
        }

    }
    //public void SetShowUI()
    //{
    //    if (!this)
    //    {
    //        return;
    //    }
    //    //StartCoroutine(setActive());
    //}
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

    //IEnumerator setActive()
    //{
    //    healthCanvas.SetActive(true);
    //    yield return new WaitForSeconds(4f);
    //    healthCanvas.SetActive(false);
    //}

}
