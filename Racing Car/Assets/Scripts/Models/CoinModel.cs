using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinModel : MonoBehaviour
{
    [SerializeField]
    private float scaleWeWantX = 0.5f;
    [SerializeField]
    private float scaleWeWantY = 0.5f;
    private bool inMagnetRange = false;

    private GameObject player;


    private void Awake()
    {
        transform.localScale = SettingScale.setLocalScale(scaleWeWantX, scaleWeWantY);
    }
    private void Start()
    {
        Debug.Log("BBBBBB");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("TODO: Add coin counter and shop");
            Destroy(gameObject);
        }
    }

    public void SetInMagnetRange()
    {
        inMagnetRange = true;
        gameObject.transform.parent = null;
    }

    private void Update()
    {
        if (inMagnetRange)
        {
            transform.position = Vector2.Lerp(transform.position, player.transform.position, 5*Time.deltaTime);
        }
    }
}
