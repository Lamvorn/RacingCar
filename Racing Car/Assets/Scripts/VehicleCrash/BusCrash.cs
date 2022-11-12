using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusCrash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bus")
        {
            BusModel car = collision.transform.GetComponent<BusModel>();
            car.IsBusCrashed = true;
            car.GetComponent<Renderer>().material.color = Color.red;
            //Debug.Log("DESIO SE SUDAR");
        }

        if (collision.transform.tag == "Car")
        {
            CarModel car = collision.transform.GetComponent<CarModel>();
            BusModel bus = gameObject.GetComponent<BusModel>();
            bus.IsBusCrashed = true;
            car.IsCarCrashed = true;
            // GRAFIKA ZA CRASH
            bus.GetComponent<Renderer>().material.color = Color.red;
            car.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
