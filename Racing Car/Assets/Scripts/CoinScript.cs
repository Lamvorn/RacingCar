using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private float scaleWeWant = 0.5f;

    private void Awake()
    {
        transform.localScale = SettingScale.setLocalScale(scaleWeWant);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("AAAAAAAAAA");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("TRALLRALLALARLA");
        }
    }
}
