using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Vector2 touchBegan;
    private Vector2 touchEnded;

    private float laneDistance;

    //[SerializeField]
    //private float scaleWeWantX = 1f;
    //[SerializeField]
    //private float scaleWeWantY = 1f;
    
    public int desiredLane = 1; //-1:bottom_bottom 0:bottom 1:middle 2:top 3:top_top
    public float speed = 1f;


    private Vector3 startPosition = new Vector3(0,0,0);

    private void Awake()
    {
        laneDistance = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y / 3;
        //transform.localScale = SettingScale.setLocalScale(scaleWeWantX, scaleWeWantY);
        startPosition += startPosition - Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)) /6;
        startPosition += Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 0)) + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width , Screen.height /2 , 0))/10;
    }
    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            Time.timeScale = 0.5f;
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            Time.timeScale = 1f;
        }

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
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            desiredLane--;

            if (desiredLane == -2)
                desiredLane = -1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            desiredLane++;

            if (desiredLane == 4)
                desiredLane = 3;
        }
        Vector2 targetPosition = startPosition;
        //Debug.Log(targetPosition);

        if (desiredLane == -1)
        {
            targetPosition += 2*Vector2.down * laneDistance;
        }
        else if (desiredLane == 0)
        {
            targetPosition += Vector2.down * laneDistance; 
        }
        else if (desiredLane == 2) {
            targetPosition += Vector2.up * laneDistance;
        }
        else if (desiredLane == 3)
        {
            targetPosition += 2*Vector2.up * laneDistance;
        }

        if( Mathf.Abs(targetPosition.y - transform.position.y) < 0.01)
            transform.position = targetPosition;
        else
        transform.position = Vector2.Lerp(transform.position, targetPosition, speed * Time.deltaTime);


    }
}
