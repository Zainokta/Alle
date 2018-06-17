using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = (GameObject)Resources.Load("Prefabs/Player/Player");
        Instantiate(player, transform.position, Quaternion.identity);	
	}
}
