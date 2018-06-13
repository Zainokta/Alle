using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class objectSpawner : MonoBehaviour
{
    public GameObject Ammo;
    public GameObject Fuel;
    float spawnTimeAmmo = 1f;
    float spawnTimeFuel = 15f;
    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnAmmo());
        StartCoroutine(SpawnFuel());
        //Invoke("spawnAmmo", 1f);
        //Invoke("spawnFuel", 15f);
	}
    /*
    void spawnAmmo()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject ammo = Instantiate(Ammo, new Vector2(Random.Range(min.x, max.x),Random.Range(min.y,max.y)), Quaternion.identity);
        NetworkServer.Spawn(ammo);
        nextObjectSpawn();
    }

    void spawnFuel()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject fuel = Instantiate(Fuel, new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)), Quaternion.identity);
        NetworkServer.Spawn(fuel);
        nextObjectSpawn();
    }

    void nextObjectSpawn()
    {
        spawnTimeAmmo = Random.Range(10f, 20f);
        spawnTimeFuel = Random.Range(20f, 40f);
        Invoke("spawnAmmo", spawnTimeAmmo);
        Invoke("spawnFuel", spawnTimeFuel);
    }
    */
    IEnumerator SpawnAmmo()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject ammo = Instantiate(Ammo, new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)), Quaternion.identity);
        NetworkServer.Spawn(ammo);
        spawnTimeAmmo = Random.Range(10f, 20f);
        yield return new WaitForSeconds(spawnTimeAmmo);
        StartCoroutine(SpawnAmmo());
    }

    IEnumerator SpawnFuel()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject fuel = Instantiate(Fuel, new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)), Quaternion.identity);
        NetworkServer.Spawn(fuel);
        spawnTimeFuel = Random.Range(10f, 15f);
        yield return new WaitForSeconds(spawnTimeFuel);
        StartCoroutine(SpawnFuel());
    }
}
