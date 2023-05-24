using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    [SerializeField]public Slider slider;

    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        LoadValues();
        
    }
    private void LateUpdate()
    {
        SaveVolume();
    }
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        slider.value = volumeValue;
        fill.color = gradient.Evaluate(1f);
    }
    public void SaveVolume()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            float volumeValue = slider.value;
            PlayerPrefs.SetFloat("VolumeValue", volumeValue);
            LoadValues();
        }
        
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        slider.value = volumeValue;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
