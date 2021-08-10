using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GordonRamseyScript : MonoBehaviour
{
    NavMeshAgent agent;
    private int target_index;

    public GameObject[] AI_targets; // Array of all target positions for AI to travel to
    public GameObject aiObject;
    public GameObject[] AI_targets_face;// Array of all target position for AI to face once seat is reached
    public GameObject[] plateTransform; // Array of all plate positions for when NPC recieves food
    public GameObject plateSelected;

    private void Awake()
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
        // add on here for additional seating locations

        AI_targets_face[0] = GameObject.Find("AiTarget_Face_0");
        AI_targets_face[1] = GameObject.Find("AiTarget_Face_1");
        AI_targets_face[2] = GameObject.Find("AiTarget_Face_2");
        AI_targets_face[3] = GameObject.Find("AiTarget_Face_3");
        AI_targets_face[4] = GameObject.Find("AiTarget_Face_4");
        AI_targets_face[5] = GameObject.Find("AiTarget_Face_5");
        AI_targets_face[6] = GameObject.Find("AiTarget_Face_6");
        AI_targets_face[7] = GameObject.Find("AiTarget_Face_7");
        AI_targets_face[8] = GameObject.Find("AiTarget_Face_8");
        AI_targets_face[9] = GameObject.Find("AiTarget_Face_9");
        AI_targets_face[10] = GameObject.Find("AiTarget_Face_10");
        AI_targets_face[11] = GameObject.Find("AiTarget_Face_11");
        AI_targets_face[12] = GameObject.Find("AiTarget_Face_12");
        //add on here for additional seating locations

        plateTransform[0] = GameObject.Find("Location0");
        plateTransform[1] = GameObject.Find("Location1");
        plateTransform[2] = GameObject.Find("Location2");
        plateTransform[3] = GameObject.Find("Location3");
        plateTransform[4] = GameObject.Find("Location4");
        plateTransform[5] = GameObject.Find("Location5");
        plateTransform[6] = GameObject.Find("Location6");
        plateTransform[7] = GameObject.Find("Location7");
        plateTransform[8] = GameObject.Find("Location8");
        plateTransform[9] = GameObject.Find("Location9");
        plateTransform[10] = GameObject.Find("Location10");
        plateTransform[11] = GameObject.Find("Location11");
        plateTransform[12] = GameObject.Find("Location12");
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomizeTarget() //this function picks a random target zone for NPC to go and seat inside the restaurant
    {
        bool target_exist = false;

        while (target_exist == false && AI_targets != null) //this loop will ensure that the target position exists
        {
            target_index = Random.Range(0, 13); //produces random number for picking out which target to choose from

            if (AI_targets[target_index] != null)
            {
                MoveToPoint(AI_targets[target_index].transform.position);
                aiObject = plateTransform[target_index];
                plateSelected = plateTransform[target_index];

                Debug.Log("AI is going to location: " + target_index);
                target_exist = true;
                break;
            }
        }
    }

    public void MoveToPoint(Vector3 point) //this function is for moving the playerobject
    {
        agent.SetDestination(point);
    }
}
