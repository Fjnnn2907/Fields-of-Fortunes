using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Skill Instance;


    private Rigidbody2D rb;
    public float Speed;
    public Transform Tager;
    public Animator anim;
    private bool hasHit = false;
    private GameObject playerPos;

    public int damage;

    public List<Enemy> nearbyEnemies = new List<Enemy>();


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindTarget();
        anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player");
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

        // list sort near distance enemy
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            anim.SetBool("Hit", true);
            hasHit = true;

            Destroy(this.gameObject, 1);
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

        }
    }
    private void Update()
    {
        // Kiểm tra nếu enemy hiện tại đã bị tiêu diệt, tìm enemy mới gần nhất
        if (Tager == null && nearbyEnemies.Count > 0)
        {
            nearbyEnemies.RemoveAt(0);
            if (nearbyEnemies.Count > 0)
            {
                Tager = nearbyEnemies[0].transform;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Tager)
        {
            return;
        }

        if (!hasHit)
        {
            Vector2 dir = Tager.position - transform.position;
            rb.velocity = dir.normalized * Speed;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            transform.rotation = Quaternion.identity;
            transform.position = Tager.position - new Vector3(0, 0.55f, 0);
        }
    }
}