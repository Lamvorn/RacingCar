using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeed : MonoBehaviour
{
    public CarModel automobilModel;

    void Update()
    {
        if (automobilModel.IsOppositeDirection && !automobilModel.IsCarCrashed)
            transform.position = transform.position - Vector3.right * Time.deltaTime*5;
    }
}
