using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanvas : MonoBehaviour
{
    public static EnemyCanvas Instance { get; private set; }

    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private Image Hp;

    private int _healthMax;

    private float targetFillAmount;
    public float updateSpeed = 0.5f;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _healthMax = 100;
        healthSlider.maxValue = _healthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp.fillAmount != targetFillAmount)
        {
            Hp.fillAmount = Mathf.MoveTowards(Hp.fillAmount, targetFillAmount, updateSpeed * Time.deltaTime);

        }
    }

    public void Show(int currentHealth)
    {
        _healthMax = currentHealth;
        healthSlider.maxValue = _healthMax;
    }

    public void SetShowUI()
    {
        if (!this)
        {
            return;
        }
        //StartCoroutine(setActive());
    }
    public void SetHealth(int Health, int MaxHealth)
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdateHealthUI(Health, MaxHealth);
    }
    public void UpdateHealthUI(int Health, int MaxHealth)
    {
        targetFillAmount = (float)Health / MaxHealth;
        //HPtext.text = Health.ToString() + " / " + MaxHealth.ToString();

    }
}
