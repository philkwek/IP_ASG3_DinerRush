using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateScript : MonoBehaviour
{
    public GameObject[] cookedFood;
    public GameObject heldFood;
    public int foodIndex;

    public Transform playerHoldPlate; // for when player wants to hold plate
    public Transform spawnPlatePosition; //this is for the plate
    public GameObject platePrefab;

    // Food Index for the plate
    public int[] foodOnPlate;
    public int numberOfFood;

    //Food poisitons for heldFood to be placed
    public Transform foodSpawn1;
    public Transform foodSpawn2;
    public Transform foodSpawn3;

    private bool spawn1_taken = false;
    private bool spawn2_taken = false;
    private bool spawn3_taken = false;
    private bool plate_full = false;

    public GameObject plateUI;
    public GameObject playerObject;
    public GameObject canvas;



    private void Start()
    {
        //plateUI = GameObject.Find("PlateUI");
        canvas = GameObject.Find("Canvas");
        playerObject = GameObject.Find("player_model");
    
        //spawnPl
    }

    public void placeFood()
    {
        //get item food number
        //get reference to gameobject
        //spawn item onto the plate
        if (playerObject.GetComponent<PlayerInventory>().itemNumber > 6
            && playerObject.GetComponent<PlayerInventory>().itemNumber < 14
            && plate_full == false && playerObject.GetComponent<PlayerInventory>().selectedItem != null) //checks if item held is cooked food
        {
            playerObject.GetComponent<PlayerInventory>().holdingItem = false;
            canvas.GetComponent<PlayerUIScript>().destroyIndicator();
            foodIndex = playerObject.GetComponent<PlayerInventory>().itemNumber;

            heldFood = playerObject.GetComponent<PlayerInventory>().selectedItem;
            playerObject.GetComponent<PlayerInventory>().selectedItem = null;
            
            heldFood.transform.parent = gameObject.transform;

            if (spawn1_taken == false) //food spawning script onto the plate
            {
                heldFood.transform.position = foodSpawn1.position;
                spawn1_taken = true;

                foodOnPlate = new int[]
                {
                    foodIndex - 7,
                };
                //foodOnPlate[0] = foodIndex - 7;

                numberOfFood += 1;

                //plateUI.GetComponent<plateUIScript>().foodImageOn(1, foodOnPlate[0]);

            } else if (spawn2_taken == false)
            {
                heldFood.transform.position = foodSpawn2.position;
                spawn2_taken = true;
                var spawn1 = foodOnPlate[0];
                foodOnPlate = new int[]
                {
                    spawn1,
                    foodIndex - 7,
                }; 
                numberOfFood += 1;

                //plateUI.GetComponent<plateUIScript>().foodImageOn(2, foodOnPlate[1]);

            } else if (spawn3_taken == false)
            {
                heldFood.transform.position = foodSpawn3.position;
                spawn3_taken = true;
                var spawn1 = foodOnPlate[0];
                var spawn2 = foodOnPlate[1];
                foodOnPlate = new int[]
                {
                    spawn1,
                    spawn2,
                    foodIndex - 7,
                };
                numberOfFood += 1;

                //plateUI.GetComponent<plateUIScript>().foodImageOn(3, foodOnPlate[2]);
                plate_full = true;
            } 

        } else if (plate_full == true)
        {
            //alert that plate full

        } else if (playerObject.GetComponent<PlayerInventory>().holdingItem == false
            || playerObject.GetComponent<PlayerInventory>().itemNumber > 14)
        {
            //alert that there is no food being held

        } else if (playerObject.GetComponent<PlayerInventory>().itemNumber > 6)
        {
            //alert that food is raw
        }
    }

    public void openPlateUI()
    {
        plateUI.SetActive(true);
    }

    public void takePlate()
    {
        gameObject.transform.position = playerHoldPlate.position;
        gameObject.transform.parent = playerObject.transform;

        if (numberOfFood == 3)
        {
            playerObject.GetComponent<PlayerInventory>().orderHold(foodOnPlate[0], foodOnPlate[1], foodOnPlate[2]);

        } else if (numberOfFood == 2)
        {
            playerObject.GetComponent<PlayerInventory>().orderHold(foodOnPlate[0], foodOnPlate[1], 20);
        } else if (numberOfFood == 1)
        {
            playerObject.GetComponent<PlayerInventory>().orderHold(foodOnPlate[0], 20, 20);
        }
        
        var plate = Instantiate(platePrefab, spawnPlatePosition.position, spawnPlatePosition.rotation);

        plate.GetComponent<plateScript>().playerHoldPlate = playerHoldPlate;
        plate.GetComponent<plateScript>().plateUI = plateUI;
        plate.GetComponent<plateScript>().spawnPlatePosition = spawnPlatePosition;
        plate.GetComponent<plateScript>().platePrefab = platePrefab;

    }

    public void DestroyFood()
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
    }


}
