using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModel : MonoBehaviour
{
    public float speed=5.5f;
    private bool isOppositeDirection=false;
    private bool isCarCrashed= false;
    private ObstacleScript obstacle;

    private void Awake()
    {
        obstacle = gameObject.GetComponent<ObstacleScript>();
    }
    public bool IsOppositeDirection { get => isOppositeDirection; set => isOppositeDirection = value; }
    public float Speed { get => speed; set => speed = value; }
    public ObstacleScript Obstacle { get => obstacle; set => obstacle = value; }
    public bool IsCarCrashed { get => isCarCrashed; set => isCarCrashed = value; }

    void Update()
    {
        if (this.IsOppositeDirection && !this.IsCarCrashed)
            transform.position = transform.position - Vector3.right * Time.deltaTime * speed;
    }

}
