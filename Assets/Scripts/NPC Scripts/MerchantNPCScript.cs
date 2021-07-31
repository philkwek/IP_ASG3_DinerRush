using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MerchantNPCScript : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject Target_1;
    public GameObject Target_2;
    public GameObject Target_3;
    public GameObject Target_4;

    [SerializeField]
    private GameObject lastKnownTarget;

    public GameObject playerObject;

    [SerializeField]
    private bool playerFocus = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // gets gameobject's navmesh agent for use
        patrol_1();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null)
        {
            Debug.Log("Facing Player");
            FaceTarget();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MoveToPoint(gameObject.transform.position);
            playerObject = other.gameObject;
            Debug.Log("Detected Player! -> " + playerObject.name);
            playerFocus = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerObject = null;
            Debug.Log("Player left focus!");
            playerFocus = false;
            MoveToPoint(lastKnownTarget.transform.position);
        }
    }

    public void MoveToPoint(Vector3 point) //this function is for moving the playerobject
    {
        agent.SetDestination(point);
    }

    void FaceTarget()
    {
        Vector3 direction = (playerObject.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void patrol_1()
    {
        if (playerFocus == false)
        {
            MoveToPoint(Target_1.transform.position);
            lastKnownTarget = Target_1;
        } else
        {
            lastKnownTarget = Target_1;
        }
    }

    public void patrol_2()
    {
        if (playerFocus == false)
        {
            MoveToPoint(Target_2.transform.position);
            lastKnownTarget = Target_2;
        }
        else
        {
            lastKnownTarget = Target_2;
        }
    }

    public void patrol_3()
    {
        if (playerFocus == false)
        {
            MoveToPoint(Target_3.transform.position);
            lastKnownTarget = Target_3;
        }
        else
        {
            lastKnownTarget = Target_3;
        }
    }

    public void patrol_4()
    {
        if (playerFocus == false)
        {
            MoveToPoint(Target_4.transform.position);
            lastKnownTarget = Target_4;
        }
        else
        {
            lastKnownTarget = Target_4;
        }
    }
}
