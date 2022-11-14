using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMSpawn : MonoBehaviour
{

    public List<GameObject> ListStage_23;
    public List<GameObject> ListStage_32;

    public GameObject Stage2into3;
    public GameObject Stage3into2;

    private bool isStage23;

    public GameObject startSpawnLocation;
    public GameObject spawnLocation;

    private int spawnCount;

    public bool IsStage23 { get => isStage23; set => isStage23 = value; }
    private void Awake()
    {
        isStage23 = true;
    }

    private void Start()
    {
        spawnCount = Random.Range(2, 18);
        //spawnCount = 1;
        int num_stage = Random.Range(0, ListStage_23.Count);
        Instantiate(ListStage_23[num_stage], startSpawnLocation.transform.position, Quaternion.Euler(0,0,-90));
    }
    public void SpawnStage23() {
        if (spawnCount == 0)
        {
            spawnCount = Random.Range(3, 19);
            isStage23 = false;
            Debug.Log("TODO: Implement Stage Merger2in3");
            int num_stage = Random.Range(0, ListStage_23.Count);
            Instantiate(ListStage_23[num_stage], startSpawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
            //Instantiate(StageMerger2in3, startSpawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
        }
        else
        {
            int num_stage = Random.Range(0, ListStage_23.Count);
            Instantiate(ListStage_23[num_stage], spawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
            spawnCount--;
        }
    }

    public void SpawnStage32() {
        if (spawnCount == 0)
        {
            spawnCount = Random.Range(3, 19);
            //spawnCount = 2;
            isStage23 = true;
            Debug.Log("TODO: Implement Stage Merger3in2");
            int num_stage = Random.Range(0, ListStage_23.Count);
            Instantiate(ListStage_23[num_stage], startSpawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
            //Instantiate(StageMerger3in2, startSpawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
        }
        else
        {
            Debug.Log("Implement ListStage32");
            int num_stage = Random.Range(0, ListStage_23.Count);
            Instantiate(ListStage_23[num_stage], spawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
            //int num_stage = Random.Range(0, ListStage_32.Count);
            //Instantiate(ListStage_32[num_stage], spawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
            spawnCount--;
        }
    }


}
