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
        //transform.localScale = SettingScale.setLocalScale(scaleWeWantX-0.2f, scaleWeWantY);
        laneDistance = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y / 3;
        Debug.Log(laneDistance);
        switch (desiredLane)
        {
            case -1:
                transform.localPosition += Vector3.left * (2*laneDistance-laneDistance/2) ;
                break;
            case 0:
                transform.localPosition += Vector3.left * (laneDistance-laneDistance/2); 
                break;
            case 1:
                transform.localPosition += Vector3.right * (0 + laneDistance / 2);
                break;
            case 2:
                transform.localPosition += Vector3.right * (laneDistance+laneDistance/2); 
                break;
            case 3:
                transform.localPosition += Vector3.right * (2*laneDistance + laneDistance/2); 
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
            Debug.Log("TODO: Game Over");
        }
    }

}
