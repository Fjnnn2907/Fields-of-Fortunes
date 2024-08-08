using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack Instance {  get; private set; }
    
    public Transform attackPoint;
    public float AttackRange;
    public LayerMask enemy;
    public int CurrentDamege;
    //[HideInInspector]
    public int Damege = 15;
    private void Awake()
    {
        Instance = this;
    }
    public void AttackToEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, AttackRange, enemy);

        if (hits.Length > 0)
        {
            CurrentDamege = Damege;
            CurrentDamege = Random.Range(CurrentDamege, CurrentDamege + 3);

            foreach (var hit in hits)
            {
                // Kiểm tra nếu đối tượng bị va chạm là Enemy hoặc Boss
                var enemyComponent = hit.GetComponent<Enemy>();
                if (enemyComponent != null)
                {
                    enemyComponent.TakeDamage(CurrentDamege);
                }

                var bossComponent = hit.GetComponent<Boss>();
                if (bossComponent != null)
                {
                    bossComponent.TakeDamage(CurrentDamege);
                }

                var mBossComponent = hit.GetComponent<mBoss>();
                if (mBossComponent != null)
                {
                    mBossComponent.TakeDamage(CurrentDamege);
                }
            }
        }
    }
    public void DamegeManger(int _MinDamege, int _MaxDamege)
    {
        _MaxDamege = Damege;
        _MaxDamege = CurrentDamege;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, AttackRange);

    }
}
