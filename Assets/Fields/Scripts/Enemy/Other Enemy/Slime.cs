using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slime : Enemy
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
        MoveZone = GameObject.Find("Zone Enemy1").GetComponent<Transform>();
    }

    protected new void Update()
    {
        base.Update();
    }

    protected override void SmartEnemyAI()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= Zone)
        {
            if (distanceToPlayer <= attackRange)
            {
               
                ChangeState(EnemyState.Attack);
                rb.velocity = Vector2.zero;
            }
            else if (distanceToPlayer <= chaseRange)
            {
                
                ChangeState(EnemyState.Run);
                moveDirection = (player.position - transform.position).normalized;
                Flip();
                rb.velocity = moveDirection * speed;
            }
            else
            {
                
                rb.velocity = Vector2.zero;
                ChangeState(EnemyState.idle);
            }
        }
        else
        {
            
            ReturnToRoam();
        }
    }
}

