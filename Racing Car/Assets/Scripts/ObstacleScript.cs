using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private float laneDistance;
    [SerializeField]
    private int desiredLane = 1;
    public GameObject explosion;

    public int DesiredLane { get => desiredLane; set => desiredLane = value; }

    public void Awake()
    {
        laneDistance = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y / 3;
//      Debug.Log(laneDistance);
        switch (DesiredLane)
        {
            case -1:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.left * (2*laneDistance-laneDistance/2) ;
                break;
            case 0:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.left * (laneDistance-laneDistance/2); 
                break;
            case 1:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.right * (0 + laneDistance / 2);
                break;
            case 2:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.right * (laneDistance+laneDistance/2); 
                break;
            case 3:
                transform.localPosition = transform.localPosition.y * Vector3.up + Vector3.right * (2*laneDistance + laneDistance/2); 
                break;
            default:
                Debug.Log("AAAAAAAAAAAAA");
                break;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerModel player = collision.transform.GetComponent<PlayerModel>();
            if (player.isHaveShield())
            {
                GameObject gm = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Destroy(gameObject);
                Destroy(gm, 3);
            }
            else
            {
                int coins = CoinModel.getCoin();
                EncryptedPlayerPrefs.SetInt("NumberOfCoinsKey", EncryptedPlayerPrefs.GetInt("NumberOfCoinsKey") + 10 * coins);
                Debug.Log("TODO: Game Over");
            }
        }
    }

}
