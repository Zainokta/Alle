using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    private GameObject ammo;
    private GameObject fuel;
    float spawnTimeAmmo = 1f;
    float spawnTimeFuel = 15f;
    // Use this for initialization
    void Start () {
        ammo = (GameObject)Resources.Load("Prefabs/Ammo/Ammo");
        fuel = (GameObject)Resources.Load("Prefabs/Fuel/Fuel");
        StartCoroutine(SpawnAmmo());
        StartCoroutine(SpawnFuel());
    }

    IEnumerator SpawnAmmo()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Instantiate(ammo, new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)), Quaternion.identity);
        spawnTimeAmmo = Random.Range(10f, 20f);
        yield return new WaitForSeconds(spawnTimeAmmo);
        StartCoroutine(SpawnAmmo());
    }

    IEnumerator SpawnFuel()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Instantiate(fuel, new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y)), Quaternion.identity);
        spawnTimeFuel = Random.Range(10f, 15f);
        yield return new WaitForSeconds(spawnTimeFuel);
        StartCoroutine(SpawnFuel());
    }
}
