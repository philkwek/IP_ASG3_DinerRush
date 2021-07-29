using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class customer_npc : MonoBehaviour
{
    NavMeshAgent agent; //reference to agent
    //public Transform target; //target position for NPC to travel to
    //public Transform turn_target; // target direction to turn to
    public GameObject[] AI_targets; // Array of all target positions for AI to travel to
    public GameObject[] AI_targets_face;// Array of all target position for AI to face once seat is reached
    public GameObject[] NPC_Model; //Array of the 2 NPC models for use

    private int target_index;
    private int npc_model;

    // Start is called before the first frame update
    void Start()
    {
        RandomizeNPC();
        agent = GetComponent<NavMeshAgent>(); // gets gameobject's navmesh agent for use
        //MoveToPoint(target.position);
        RandomizeTarget();
    }

    private void Update()
    {
        if (agent.velocity.magnitude < 0.15f) // turns NPC to face the appropriate direction once AI is "seated"
        {
            Debug.Log("Turning");
            FaceTarget();
        }
    }

    public void RandomizeNPC() //this function randomely chooses between the 2 NPC Models for use
    {
        npc_model = Random.Range(0, 2);
        NPC_Model[npc_model].SetActive(true);
    }

    public void RandomizeTarget() //this function picks a random target zone for NPC to go and seat inside the restaurant
    {
        target_index = Random.Range(0, 6); //produces random number for picking out which target to choose from
        Debug.Log(target_index);
        MoveToPoint(AI_targets[target_index].transform.position);
    }

    public void MoveToPoint(Vector3 point) //this function is for moving the playerobject
    {
        agent.SetDestination(point); 
    }

    void FaceTarget() // function for turning gameObject
    {
        Vector3 direction = (AI_targets_face[target_index].transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


}
