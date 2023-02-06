using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetColliderForCoins : MonoBehaviour
{
    
    public float setTimeUntilEndOfPowerUp = 10f;
    private float realTimeUntilEndOfPowerUp = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Coin")
        {
            collision.GetComponent<CoinModel>().SetInMagnetRange();
        }
    }
    private void OnEnable()
    {
        startTimer();
        //OVDE TREBA PRENETI VREME SA MARKETA, NEKA TO BUDE 5s + 2 * KOLIKO JE NABUDZENO PUTA U MARKETU s
    }
    public void startTimer() {
        realTimeUntilEndOfPowerUp = setTimeUntilEndOfPowerUp;
    }
    private void Update()
    {
        if (realTimeUntilEndOfPowerUp < 0f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            realTimeUntilEndOfPowerUp -= Time.deltaTime;
        }
    }
}
