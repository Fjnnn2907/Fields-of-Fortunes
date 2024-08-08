using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mBoss : MonoBehaviour
{
    public GameObject thisGameObject;
    public GameObject player; // The player Transform
    public float speed = 2f; // Movement speed
    public float attackRange = .5f; // Attack range
    public float attackCooldown = 2f; // Cooldown between attacks
    public int maxHealth = 100; // Max health
    public int damage = 10; // Damage dealt to the player

    [SerializeField] private float lastAttackTime = 0f; // Time of last attack
    [SerializeField] private int currentHealth; // Current health
    [SerializeField] private Animator animator; // Animator component
    [SerializeField] private bool isDead = false; // Flag to check if boss is dead
    private PlayerManger manager;
    
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        manager = player.GetComponent<PlayerManger>();
    }

    void Update()
    {
        if (isDead) return;

        MoveTowardsPlayer();
        HandleAttack();
    }

    void MoveTowardsPlayer()
    {
        animator.SetBool("isRunning",true);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void HandleAttack()
    {
        if (GetDistance() <= attackRange /*&& Time.deltaTime > lastAttackTime + attackCooldown*/)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        animator.SetBool("IsAttacking", true);
        //Them am thanh cac thu vao
        Debug.Log("Boss attacks!");
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; 

        currentHealth -= damage;
        animator.SetBool("IsHit", true);
        Invoke("ResetHit", 0.1f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return; 

        isDead = true;
        animator.SetTrigger("Die");
        Debug.Log("Boss is dead!");
        //Them am thanh cac thu vao
        //Destroy(gameObject, 1f); 
        thisGameObject.SetActive(false);
    }

    void ResetHit()
    {
        animator.SetBool("IsHit", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            manager.currentHealth--;
        }
    }

    private float GetDistance()
    {
        float range = Vector2.Distance(transform.position, player.transform.position);
        return range;
    }
}