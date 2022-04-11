using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStage : MonoBehaviour
{
    private float speedStage = 3f;
    void Update()
    {
        transform.position = transform.position - Vector3.up * speedStage * Time.deltaTime;
    }
}
