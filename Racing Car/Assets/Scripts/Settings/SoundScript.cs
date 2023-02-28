using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    private static string SOUND = "Sound";

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1) { 
            Destroy(this.gameObject);
        }
        this.GetComponent<AudioSource>().volume = EncryptedPlayerPrefs.GetFloat(SOUND);
        DontDestroyOnLoad(this.gameObject);
    }
}
