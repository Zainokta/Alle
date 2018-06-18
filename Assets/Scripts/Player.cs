using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    private Transform playerPositon;
    private GameObject bullet;
    private GameObject laser;
    private float playerSpeed = 5f;
    private float fireRate = 0.5f;
    private float nextFire = 0;
    private Rigidbody2D rb;
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
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        fireBullet();
        inputHandler();
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 0.5f, maxScreenBounds.x - 0.5f), Mathf.Clamp(transform.position.y, minScreenBounds.y + 0.5f, maxScreenBounds.y - 0.5f), transform.position.z);
    }

    void inputHandler()
    {
        Vector2 input = GetInput();
        rb.velocity = new Vector2(input.x * playerSpeed, input.y * playerSpeed);
    }

    private Vector2 GetInput()
    {
        Vector2 input = new Vector2
        {
            x = CrossPlatformInputManager.GetAxis("Horizontal"),
            y = CrossPlatformInputManager.GetAxis("Vertical")
        };
        return input;
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
            UI_Manager.instance.showTextShame();
            Destroy(collision);
        }
    }
}
