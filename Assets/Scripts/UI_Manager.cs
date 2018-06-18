using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public static UI_Manager instance;

    public Slider fuelSlider;
    public Slider ammoSlider;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	void Update () {

	}

    public void updateSliderValue(string slider, string condition, float value)
    {
        switch (slider)
        {
            case "fuel":
                switch (condition)
                {
                    case "reduce":
                        fuelSlider.value -= value;
                        break;
                    case "fill":
                        fuelSlider.value += value;
                        break;
                }
                break;
            case "ammo":
                switch (condition)
                {
                    case "reduce":
                        ammoSlider.value -= value;
                        break;
                    case "fill":
                        fuelSlider.value += value;
                        break;
                }
                break;
        }
    }

    public void changeWeaponType(string type)
    {
        Player player;
        player = FindObjectOfType<Player>();
        player.WeaponType = type;
    }
}
