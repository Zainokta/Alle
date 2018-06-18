using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    private GameObject enemy;
    public float spawnRate = 7.5f;
    // Use this for initialization
    void Start()
    {
        enemy = (GameObject)Resources.Load("Prefabs/Enemy/Enemy");
        Invoke("spawnEnemy", spawnRate);
        InvokeRepeating("increaseSpawnRate", 0f, 30f);
    }

    void spawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject Enemy = Instantiate(enemy, new Vector2(max.x, Random.Range(min.y, max.y)), Quaternion.identity);
        nextEnemySpawn();
    }

    void nextEnemySpawn()
    {
        float spawnInSeconds;
        if (spawnRate > 1f)
        {
            spawnInSeconds = Random.Range(1f, spawnRate);
        }
        else
        {
            spawnInSeconds = 1f;
        }
        Invoke("spawnEnemy", spawnInSeconds);
    }

    void increaseSpawnRate()
    {
        if (spawnRate > 1f)
        {
            spawnRate--;
        }
        if (spawnRate == 1f)
        {
            CancelInvoke("increaseSpawnRate");
        }
    }
}
