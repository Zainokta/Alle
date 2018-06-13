using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class playerController : NetworkBehaviour {
    public float speed;
    public GameObject guns;
    private Slider sliderAmmo;
    private Slider sliderFuel;
    float fireRate = 0.3f;
    float nextFire = 0;
    bool sudahKena = false;

    void Start ()
    {
        sliderAmmo = gameplayManager.instance.ammoSlider;
        sliderFuel = gameplayManager.instance.fuelSlider;
    }
    
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if(sliderFuel.value <= 0)
        {
            Destroy(gameObject);
        }
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 7;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * 7;
        transform.Translate(moveX, moveY, 0); Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 0.5f, maxScreenBounds.x - 0.5f), Mathf.Clamp(transform.position.y, minScreenBounds.y + 0.5f, maxScreenBounds.y - 0.5f), transform.position.z);

        if (Input.GetMouseButton(0) && sliderAmmo.value > 0 && Time.time > nextFire)
        {
            CmdFireBullet();
        }
    }
    [Command]
    void CmdFireBullet()
    {
        nextFire = Time.time + fireRate;
        GameObject bullet = Instantiate(guns, new Vector2(transform.position.x + 1,transform.position.y), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
        NetworkServer.Spawn(bullet);
        sliderAmmo.value -= 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy" && sudahKena == false)
        {
            sliderFuel.value -= 20;
            sudahKena = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (sudahKena == true)
            sudahKena = false;
    }
}
