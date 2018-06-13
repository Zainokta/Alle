using System;
using UnityEngine;

public class fuelController : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameplayManager.instance.refillFuel();
            Destroy(gameObject);
        }
    }
}