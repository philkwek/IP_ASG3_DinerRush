using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class customer_npc : MonoBehaviour
{
    NavMeshAgent agent; //reference to agent
    public Transform target; //target position for NPC to travel to
    public Transform turn_target; // target direction to turn to

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // gets gameobject's navmesh agent for use
        MoveToPoint(target.position); //moves npc to target location. 
    }

    private void Update()
    {
        if (agent.velocity.magnitude < 0.15f) // turns NPC to face the appropriate direction once AI is "seated"
        {
            Debug.Log("Turning");
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point) //this function is for moving the playerobject
    {
        agent.SetDestination(point); 
    }

    void FaceTarget() // function for turning gameObject
    {
        Vector3 direction = (turn_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


}
