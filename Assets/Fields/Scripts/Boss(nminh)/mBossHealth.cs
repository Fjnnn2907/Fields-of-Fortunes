using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mBossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            animator.SetBool("IsHit", true);
            Invoke("ResetHit", 0.1f);
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Debug.Log("Boss is dead!");
        // Additional death logic, such as dropping loot or playing sound
        Destroy(gameObject, 1f); // Delay to allow death animation to play
    }

    void ResetHit()
    {
        animator.SetBool("IsHit", false);
    }
}
