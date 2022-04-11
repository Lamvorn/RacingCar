using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewStageColider : MonoBehaviour
{
    public GMSpawn gm;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Stage")
        {
            gm.SpawnStage();
        }

    }
}
