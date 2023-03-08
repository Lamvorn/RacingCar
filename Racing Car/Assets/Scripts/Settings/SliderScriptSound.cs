using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScriptSound : MonoBehaviour
{
    private static string SOUND = "Sound";

    private GameObject soundSource;

    public Slider slider;

    public GameObject soundOn;
    public GameObject soundOff;

    private void Awake()
    {
        slider.value = EncryptedPlayerPrefs.GetFloat(SOUND);
    }
    public void OnValueChanged()
    {
        soundSource = GameObject.FindGameObjectWithTag("GameMusic");
        if (slider.value == 0)
        {
            soundOff.SetActive(true);
            soundOn.SetActive(false);
        }
        else {
            soundOff.SetActive(false);
            soundOn.SetActive(true);
        }
        EncryptedPlayerPrefs.SetFloat(SOUND, slider.value);
        soundSource.GetComponent<AudioSource>().volume = slider.value;
    }
}
