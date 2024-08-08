using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance {  get; private set; }

    public GameObject enemyPrefab;   
    public Transform spawnPoints;
    public int count;
    public int maxEnemies;
    public float spawnTime;
    public int currentEnemies;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentEnemies = maxEnemies;
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
            if(currentEnemies >= maxEnemies)
                break;

        }
    }

    void SpawnEnemy()
    {
        if (currentEnemies < maxEnemies)
        {
            Instantiate(enemyPrefab, spawnPoints.position + new Vector3(Random.Range(-2,2), Random.Range(-2, 2)), Quaternion.identity);
            currentEnemies++;
        }      
    }

    public void KillEnemy()
    {
        currentEnemies--;
        StartCoroutine(TimeSpawn());
    }

    IEnumerator TimeSpawn()
    {
        yield return new WaitForSeconds(spawnTime);
        count++;
        SpawnEnemy();
    }

}
