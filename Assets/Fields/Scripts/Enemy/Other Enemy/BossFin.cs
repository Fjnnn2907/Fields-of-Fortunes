using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFin : Enemy
{

    protected new void Awake()
    {
        base.Awake();


    }

    protected new void Start()
    {
        base.Start();

    }

    protected new void FixedUpdate()
    {
        SmartEnemyAI();
    }

    protected new void Update()
    {
        base.Update();

    }

    public override void TakeDamage(int damage)
    {
        //base.TakeDamage(damage);
        hp -= damage;
        UpdateHealh();
        if (maxHp != hp)
            StartCoroutine(CanvasActive());

        //EnemyHealthh.Instance.SetShowUI();
        PopUPManager.Instance.ShowDamege(damage.ToString(), this.transform);
        if (hp > 0)
        {
            ChangeState(EnemyState.Run);
        }
        else
        {
            ChangeState(EnemyState.Deah);
            Destroy(gameObject, 1);
        }
    }
    protected override void HitAndRunPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        icon.SetActive(true);
        if (Mathf.Abs(player.position.y - transform.position.y) <= 0.3f || distanceToPlayer <= attackRange)
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Attack);
            Vector2 direction = (player.position - transform.position).normalized;
            if (direction.x > 0 && transform.position.x < player.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
                healthSlider.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (direction.x < 0 && transform.position.x > player.position.x)
            {
                transform.localScale = new Vector2(1, 1);
                healthSlider.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else if (distanceToPlayer <= chaseRange)
        {
            moveDirection = (player.position - transform.position).normalized;
            Flip();
            rb.velocity = moveDirection * speed;
            ChangeState(EnemyState.Run);
        }
        else
        {
            ReturnToRoam();
            icon.SetActive(false);
        }
    }
}
