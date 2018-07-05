using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class UI_Manager : MonoBehaviour {

    public static UI_Manager instance;

    public Slider fuelSlider;
    public Slider ammoSlider;
    public Text txtPraise;
    public Text txtScore;
    public GameObject panel;
    public int score;
    private int random;
    private string[] text = new string[4];
    private Animator anim;
    private float scrollSpeed = 0.5f;

	// Use this for initialization
	void Start () {
        text[0] = "Nice!";
        text[1] = "Wow!";
        text[2] = "Excellent!";
        text[3] = "You fool!";
        txtScore.text = "Score : 0";
        anim = txtPraise.GetComponent<Animator>();
        instance = this; 
	}
	
	void Update () {
        checkGameOver();
        updateSliderValue("fuel", "reduce", 1 * Time.deltaTime);
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
                        ammoSlider.value += value;
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

    public void addScore(int value)
    {
        score += value;
        txtScore.text = "Score : " + score.ToString();
    }

    public void showTextPraise()
    {
        random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                txtPraise.text = text[0];
                break;
            case 1:
                txtPraise.text = text[1];
                break;
            case 2:
                txtPraise.text = text[2];
                break;
        }
        anim.SetTrigger("Open");
    }

    public void showTextShame()
    {
        txtPraise.text = text[3];
        anim.SetTrigger("Open");
    }

    public void checkGameOver()
    {
        if(fuelSlider.value <= 0)
        {
            FindObjectOfType<Player>().enabled = false;
            panel.SetActive(true);
        }
    }
    public void restartGame()
    {
        txtScore.text = "Score : 0";
        SceneManager.LoadScene("Game");
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
