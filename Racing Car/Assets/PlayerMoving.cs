using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 2; 

    private void Start()
    {
    }
    private void Update() {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector2 targetPosition = transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector2.left * laneDistance;
        }
        else if (desiredLane == 2) {
            targetPosition += Vector2.right * laneDistance;
        }

        transform.position = Vector2.Lerp(transform.position, targetPosition, 50*Time.deltaTime);
        
    }

    private void FixedUpdate()
    {
    }


}
