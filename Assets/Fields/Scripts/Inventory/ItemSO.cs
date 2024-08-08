using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatTochange stat = new StatTochange();
    public int amountToChangeStat;

    public AttributesTochange attributes = new AttributesTochange();
    public int amountToAttributes;

    public bool UseItem()
    {
        var PlayerHeal = GameObject.Find("PLAYER").GetComponent<PlayerManger>();
        var Player_Exp = GameObject.Find("PLAYER").GetComponent<PlayerExp>();
        if(stat == StatTochange.Heal)
        {
            
            if (PlayerHeal.currentHealth >= PlayerManger.Instance.maxHealth)
            {
                return false;
            }
            else
            {
                PlayerHeal.currentHealth = Mathf.Min(PlayerHeal.currentHealth + amountToChangeStat, PlayerManger.Instance.maxHealth);
                return true;
            }
        }
        if(stat == StatTochange.MaxHeal)
        {
            if (PlayerHeal.currentHealth >= PlayerManger.Instance.maxHealth)
            { 
                return false;
            }
            else
            {
                PlayerHeal.currentHealth = PlayerManger.Instance.maxHealth;
                PlayerHeal.currentHealth = Mathf.Min(PlayerHeal.currentHealth + amountToChangeStat, PlayerManger.Instance.maxHealth);
                return true;
            }
        }
        if(stat == StatTochange.Exp)
        {
            PlayerExp.Instance.AddExp(amountToChangeStat);
            return true;
        }
        
        return false;
    }

    public enum StatTochange
    {
        None,
        Heal,
        MaxHeal,
        Exp
    };

    public enum AttributesTochange
    {
        none,
        strength,

    };
}
