using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Car") {
            CarModel car = collision.transform.GetComponent<CarModel>();
            car.IsCarCrashed = true;
            car.GetComponent<Renderer>().material.color = Color.red;
            //Debug.Log("DESIO SE SUDAR");
        }

        if (collision.transform.tag == "Bus") {
            BusModel bus = collision.transform.GetComponent<BusModel>();
            CarModel car = gameObject.GetComponent<CarModel>();
            bus.IsBusCrashed = true;
            car.IsCarCrashed = true;
            // GRAFIKA ZA CRASH
            bus.GetComponent<Renderer>().material.color = Color.red;
            car.GetComponent<Renderer>().material.color = Color.red;
        }
    }

}
