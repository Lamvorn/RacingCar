using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsbtacleScript : MonoBehaviour
{
    [SerializeField]
    private float scaleWeWantX = 1f;
    [SerializeField]
    private float scaleWeWantY = 1f;
    private float laneDistance;
    [SerializeField]
    private float desiredLane = 1f;


    public void Awake()
    {
        transform.localScale = SettingScale.setLocalScale(scaleWeWantX-0.2f, scaleWeWantY);
        laneDistance = SettingScale.setLocalDistance(scaleWeWantX);
        switch (desiredLane)
        {
            case -1:
                transform.localPosition += 2 * Vector3.left * laneDistance;
                break;
            case 0:
                transform.localPosition += Vector3.left * laneDistance; 
                break;
            case 1:
                transform.localPosition = transform.localPosition.y * transform.up;
                break;
            case 2:
                transform.localPosition += Vector3.right * laneDistance; 
                break;
            case 3:
                transform.localPosition += 2 * Vector3.right * laneDistance; 
                break;
            default: break;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("TODO: Game Over");
        }
    }

}
