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
        if (other.transform.tag == "CustomerNPC")
        {
            Target.SetActive(false);

            NPC = other.gameObject;

            Invoke("leaveFunction", 5.0f); // temporary function to test leaving script
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "CustomerNPC")
        {
            Target.SetActive(true);
            
        }
    }

    public void leaveFunction() //temporary function to test deletion of NPCs
    {
        NPC.GetComponent<customer_npc>().LeaveRestaurant();
        SpawnObject.GetComponent<SpawnNPCScript>().decreaseNPC(); 
    }

}
