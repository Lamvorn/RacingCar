using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    private float scaleWeWantX = 0.5f;
    [SerializeField]
    private float scaleWeWantY = 0.5f;

    private void Awake()
    {
        transform.localScale = SettingScale.setLocalScale(scaleWeWantX,scaleWeWantY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("TODO: Add coin counter and shop");
            Destroy(gameObject);
        }
    }
}
