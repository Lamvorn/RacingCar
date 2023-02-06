using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadworksModel : MonoBehaviour
{
    public float speed = 1.5f;
    private bool isOppositeDirection = false;
    private ObstacleScript obstacle;

    private void Awake()
    {
        obstacle = gameObject.GetComponent<ObstacleScript>();
    }
    public bool IsOppositeDirection { get => isOppositeDirection; set => isOppositeDirection = value; }
    public float Speed { get => speed; set => speed = value; }
    public ObstacleScript Obstacle { get => obstacle; set => obstacle = value; }

    void Update()
    {
        if (this.IsOppositeDirection)
            transform.position = transform.position - Vector3.right * Time.deltaTime * speed;
    }
}
