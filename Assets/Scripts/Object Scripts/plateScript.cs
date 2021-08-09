using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateScript : MonoBehaviour
{
    public GameObject[] cookedFood;
    public GameObject heldFood;
    public int foodIndex;

    //Plate spawns for when the player takes a plate
    public Transform plateSpawn1;
    public Transform plateSpawn2;
    public Transform plateSpawn3;

    public Transform spawnPlatePosition; //this is for the plate

    // Food Index for the plate
    public int[] foodOnPlate = new int[3];

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
        
    }

    public void placeFood()
    {
        //get item food number
        //get reference to gameobject
        //spawn item onto the plate
        if (playerObject.GetComponent<PlayerInventory>().itemNumber > 6
            && playerObject.GetComponent<PlayerInventory>().itemNumber < 14
            && plate_full == false) //checks if item held is cooked food
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
                foodOnPlate[0] = foodIndex - 7;

                plateUI.GetComponent<plateUIScript>().foodImageOn(1, foodOnPlate[0]);

            } else if (spawn2_taken == false)
            {
                heldFood.transform.position = foodSpawn2.position;
                spawn2_taken = true;
                foodOnPlate[1] = foodIndex - 7;

                plateUI.GetComponent<plateUIScript>().foodImageOn(2, foodOnPlate[1]);

            } else if (spawn3_taken == false)
            {
                heldFood.transform.position = foodSpawn3.position;
                spawn3_taken = true;
                foodOnPlate[2] = foodIndex - 7;

                plateUI.GetComponent<plateUIScript>().foodImageOn(3, foodOnPlate[2]);
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
        gameObject.transform.position = spawnPlatePosition.position;
        gameObject.transform.parent = playerObject.transform;
    }
}
