using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Transform playerPositon;
    private GameObject bullet;
    private GameObject laser;
    private float fireRate = 0.5f;
    private float nextFire = 0;
    private string weaponType;

    public string WeaponType
    {
        get
        {
            return weaponType;
        }

        set
        {
            weaponType = value;
        }
    }

    // Use this for initialization

    void Start () {
        WeaponType = "bullet";
        bullet = (GameObject)Resources.Load("Prefabs/Bullet/Bullet");
        laser = (GameObject)Resources.Load("Prefabs/Laser/Laser");
        playerPositon = GetComponent<Transform>();
        playerPositon = GameObject.Find("PlayerSpawn").transform;
	}
	
	// Update is called once per frame
	void Update () {
        fireBullet();
    }

    void fireBullet()
    {
        switch (WeaponType)
        {
            case "bullet":
                if (Time.time > nextFire && UI_Manager.instance.ammoSlider.value > 0)
                {
                    nextFire = Time.time + fireRate;
                    GameObject bulletObj = Instantiate(bullet, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    bulletObj.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
                    UI_Manager.instance.updateSliderValue("ammo", "reduce", 1);
                }
                break;
            case "laser":
                if (Time.time > nextFire && UI_Manager.instance.ammoSlider.value > 0)
                {
                    nextFire = Time.time + fireRate;
                    GameObject laserObj = Instantiate(laser, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    laserObj.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
                    UI_Manager.instance.updateSliderValue("ammo", "reduce", 3);
                }
                break;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            Debug.Log("Bullet hit");
            UI_Manager.instance.updateSliderValue("fuel", "reduce", 10);
            Destroy(collision);
        }
    }
}
