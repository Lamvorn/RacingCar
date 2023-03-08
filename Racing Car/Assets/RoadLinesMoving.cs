using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLinesMoving : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3( 2f * Time.deltaTime, 0, transform.position.z);
    }
}
