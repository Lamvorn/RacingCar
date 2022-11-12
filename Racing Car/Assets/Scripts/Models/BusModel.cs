using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusModel : MonoBehaviour
{
    public float speed = 3f;
    private bool isOppositeDirection=false;
    private bool isBusCrashed = false;
    public OsbtacleScript obstacle;
  //  public GameObject autobus;

    private void Awake()
    {
        //OsbtacleScript obstacle = Automobil.GetComponent<OsbtacleScript>();
    }
    public bool IsOppositeDirection { get => isOppositeDirection; set => isOppositeDirection = value; }
    public float Speed { get => speed; set => speed = value; }
   // public GameObject Autobus { get => autobus; set => autobus = value; }
    public OsbtacleScript Obstacle { get => obstacle; set => obstacle = value; }
    public bool IsBusCrashed { get => isBusCrashed; set => isBusCrashed = value; }

    void Update()
    {
        if (this.IsOppositeDirection && !this.IsBusCrashed)
            transform.position = transform.position - Vector3.right * Time.deltaTime * speed;
    }

}
