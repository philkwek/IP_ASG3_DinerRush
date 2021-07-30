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
    private float spawnDelay = 10; // sets spawn rate of the NPC

    public int npc_number;

    //private Player activeNPC;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn() && npc_number < 6)
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

    private bool ShouldSpawn() 
    {
        return Time.time >= nextSpawnTime;
    }

    public void decreaseNPC()
    {
        npc_number -= 1;
    }
}
