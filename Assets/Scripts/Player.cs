using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Transform playerPositon;

	// Use this for initialization
	void Start () {
        playerPositon = GetComponent<Transform>();
        playerPositon = GameObject.Find("PlayerSpawn").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
