using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMSpawn : MonoBehaviour
{

    public List<GameObject> ListStage_23;
    public List<GameObject> ListStage_32;

    public GameObject startSpawnLocation;
    public GameObject spawnLocation;
   
    private void Start()
    {
        int num_stage = Random.Range(0, ListStage_23.Count);
        Instantiate(ListStage_23[num_stage], startSpawnLocation.transform.position, Quaternion.identity);
    }
    public void SpawnStage() {
       createStage();
    }
    private void createStage()
    {
        int num_stage = Random.Range(0, ListStage_23.Count);
        Instantiate(ListStage_23[num_stage], spawnLocation.transform.position, Quaternion.identity);
    }
}
