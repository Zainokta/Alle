using System;
using Object = System.Object;
using UnityEngine;
using UnityEngine.UI;

public class gameplayManager : MonoBehaviour
{
    public static gameplayManager instance = null;
    
    public GameObject quitButton;
    public Slider fuelSlider;
    public Slider ammoSlider;
    public AudioSource audioSFX;
    public AudioSource audioBG;
    public GameObject Ammo;
    public GameObject Fuel;
    public float score = 0;

    bool keEscape = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && keEscape == false)
        {
            Time.timeScale = 0;
            quitButton.SetActive(true);
            keEscape = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && keEscape == true)
        {
            Time.timeScale = 1;
            quitButton.SetActive(false);
            keEscape = false;
        }

        if(fuelSlider.value <= 0)
        {
            Time.timeScale = 0;
            audioBG.Stop();
        }
        fuelSlider.value -= 1f * Time.deltaTime;
    }
    
    public void refillAmmo()
    {
        ammoSlider.value += 30;
    }

    public void refillFuel()
    {
        fuelSlider.value += 30;
    }

    public void reduceEntity()
    {
        ammoSlider.value -= 20;
        fuelSlider.value -= 20;
    }

    public void playAudio()
    {
        audioSFX.Play();
    }
    
    public void quitClicked()
    {
        Application.Quit();
    }
}
