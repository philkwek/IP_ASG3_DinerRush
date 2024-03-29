using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLeaveScript : MonoBehaviour
{
    public GameObject Target;
    [SerializeField]
    private GameObject NPC;

    public GameObject SpawnObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CustomerNPC" || other.transform.tag == "GordonRamsey")
        {
            if (other.transform.tag == "CustomerNPC")
            {
                if (other.gameObject.GetComponent<customer_npc>().orderStart == false)
                {
                    Target.SetActive(false); //disables target so spawner knows that seat has been occupied

                    NPC = other.gameObject;

                    NPC.GetComponent<npcMoodScript>().orderAlert();

                    if (other.transform.tag == "CustomerNPC")
                    {
                        NPC.GetComponent<customer_npc>().orderStart = true;
                    }
                    else
                    {
                        NPC.GetComponent<GordonRamseyScript>().orderStart = true;
                    }
                }
            } else if (other.transform.tag == "GordonRamsey")
            {
                if (other.gameObject.GetComponent<GordonRamseyScript>().orderStart == false)
                {
                    Target.SetActive(false); //disables target so spawner knows that seat has been occupied

                    NPC = other.gameObject;

                    NPC.GetComponent<npcMoodScript>().orderAlert();

                    if (other.transform.tag == "CustomerNPC")
                    {
                        NPC.GetComponent<customer_npc>().orderStart = true;
                    }
                    else
                    {
                        NPC.GetComponent<GordonRamseyScript>().orderStart = true;
                    }
                }
            }
            
        }
    }

    

    public void leaveFunction() //temporary function to test deletion of NPCs
    {
        NPC.GetComponent<customer_npc>().LeaveRestaurant();
        SpawnObject.GetComponent<SpawnNPCScript>().decreaseNPC(); 
    }

}
