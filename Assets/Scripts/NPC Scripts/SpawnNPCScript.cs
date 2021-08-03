using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNPCScript : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField]
    private Transform SpawnLocation;

    [SerializeField]
    private GameObject npcPrefab;

    [SerializeField]
    private GameObject ramseyPrefab;

    [SerializeField]
    private float spawnDelay = 10; // sets spawn rate of the NPC

    public GameObject[] AI_targets; // this check is to ensure the spawner does not spawn when there are no more areas left

    public int npc_number;
    public int max_npc; // variable to be set by roundscript

    //private Player activeNPC;

    // Start is called before the first frame update
    void Start()
    {
        AI_targets[0] = GameObject.Find("AiTarget_0");
        AI_targets[1] = GameObject.Find("AiTarget_1");
        AI_targets[2] = GameObject.Find("AiTarget_2");
        AI_targets[3] = GameObject.Find("AiTarget_3");
        AI_targets[4] = GameObject.Find("AiTarget_4");
        AI_targets[5] = GameObject.Find("AiTarget_5");
        AI_targets[6] = GameObject.Find("AiTarget_6");
        AI_targets[7] = GameObject.Find("AiTarget_7");
        AI_targets[8] = GameObject.Find("AiTarget_8");
        AI_targets[9] = GameObject.Find("AiTarget_9");
        AI_targets[10] = GameObject.Find("AiTarget_10");
        AI_targets[11] = GameObject.Find("AiTarget_11");
        AI_targets[12] = GameObject.Find("AiTarget_12");
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn() && npc_number < max_npc && AI_targets != null)
        {
            Spawn();
        }
    }

    private void Spawn() //this function handles the spawn of NPC object
    {
        npc_number += 1;
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(npcPrefab, SpawnLocation.position, SpawnLocation.rotation);
        //newNPC.
    }

    public void SpawnRamsey()
    {
        Instantiate(ramseyPrefab, SpawnLocation.position, SpawnLocation.rotation);
    }

    private bool ShouldSpawn() 
    {
        return Time.time >= nextSpawnTime;
    }

    public void decreaseNPC()
    {
        //npc_number -= 1;
    }
}
