using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float setTimeUntilEndOfPowerUp = 10f;
    private float realTimeUntilEndOfPowerUp = 0f;
    private bool shiled = false;

    public Color startColor = Color.white;
    public Color endColor = Color.yellow;
    public float speed = 1;
    Renderer ren;

    public bool isHaveShield() { return shiled; }
    public void setShield(bool status_of_shield) { this.shiled = status_of_shield; }

    private void Awake()
    {
        ren = GetComponent<Renderer>();
    }
    public void startTimer()
    {
        realTimeUntilEndOfPowerUp = setTimeUntilEndOfPowerUp + EncryptedPlayerPrefs.GetInt("ShieldPowerKey") * 10;
        //Debug.Log(realTimeUntilEndOfPowerUp);
    }
    private void Update()
    {
        if (isHaveShield() && realTimeUntilEndOfPowerUp<0)
        {
            if (this != null)
            {
                this.setShield(false);
                ren.material.color = startColor;
                //Debug.Log("setovan shield na false");
            }
        }
        else if(isHaveShield())
        {
            ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
            realTimeUntilEndOfPowerUp -= Time.deltaTime;
            if(realTimeUntilEndOfPowerUp < 13)
                speed = 3;
            if (realTimeUntilEndOfPowerUp < 5)
                speed = 1;
        }
    }
}
