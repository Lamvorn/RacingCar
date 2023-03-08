using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldModel : MonoBehaviour
{
    private PlayerModel player;

    [SerializeField]
    private int desiredLane = 1;
    private void Awake()
    {
        float laneDistance = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y / 3;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            player = collision.transform.GetComponent<PlayerModel>();
            //Debug.Log("logujem vrednost : " + player.getShield());
            player.setShield(true);
            player.speedOfChangingColor = 6;
            player.startTimer();
            Destroy(gameObject);
        }
    }
}
