using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteStage : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Stage")
        {
            Destroy(collision.gameObject);
        }

    }
}
