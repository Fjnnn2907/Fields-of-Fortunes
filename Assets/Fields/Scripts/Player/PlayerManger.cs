using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class PlayerManger : MonoBehaviour
{
    public static PlayerManger Instance { get; private set; }
    public int currentHealth = 0;
    public int maxHealth = 20;

    [SerializeField]
    //private Enemy enemy;


    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        PlayerHealth.Instance.SetHealth(currentHealth, maxHealth);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerExp.Instance.AddExp(100);
            PopUPManager.Instance.ShowExp("100", this.transform);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            //enemy.TakeDamage(5);
        }
        //if (enemy == null) return;
    }
    public void TakeDmae(int Damege)
    {
        PopUPManager.Instance.ShowDamege(Damege.ToString(), this.transform);
        currentHealth -= Damege;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
}
