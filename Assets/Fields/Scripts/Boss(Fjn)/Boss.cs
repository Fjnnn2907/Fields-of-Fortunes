using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1f;
    public float skillRange = 3f;
    public float skillCooldown = 5f;
    public float Hp = 100;

    protected float skillTimer = 0f;
    protected Transform player;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected BossState bossState = BossState.Idle;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ChangeState(BossState.Idle);
    }

    protected virtual void Update()
    {
        switch (bossState)
        {
            case BossState.Idle:
                if (Vector2.Distance(transform.position, player.position) < attackRange)
                {
                    ChangeState(BossState.Attacking);
                }
                else if (Vector2.Distance(transform.position, player.position) < skillRange)
                {
                    ChangeState(BossState.UsingSkill);
                }
                else
                {
                    Move();
                }
                break;
            case BossState.Moving:
                Move();
                if (Vector2.Distance(transform.position, player.position) < attackRange)
                {
                    ChangeState(BossState.Attacking);
                }
                else if (Vector2.Distance(transform.position, player.position) < skillRange)
                {
                    ChangeState(BossState.UsingSkill);
                }
                break;
            case BossState.Attacking:
                Attack();
                break;
            case BossState.UsingSkill:
                UseSkill();
                break;
            case BossState.Hit:
                Hit();
                break;
            case BossState.Dead:
                Dead();
                break;
        }

        skillTimer -= Time.deltaTime;
    }

    protected virtual void Move()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            ChangeState(BossState.Moving);
        }
    }

    public virtual void Attack()
    {
        ChangeState(BossState.Attacking);
    }

    public virtual void UseSkill()
    {
        if (skillTimer <= 0)
        {
            skillTimer = skillCooldown;
        }
        ChangeState(BossState.Moving); 
    }

    public virtual void Hit()
    {
        ChangeState(BossState.Hit);
 
        Invoke("EndHit", .5f); 
    }

    public virtual void EndHit()
    {
        if (bossState == BossState.Hit)
        {
            ChangeState(BossState.Idle);
        }
    }

    public virtual void Dead()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject, 1.2f);
            ChangeState(BossState.Dead);
            return;
        }
        
    }

    public virtual void ChangeState(BossState newState)
    {
        if (bossState == BossState.Idle)
            animator.SetBool("idle", false);
        else if (bossState == BossState.Moving)
            animator.SetBool("run", false);
        else if (bossState == BossState.Attacking)
            animator.SetBool("attack", false);
        else if (bossState == BossState.UsingSkill)
            animator.SetBool("skill", false);
        else if (bossState == BossState.Dead)
            animator.SetBool("deah", false);
        else if (bossState == BossState.Hit)
            animator.SetBool("hit", false);

        bossState = newState;

        if (bossState == BossState.Idle)
            animator.SetBool("idle", true);
        else if (bossState == BossState.Moving)
            animator.SetBool("run", true);
        else if (bossState == BossState.Attacking)
            animator.SetBool("attack", true);
        else if (bossState == BossState.UsingSkill)
            animator.SetBool("skill", true);
        else if (bossState == BossState.Dead)
            animator.SetBool("deah", true);
        else if (bossState == BossState.Hit)
            animator.SetBool("hit", true);
    }

    public virtual void TakeDamage(int damage)
    {
        Hp -= damage;
        if (bossState != BossState.Hit && bossState != BossState.Dead)
        {
            Hit();
        }
    }
}

public enum BossState
{
    Idle,
    Moving,
    Attacking,
    UsingSkill,
    Hit,
    Dead
}