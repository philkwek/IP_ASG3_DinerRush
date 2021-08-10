using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNPCScript : MonoBehaviour
{
    //Variables for checking if Obj 4 has been completed
    public int numberOfNPCs;
    [SerializeField]
    private int deletedNPCs;

    public GameObject gameController;
    public GameObject roundEnd; //for game stats shown in the roundend ui

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CustomerNPC")
        {
            deletedNPCs += 1;

            if (deletedNPCs == numberOfNPCs)
            {
                gameController.GetComponent<RoundScript>().objUpdate(4);
            }

            if (other.gameObject.GetComponent<customer_npc>().order_received == true)
            {
                roundEnd.GetComponent<RoundEndMenu>().increaseCorrectOrder();

            } else if (other.gameObject.GetComponent<customer_npc>().order_received == false)
            {
                roundEnd.GetComponent<RoundEndMenu>().increaseMissOrder();
            }
            
            Destroy(other.gameObject);
            //SpawnObject.GetComponent<SpawnNPCScript>().decreaseNPC();
        }
    }
}
