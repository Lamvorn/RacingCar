using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusModel : MonoBehaviour
{
    private float speed = 1f;
    private bool isOppositeDirection;
    private bool isBusCrashed = false;
    public OsbtacleScript obstacle;
    public GameObject autobus;

    private void Awake()
    {
        //OsbtacleScript obstacle = Automobil.GetComponent<OsbtacleScript>();
    }
    public bool IsOppositeDirection { get => isOppositeDirection; set => isOppositeDirection = value; }
    public float Speed { get => speed; set => speed = value; }
    public GameObject Automobil { get => autobus; set => autobus = value; }
    public OsbtacleScript Obstacle { get => obstacle; set => obstacle = value; }
    public bool IsBusCrashed { get => isBusCrashed; set => isBusCrashed = value; }
}
