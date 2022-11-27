using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetColliderForCoins : MonoBehaviour
{
    
    public float timeUntilEndOfPowerUp = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Coin")
        {
            collision.GetComponent<CoinModel>().SetInMagnetRange();
        }
    }
    private void OnEnable()
    {
        timeUntilEndOfPowerUp = 5f;
        //OVDE TREBA PRENETI VREME SA MARKETA, NEKA TO BUDE 5s + 2 * KOLIKO JE NABUDZENO PUTA U MARKETU s
    }

    private void Update()
    {
        if (timeUntilEndOfPowerUp < 0f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            timeUntilEndOfPowerUp -= Time.deltaTime;
        }
    }
}
