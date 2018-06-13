using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKey)
        {
            Time.timeScale = 1.0f;
            this.gameObject.SetActive(false);
        }
	}
}
