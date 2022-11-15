using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeDirectionDecision : MonoBehaviour
{
    public GMSpawn gm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Car")
        {
            if (gm.IsStage23)
            {
                CarModel car = collision.transform.GetComponent<CarModel>();
                if (car.Obstacle.DesiredLane == -1 || car.Obstacle.DesiredLane == 0)
                {
                    car.IsOppositeDirection = true;
                    //Debug.Log("brzi auto");
                }
            }
            else 
            { 
                CarModel car = collision.transform.GetComponent<CarModel>();
                if (car.Obstacle.DesiredLane == -1 || car.Obstacle.DesiredLane == 0 || car.Obstacle.DesiredLane == 1)
                {
                    car.IsOppositeDirection = true;
                    //Debug.Log("brzi auto");
                }
            }
        }
        if (collision.transform.tag == "Bus")
        {
            if (gm.IsStage23)
            {
                BusModel bus = collision.transform.GetComponent<BusModel>();
                if (bus.Obstacle.DesiredLane == -1 || bus.Obstacle.DesiredLane == 0)
                {
                    bus.IsOppositeDirection = true;
                    //Debug.Log("brzi bus");
                }
            }
            else
            {
                BusModel bus = collision.transform.GetComponent<BusModel>();
                if (bus.Obstacle.DesiredLane == -1 || bus.Obstacle.DesiredLane == 0 || bus.Obstacle.DesiredLane == 1)
                {
                    bus.IsOppositeDirection = true;
                    //Debug.Log("brzi bus");
                }
            }
        }
        if (collision.transform.tag == "Roadworks")
        {
            RoadworksModel roadworks = collision.transform.GetComponent<RoadworksModel>();
            roadworks.IsOppositeDirection = true;
        }
    }
}
