using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeDirectionDecision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Car")
        {
           CarModel car = collision.transform.GetComponent<CarModel>();
            if (car.Obstacle.DesiredLane == -1 || car.Obstacle.DesiredLane == 0)
            { 
                car.IsOppositeDirection = true;
                //Debug.Log("brzi auto");
            }
        }
        if (collision.transform.tag == "Bus")
        {
            BusModel bus = collision.transform.GetComponent<BusModel>();
            if (bus.Obstacle.DesiredLane == -1 || bus.Obstacle.DesiredLane == 0)
            {
                bus.IsOppositeDirection = true;
                //Debug.Log("brzi bus");
            }
        }
    }
    
}
