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

    public GameObject player;

    private int spawnCount;

    public bool IsStage23 { get => isStage23; set => isStage23 = value; }
    private void Awake()
    {
        isStage23 = true;
    }

    private void Start()
    {
        player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/player" + EncryptedPlayerPrefs.GetInt("EquipedSkinKey"));
        spawnCount = Random.Range(2, 18);
        //spawnCount = 0;
        int num_stage = Random.Range(0, ListStage_23.Count);
        Instantiate(ListStage_23[num_stage], startSpawnLocation.transform.position, Quaternion.Euler(0,0,-90));
    }
    private void SpawnStage23() {
        if (spawnCount == 0)
        {

            spawnCount = Random.Range(3, 19);
            //spawnCount = 1;
            Debug.Log("Stage Merger2in3");
            Instantiate(Stage2into3, startSpawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
        }
        else
        {
            Debug.Log("STAGE23");
            int num_stage = Random.Range(0, ListStage_23.Count);
            Instantiate(ListStage_23[num_stage], spawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
            spawnCount--;
        }
    }

    private void SpawnStage32() {
        if (spawnCount == 0)
        {
            spawnCount = Random.Range(3, 19);
            //spawnCount = 1;
            Debug.Log("Stage Merger3in2");

            Instantiate(Stage3into2, startSpawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
        }
        else
        {
            Debug.Log("TODO: MAKE Stages 32");
            int num_stage = Random.Range(0, ListStage_23.Count);
            Instantiate(ListStage_23[num_stage], spawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
            //int num_stage = Random.Range(0, ListStage_32.Count);
            //Instantiate(ListStage_32[num_stage], spawnLocation.transform.position, Quaternion.Euler(0, 0, -90));
            spawnCount--;
        }
    }
    public void SpawnStage()
    {
        if (isStage23) SpawnStage23();
        else SpawnStage32();
    }
}
