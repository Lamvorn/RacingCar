using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetModel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameObject go = GameObject.FindObjectOfType<magnetColliderForCoins>(true).gameObject;
            if (go.activeSelf) { go.GetComponent<magnetColliderForCoins>().startTimer(); }
            else go.SetActive(true);
            Destroy(gameObject);
        }
    }
}
