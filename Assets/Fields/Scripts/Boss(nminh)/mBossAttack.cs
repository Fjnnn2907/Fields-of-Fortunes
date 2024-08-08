using UnityEngine;

public class mBossAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 2f;
    private float lastAttackTime = 0f;
    public int damage = 10;
    private Animator animator;
    public Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        animator.SetBool("IsAttacking", true);
        // Implement damage application logic here
        Debug.Log("Boss attacks!");
    }

    public void AttackDistance()
    {
        if (Vector2.Distance(transform.position, player.position) <= attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }
}
