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

    private GameObject spawnObject;

    private void Awake()
    {
        AI_targets[0] = GameObject.Find("AiTarget_0");
        AI_targets[1] = GameObject.Find("AiTarget_1");
        AI_targets[2] = GameObject.Find("AiTarget_2");
        AI_targets[3] = GameObject.Find("AiTarget_3");
        AI_targets[4] = GameObject.Find("AiTarget_4");
        AI_targets[5] = GameObject.Find("AiTarget_5");

        AI_targets_face[0] = GameObject.Find("AiTarget_Face_0");
        AI_targets_face[1] = GameObject.Find("AiTarget_Face_1");
        AI_targets_face[2] = GameObject.Find("AiTarget_Face_2");
        AI_targets_face[3] = GameObject.Find("AiTarget_Face_3");
        AI_targets_face[4] = GameObject.Find("AiTarget_Face_4");
        AI_targets_face[5] = GameObject.Find("AiTarget_Face_5");

        spawnObject = GameObject.Find("NPC_Spawn");
    }

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
            //Debug.Log("Turning");
            FaceTarget();
        }

        if (AI_targets == null)
        {
            //stop spawn
            spawnObject.SetActive(false);
        }
    }

    public void RandomizeNPC() //this function randomely chooses a NPC Model to use
    {
        npc_model = Random.Range(0, 2);
        NPC_Model[npc_model].SetActive(true);
    }

    public void RandomizeTarget() //this function picks a random target zone for NPC to go and seat inside the restaurant
    {
        bool target_exist = false;

        while (target_exist == false && AI_targets != null) //this loop will ensure that the target position exists
        {
            target_index = Random.Range(0, 6); //produces random number for picking out which target to choose from

            if (AI_targets[target_index] != null)
            {
                MoveToPoint(AI_targets[target_index].transform.position);
                Debug.Log("AI is going to location: " + target_index);
                target_exist = true;
                break;
            }

            if (AI_targets == null)
            {
                break;
            }
        }
        
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
