using System;
using UnityEngine;

public class ammoController : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameplayManager.instance.refillAmmo();
            Destroy(gameObject);
        }
    }
}
