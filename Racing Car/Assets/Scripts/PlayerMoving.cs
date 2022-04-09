using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Vector2 touchBegan;
    private Vector2 touchEnded;

    private float laneDistance;

    [SerializeField]
    private float scaleWeWantX = 1f;
    [SerializeField]
    private float scaleWeWantY = 1f;

    public int desiredLane = 1; //-1:left_left 0:left 1:middle 2:right 3:right_right
    public float speed = 1f;

    private void Awake()
    {
        laneDistance = SettingScale.setLocalDistance(scaleWeWantX);
        transform.localScale = SettingScale.setLocalScale(scaleWeWantX, scaleWeWantY);
    }
    private void Update() {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                touchBegan = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEnded = Camera.main.ScreenToWorldPoint(touch.position);
                if (touchBegan.x - touchEnded.x < 0)
                {
                    desiredLane++;
                    if (desiredLane == 4)
                        desiredLane = 3;
                }
                else
                {
                    desiredLane--;
                    if (desiredLane == -2)
                        desiredLane = -1;
                }
            }            
        }

        Vector2 targetPosition = transform.position.y * transform.up;
        //Debug.Log(targetPosition);

        if (desiredLane == -1)
        {
            targetPosition += 2*Vector2.left * laneDistance;
        }
        else if (desiredLane == 0)
        {
            targetPosition += Vector2.left * laneDistance; 
        }
        else if (desiredLane == 2) {
            targetPosition += Vector2.right * laneDistance;
        }
        else if (desiredLane == 3)
        {
            targetPosition += 2*Vector2.right * laneDistance;
        }

        if( Mathf.Abs(targetPosition.x - transform.position.x) < 0.01)
            transform.position = targetPosition;
        else
        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
