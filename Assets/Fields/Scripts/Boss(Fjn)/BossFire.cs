using UnityEngine;

public class BossFire : Boss
{
    public GameObject fireballPrefab;  
    public float fireballCooldown = 3f;
    public GameObject minionPrefab;  
    public float minionSpawnCooldown = 10f;

    private float fireballTimer;
    private float minionSpawnTimer;
    private bool isUsingSkill = false;

    protected override void Start()
    {
        base.Start();
        moveSpeed = 0; 
        ChangeState(BossState.Idle);

        fireballTimer = fireballCooldown;
        minionSpawnTimer = minionSpawnCooldown;
    }

    protected override void Update()
    {
        base.Update();

        if (isUsingSkill)
            return;

        fireballTimer -= Time.deltaTime;
        minionSpawnTimer -= Time.deltaTime;

        if (fireballTimer <= 0)
        {
            StartFireballAttack();
        }
        else if (minionSpawnTimer <= 0)
        {
            StartMinionSpawn();
        }
        Dead();


    }

    private void StartFireballAttack()
    {
        ChangeState(BossState.UsingSkill);
        isUsingSkill = true;
        FireballAttack();
        Invoke("EndSkill", 1f);
        fireballTimer = fireballCooldown;
    }

    private void StartMinionSpawn()
    {
        ChangeState(BossState.UsingSkill);
        isUsingSkill = true;
        SpawnMinions();
        Invoke("EndSkill", 1f);
        minionSpawnTimer = minionSpawnCooldown;
    }

    public override void Attack()
    {
        base.Attack();

    }

    public override void UseSkill()
    {
        base.UseSkill();

        ChangeState(BossState.UsingSkill);
    }

    private void FireballAttack()
    {
        GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (player.position - transform.position).normalized;
        fireball.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        Destroy(fireball, 5f); 
    }

    private void SpawnMinions()
    {
        // Gọi lính hỏa
        Instantiate(minionPrefab, transform.position, Quaternion.identity);
    }

    private void EndSkill()
    {
        isUsingSkill = false;
        ChangeState(BossState.Idle);
    }

    public override void Dead()
    {
        base.Dead();
    }
}
