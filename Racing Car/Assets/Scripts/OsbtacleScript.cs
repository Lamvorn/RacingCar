using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsbtacleScript : MonoBehaviour
{
    [SerializeField]
    private float scaleWeWantX = 1f;
    [SerializeField]
    private float scaleWeWantY = 1f;

    public void Awake()
    {
        transform.localScale = SettingScale.setLocalScale(scaleWeWantX, scaleWeWantY);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("TODO: Game Over");
        }
    }

}
