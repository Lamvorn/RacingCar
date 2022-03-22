using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 2;
    public float speed = 1f;
    private Vector2 touchBegan;
    private Vector2 touchEnded;

    private void Start()
    {
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
                    if (desiredLane == 3)
                        desiredLane = 2;
                }
                else
                {
                    desiredLane--;
                    if (desiredLane == -1)
                        desiredLane = 0;
                }
            }            
        }

        Vector2 targetPosition = transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector2.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector2.right * laneDistance;
        }

        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
    }


}
