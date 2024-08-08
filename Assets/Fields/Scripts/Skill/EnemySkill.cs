using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkill : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Transform target;
    public float speed = 5f;
    public int damage = 10;
    private bool isStart = true;
    private bool isFlying = false;
    private bool hasHit = false;
    private Enemy enemy;
    private Collider2D col;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = FindObjectOfType<Enemy>();
    }

    private void Start()
    {
        StartCoroutine(StartSpell());
    }

    private void Update()
    {
        if (isFlying && !hasHit)
        {
            FlyToPlayer();
        }
        if (hasHit)
        {
             transform.rotation = Quaternion.identity;
            transform.position = target.position - new Vector3(0, 0.55f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerManger>();
            if (player != null)
            {
                player.TakeDmae(damage);
            }
            hasHit = true;
            isFlying = false;
            anim.SetTrigger("end");
            rb.velocity = Vector2.zero;
            Destroy(gameObject, 1f); 
        }
    }

    private void FlyToPlayer()
    {
        if (target == null)
        {
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private IEnumerator StartSpell()
    {
        enemy.speed = 0;
        anim.SetTrigger("start");
        col.enabled = false;
       yield return new WaitForSeconds(1.4f);
        enemy.speed = 2;
        col.enabled = true;
        isStart = false;
        isFlying = true;
        anim.SetTrigger("update");
    }
}
