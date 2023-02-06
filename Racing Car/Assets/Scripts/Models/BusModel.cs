using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusModel : MonoBehaviour
{
    public float speed = 4f;
    private bool isOppositeDirection=false;
    private bool isBusCrashed = false;
    private ObstacleScript obstacle;

    private void Awake()
    {
        obstacle = gameObject.GetComponent<ObstacleScript>();
    }
    public bool IsOppositeDirection { get => isOppositeDirection; set => isOppositeDirection = value; }
    public float Speed { get => speed; set => speed = value; }
    public ObstacleScript Obstacle { get => obstacle; set => obstacle = value; }
    public bool IsBusCrashed { get => isBusCrashed; set => isBusCrashed = value; }

    void Update()
    {
        if (this.IsOppositeDirection && !this.IsBusCrashed)
            transform.position = transform.position - Vector3.right * Time.deltaTime * speed;
    }

}
