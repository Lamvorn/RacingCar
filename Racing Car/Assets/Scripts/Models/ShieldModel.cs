using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldModel : MonoBehaviour
{
    private PlayerModel player;

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
