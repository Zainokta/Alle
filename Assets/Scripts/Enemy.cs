using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private GameObject explosion;
    [SerializeField]
    private float enemySpeed;
    private GameObject enemyBullet;

    float fireRate = 2f;
    float nextFire = 0;
    private int deathCounter = 0;

    Rigidbody2D EnemyRB;

    private void Start()
    {
        explosion = (GameObject)Resources.Load("Prefabs/Explosion/Explosion");
        enemyBullet = (GameObject)Resources.Load("Prefabs/Bullet/Bullet");
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
            //gameplayManager.instance.playAudio();
            UI_Manager.instance.updateSliderValue("fuel", "reduce", 20);
            UI_Manager.instance.updateSliderValue("ammo", "reduce", 10);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            //gameplayManager.instance.playAudio();
            deathCounter++;
            if (deathCounter >= 2)
            {
                //gameplayManager.instance.score++;
                GameObject explosionObj = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(explosionObj, 2.5f);
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Laser")
        {
            GameObject explosionObj = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionObj, 2.5f);
            Destroy(gameObject);
        }
    }

    IEnumerator Fire()
    {
        Debug.Log("Fire!");
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(enemyBullet, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
            bullet.gameObject.tag = "BulletEnemy";
        }
        yield return null;
        StartCoroutine(Fire());
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
