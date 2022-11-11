using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSpeed : MonoBehaviour
{
    public BusModel autobusModel;

    void Update()
    {
        if (autobusModel.IsOppositeDirection && !autobusModel.IsBusCrashed)
            transform.position = transform.position - Vector3.right * Time.deltaTime * 3;
    }
}
