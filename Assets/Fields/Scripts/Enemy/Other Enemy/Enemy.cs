using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemDrop
{
    public GameObject item;
    public float dropRate;
}

public class Enemy : MonoBehaviour
{
    public float speed;
    public float Zone;
    public float timeChange = 3f;
    public float stopTime = 1f;
    public float chaseRange;
    public float attackRange;
    public EnemyState enemyState;
    public GameObject icon;
    public List<ItemDrop> itemDrops;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField]
    protected Transform MoveZone;
    protected Transform player;
    protected Vector2 moveDirection;
    protected bool isMoving = false;
    protected Vector2 initialPosition;
    public int hp;
    public int maxHp = 40;
    [SerializeField]
    protected Slider healthSlider;
    [SerializeField]
    protected GameObject canvasHealth;

    protected virtual void Awake()
    {
        player = GameObject.Find("PLAYER").GetComponent<Transform>();
        MoveZone = GameObject.Find("Zone Enemy").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initialPosition = transform.position;
        StartCoroutine(EnemyRoam());
    }

    protected virtual void Start()
    {
        maxHp = hp;
        healthSlider.maxValue = maxHp;
        canvasHealth.SetActive(false);

    }

    protected virtual void FixedUpdate()
    {
        SmartEnemyAI();
    }

    protected void Update()
    {
        UpdateHealh();
    }

    protected virtual void SmartEnemyAI()
    {
        if (enemyState == EnemyState.Run || enemyState == EnemyState.Attack)
        {
            HitAndRunPlayer();
        }
        else if (enemyState == EnemyState.Deah)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        else if (isMoving)
        {
            if (Vector2.Distance(transform.position, MoveZone.position) >= Zone)
            {
                moveDirection = (MoveZone.position - transform.position).normalized;
                Flip();
            }
            ChangeState(EnemyState.Roam);
            rb.velocity = moveDirection * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.idle);
        }
    }

    protected virtual IEnumerator EnemyRoam()
    {
        while (true)
        {
            if (enemyState != EnemyState.Run && enemyState != EnemyState.Attack)
            {
                yield return new WaitForSeconds(timeChange);
                isMoving = false;
                yield return new WaitForSeconds(stopTime);
                isMoving = true;
                ChangeDir();
            }
            else
            {
                yield return null; // Đợi một frame
            }
        }
    }

    protected virtual void ChangeDir()
    {
        var random = Random.Range(3f, 7f);
        stopTime = random;
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Flip();
    }

    protected virtual void Flip()
    {
        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
            healthSlider.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
            healthSlider.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(MoveZone.position, Zone);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // cập nhật máu
    public void UpdateHealh()
    {
        healthSlider.value = hp;
    }

    public virtual void TakeDamage(int damage)
    {
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
            StartCoroutine(DeahTimer());
        }
    }

    protected virtual IEnumerator CanvasActive()
    {
        canvasHealth.SetActive(true);
        yield return new WaitForSeconds(3);
        canvasHealth.SetActive(false);
    }

    IEnumerator DeahTimer()
    {
        ChangeState(EnemyState.Deah);
        Destroy(gameObject, 1);
        yield return new WaitForSeconds(.9f);
        PlayerExp.Instance.AddExp(50);
        PopUPManager.Instance.ShowExp("50", player.transform);
        SpawnManager.Instance.KillEnemy();
        DropItem();
    }

    private void DropItem()
    {
        float totalDropRate = 0;
        foreach (var itemDrop in itemDrops)
        {
            totalDropRate += itemDrop.dropRate;
        }

        float randomValue = Random.value * totalDropRate;
        float cumulative = 0;
        foreach (var itemDrop in itemDrops)
        {
            cumulative += itemDrop.dropRate;
            if (randomValue < cumulative)
            {
                Instantiate(itemDrop.item, transform.position, Quaternion.identity);
                break;
            }
        }
    }
    //
    protected virtual void HitAndRunPlayer()
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

    protected virtual void ReturnToRoam()
    {
        float distanceToInitialPosition = Vector2.Distance(transform.position, initialPosition);

        if (distanceToInitialPosition > 0.1f)
        {
            moveDirection = (initialPosition - (Vector2)transform.position).normalized;
            Flip();
            rb.velocity = moveDirection * speed;
            ChangeState(EnemyState.Roam);
        }
        else
        {
            rb.velocity = Vector2.zero;
            isMoving = true;
            ChangeState(EnemyState.idle);
        }
    }

    protected virtual void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.idle)
            anim.SetBool("idle", false);
        else if (enemyState == EnemyState.Roam || enemyState == EnemyState.Run)
            anim.SetBool("run", false);
        else if (enemyState == EnemyState.Attack)
            anim.SetBool("attack", false);
        else if (enemyState == EnemyState.Deah)
            anim.SetBool("deah", false);

        enemyState = newState;

        if (enemyState == EnemyState.idle)
            anim.SetBool("idle", true);
        else if (enemyState == EnemyState.Roam || enemyState == EnemyState.Run)
            anim.SetBool("run", true);
        else if (enemyState == EnemyState.Attack)
            anim.SetBool("attack", true);
        else if (enemyState == EnemyState.Deah)
            anim.SetBool("deah", true);
    }
}

public enum EnemyState
{
    idle,
    Roam,
    Attack,
    Run,
    Deah
}
