using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GordonRamseyScript : MonoBehaviour
{
    NavMeshAgent agent; //reference to agent
    //public Transform target; //target position for NPC to travel to
    //public Transform turn_target; // target direction to turn to
    public GameObject[] AI_targets; // Array of all target positions for AI to travel to
    public GameObject aiObject;
    public GameObject[] AI_targets_face;// Array of all target position for AI to face once seat is reached
    public GameObject[] plateTransform; // Array of all plate positions for when NPC recieves food
    public GameObject plateSelected;

    public GameObject customerPlate;

    public int[] assignedOrder; //assigned order 
    public string orderText; //order text
    public int[] receivedOrder; //for when player gives order to AI

    public bool ordered = false;
    public bool order_received = false;
    public bool order_complete = false;
    public bool orderCorrect = false; //true if order given is correct

    public bool orderTimer = false;
    public bool timerStart = false;
    public bool orderStart = false;
    public bool attendOrder = false;

    public float currentTime = 0f;
    public float startingTime = 60;
    public float orderTime = 0f;
    public float orderStarting_time = 50f;

    public float eatDuration = 5.0f;
    public float eatTime = 0f;
    public bool eatingComplete = false;

    private int target_index;
    private int npc_model;

    [SerializeField]
    private GameObject spawnObject;
    [SerializeField]
    private GameObject leaveObject;
    [SerializeField]
    private bool followNPC;
    [SerializeField]
    private bool isLeaving = false;

    public GameObject canvas;
    public GameObject giveRamseyUI;
    public GameObject playerObject;

    public Transform plateLocation;

    public bool followingNPC = false;

    public bool angry = false;
    public bool disappointed = false;

    //Audio for delicious reaction
    public AudioSource delicious;


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

        spawnObject = GameObject.Find("NPC_Spawn");
        leaveObject = GameObject.Find("NPC_Leave");
        playerObject = GameObject.Find("player_model");

        canvas = GameObject.Find("Canvas");
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // gets gameobject's navmesh agent for use
        //MoveToPoint(target.position);
        RandomizeTarget();

        currentTime = startingTime;
        orderTime = orderStarting_time;
        eatTime = eatDuration;

        orderText = "Beef Steak & Sausage";
        int[] order =
        {
            0,
            5,
        };
        assignedOrder = order;

    }

    private void Update()
    {
        if (agent.velocity.magnitude < 0.15f && followingNPC == false) // turns NPC to face the appropriate direction once AI is "seated"
        {
            //Debug.Log("Turning");
            FaceTarget(AI_targets_face[target_index]);
        }

        if (timerStart == true)
        {
            startTimer();
            //Debug.Log(currentTime.ToString("0"));
        }

        if (orderStart == true)
        {
            startOrder();
        }

        if (order_complete == true)
        {
            eatingFood();
        }
    }

    public void interactOrder() //function that runs from playercontroller, opens order menu
    {
        attendOrder = true;
        if (ordered == false)
        {
            canvas.GetComponent<orderScript>().orderText = orderText;
            canvas.GetComponent<orderScript>().assignedOrder = assignedOrder;
            canvas.GetComponent<orderScript>().orderMenuOpen();
            ordered = true;
        }

    }

    public void checkOrder(int[] dishes)
    {
        Debug.Log("Order Check running");
        var numberOfDishes = assignedOrder.GetLength(0);
        var numberCheck = 0;
        Debug.Log(dishes[0]);

        if (numberOfDishes == dishes.GetLength(0))
        {
            for (int i = 0; i < numberOfDishes; i++)
            {
                Debug.Log("Checking dish" + dishes[i]);

                for (int x = 0; x < numberOfDishes; x++)
                {
                    if (dishes[i] == assignedOrder[x])
                    {
                        numberCheck += 1;
                        Debug.Log("Found match: " + numberCheck);
                    }
                }
            }
        }

        if (numberCheck == numberOfDishes)
        {
            orderCorrect = true;
            canvas.GetComponent<orderScript>().toggleOrderAlert(true);
            order_received = true;
            playerObject.GetComponent<PlayerInventory>().currentDish = null;

        }
        else if (numberCheck != numberOfDishes) // function to run when order given is wrong
        {
            orderCorrect = false;
            canvas.GetComponent<orderScript>().toggleOrderAlert(false);
            gameObject.GetComponent<npcMoodScript>().ramseyWrongOrder();

            Invoke("angryReaction", 5.0f);
            Invoke("LeaveRestaurant", 5.0f);
        }
    }

    public void startTimer() // for AI waiting for order to be given by player
    { // total time => 120s
        

        if (order_received != true && isLeaving == false && orderCorrect == false)
        {
            if (currentTime > 0)
            {
                currentTime -= 1 * Time.deltaTime;
                followNPC = true;
                followPlayer();
            }

            if (currentTime <= 0 && angry == false && timerStart == true)
            {
                timerStart = false;
                angry = true;

                gameObject.GetComponent<npcMoodScript>().tooLongOrder();
                stopFollowPlayer();
                Invoke("LeaveRestaurant", 5.0f);
                Invoke("angryReaction", 5.0f);
            }

        }
        else if (order_complete == false && orderCorrect == true) //code runs when order is complete & correct
        {
            order_complete = true;
            timerStart = false;
            gameObject.GetComponent<npcMoodScript>().offAlert();

            //code transfers plate into gordon ramsey's hands
            customerPlate = playerObject.GetComponent<PlayerInventory>().plateObject;
            customerPlate.transform.position = plateLocation.transform.position;
            customerPlate.transform.parent = gameObject.transform;

        }
    }


    public void eatingFood() //function for AI "eating" food, runs after order_complete is true
    {
        if (eatingComplete == false)
        {
            if (eatTime > 0)
            {
                eatTime -= 1 * Time.deltaTime;
            }
            else if (eatTime <= 0)
            {
                eatingComplete = true;
                gameObject.GetComponent<npcMoodScript>().happyAlert();
                delicious.Play();
                stopFollowPlayer();
                LeaveRestaurant();
                customerPlate.GetComponent<plateScript>().DestroyFood(); //destroy food models
                Destroy(customerPlate);
            }
        }
    }

    public void startOrder() //for AI reaches seat and is waiting for order
    {
        Debug.Log("Started Order wait timer");
        bool angry = false;

        if (orderTime > 0 && attendOrder == false)
        {
            orderTime -= 1 * Time.deltaTime; ;
            
        }
        else if (orderTime <= 0 && angry == false) //for when timer runs out and order has not been recieved
        {
            angry = true;
            gameObject.GetComponent<npcMoodScript>().ramseyNoOrder();
            Invoke("LeaveRestaurant", 5.0f);
            Invoke("angryReaction", 5.0f);
            
            
        }
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

    public void followPlayer() //function for AI to follow playerobject
    {
        if (followNPC == true)
        {
            //followNPC = true;
            agent.stoppingDistance = 3;
            agent.updateRotation = false;
            MoveToPoint(playerObject.transform.position);
            FaceTarget(playerObject);
        }
    }

    public void stopFollowPlayer()
    {
        followNPC = false;
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
    }


    public void MoveToPoint(Vector3 point) //this function is for moving the playerobject
    {
        //agent.stoppingDistance = 0;
        agent.SetDestination(point);
    }

    void FaceTarget(GameObject obj) // function for turning gameObject
    {
        Vector3 direction = (obj.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void LeaveRestaurant() //leave restaurant script
    {
        isLeaving = true;
        Debug.Log("Ramsey leaving Restaurant");
        stopFollowPlayer();
        MoveToPoint(leaveObject.transform.position);
        //spawnObject.GetComponent<SpawnNPCScript>().decreaseNPC();
        //function above decreases total number of NPCs in game, allowing spawner to spawn in more NPCs
    }

    public void giveRamseyFoodUI()
    {
        giveRamseyUI.SetActive(true);
    }

    public void threwFoodAway() //function runs when player throws food away
    {
        orderStart = false;
        gameObject.GetComponent<npcMoodScript>().wasteFoodOrder();
        stopFollowPlayer();
        Invoke("LeaveRestaurant", 5.0f);
        Invoke("angryReaction", 5.0f);
        //text
    }

    void angryReaction()
    {
        gameObject.GetComponent<npcMoodScript>().angryAlert();
    }


}
