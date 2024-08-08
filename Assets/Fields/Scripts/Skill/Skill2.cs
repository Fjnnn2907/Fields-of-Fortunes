using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    public static Skill2 instance;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isStart = true;
    private bool isGun;
    private bool isHit;
    public Transform Tager;
    public float Speed;
    public int damege;
    private List<Enemy> nearbyEnemies = new List<Enemy>();

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        FindTarget();  
    }

    private void Update()
    {
        UpdateAnimation();
        HandleLogic();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damege);
            }
            Debug.Log("Enemy hit");
            isGun = false;
            isHit = true;
            anim.SetBool("end", true);
            Destroy(gameObject, 1f);
        }
    }

    private void HandleLogic()
    {
        if (!Tager) return;

        if (isStart)
        {
            StartCoroutine(TimerSkill());
        }
        if (isHit)
        {
            transform.rotation = Quaternion.identity;
            transform.position = Tager.position - new Vector3(0, 0.55f, 0);
        }
        if (isGun)
        {
            Vector2 dir = Tager.position - transform.position;
            rb.velocity = dir.normalized * Speed;
        }
    }

    private IEnumerator TimerSkill()
    {
        Movement.Instance.speed = 0;
        rb.velocity = Vector2.zero;
        
        yield return new WaitForSeconds(1.3f);
        Movement.Instance.speed = 5;
        isStart = false;
        isGun = true;
    }

    private void UpdateAnimation()
    {
        anim.SetBool("start", isStart);
        anim.SetBool("update", isGun);
    }

    private void FindTarget()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemyObject in enemyObjects)
        {
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                nearbyEnemies.Add(enemy);
            }
        }

        nearbyEnemies.Sort((a, b) =>
        {
            float distanceA = Vector2.Distance(transform.position, a.transform.position);
            float distanceB = Vector2.Distance(transform.position, b.transform.position);
            return distanceA.CompareTo(distanceB);
        });


        if (nearbyEnemies.Count > 0)
        {
            Tager = nearbyEnemies[0].transform;
        }
    }
}
