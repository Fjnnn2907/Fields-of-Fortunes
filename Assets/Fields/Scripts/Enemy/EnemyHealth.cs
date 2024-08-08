using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private PlayerManger player;
    public int damage;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManger>();

    }
    public void AttackPlayer()
    {
        player.TakeDmae(damage);
    }


}
