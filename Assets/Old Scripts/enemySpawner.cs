using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enemySpawner : MonoBehaviour {
    public GameObject enemy;
    public float spawnRate = 5f;
	// Use this for initialization
	void Start () {
        Invoke("spawnEnemy", spawnRate);
        InvokeRepeating("increaseSpawnRate", 0f, 30f);
	}
    
    void spawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject Enemy = Instantiate(enemy, new Vector2(max.x,Random.Range(min.y, max.y)), Quaternion.identity);
        NetworkServer.Spawn(Enemy);
        nextEnemySpawn();
    }

    void nextEnemySpawn()
    {
        float spawnInSeconds;
        if(spawnRate > 1f)
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
        if(spawnRate > 1f)
        {
            spawnRate--;
        }
        if(spawnRate == 1f)
        {
            CancelInvoke("increaseSpawnRate");
        }
    }
}
