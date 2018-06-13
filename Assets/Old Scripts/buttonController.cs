using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonController : MonoBehaviour
{
    private Slider forAmmo;
    private Slider fuelSlider;

    private void Start()
    {
        forAmmo = gameplayManager.instance.ammoSlider;
        fuelSlider = gameplayManager.instance.fuelSlider;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AmmoClicked();
    }
    public void AmmoClicked()
    {
        if (fuelSlider.value > 0)
        {
            forAmmo.value += 20;
            fuelSlider.value -= 10;
        }
    }
    public void QuitClicked()
    {
        Application.Quit();
    }
}
