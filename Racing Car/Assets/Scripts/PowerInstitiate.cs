using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInstitiate : MonoBehaviour
{
    public GameObject powerMagnet;
    public GameObject powerShield;
    // Start is called before the first frame update
    void Awake()
    {
        int random = Random.Range(1, 3);
        switch (random) { 
            case 1:
                powerMagnet.SetActive(true);
                powerShield.SetActive(false);
                break;
            case 2:
                powerShield.SetActive(true);
                powerMagnet.SetActive(false);
                break;
        }
    }
}
