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
    private static int coins = 0;
    private GameObject player;

    private float laneDistance;
    [SerializeField]
    private int desiredLane = 1;

    public static int getCoin() { 
        return coins;
    }
    public static void setCoin(int coin) { 
        coins = coin;
    }
    private void Awake()
    {
        transform.localScale = SettingScale.setLocalScale(scaleWeWantX, scaleWeWantY);
        laneDistance = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y / 3;
        //      Debug.Log(laneDistance);
        switch (desiredLane)
        {
            case -1:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.left * (2 * laneDistance - laneDistance / 2);
                break;
            case 0:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.left * (laneDistance - laneDistance / 2);
                break;
            case 1:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.right * (0 + laneDistance / 2);
                break;
            case 2:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.right * (laneDistance + laneDistance / 2);
                break;
            case 3:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.right * (2 * laneDistance + laneDistance / 2);
                break;
            default:
                Debug.Log("AAAAAAAAAAAAA");
                break;
        }
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            
            coins++;
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
        if (inMagnetRange && player != null)
        {
            transform.position = Vector2.Lerp(transform.position, player.transform.position, 5*Time.deltaTime);
        }
        else if(player == null) 
            Destroy(gameObject);
    }
}
