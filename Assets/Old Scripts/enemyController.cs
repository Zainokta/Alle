using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class enemyController : MonoBehaviour {
    public GameObject Explosion;
    public float enemySpeed;
    public GameObject atk;

    float fireRate = 2f;
    float nextFire = 0;
    private int deathCounter = 0;
    
    Rigidbody2D EnemyRB;

    private void Start()
    {
        EnemyRB = GetComponent<Rigidbody2D>();
        StartCoroutine(Fire());
    }

    private void FixedUpdate()
    {
        EnemyRB.velocity = new Vector2(-1f, 0) * enemySpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameplayManager.instance.reduceEntity();
            gameplayManager.instance.playAudio();
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            gameplayManager.instance.playAudio();
            deathCounter++;
            if(deathCounter >= 2)
            {
                gameplayManager.instance.score++;
                GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(explosion, 2.5f);
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
    
    IEnumerator Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(atk, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
            bullet.gameObject.tag = "BulletEnemy";
            NetworkServer.Spawn(bullet);
        }
        yield return null;
        StartCoroutine(Fire());
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
