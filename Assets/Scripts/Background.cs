using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    private float speed = -0.5f;
    public Material mats;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * speed;

        mats.mainTextureOffset = new Vector2(offset, 0);
    }
}