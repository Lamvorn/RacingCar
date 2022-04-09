using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMSpawn : MonoBehaviour
{
    public GameObject spawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

            Instantiate(spawn,objectPos, Quaternion.identity,GameObject.FindGameObjectWithTag("Stage").transform);
            Debug.Log(objectPos);
        }
    }
}
