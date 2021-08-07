using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookUIScript : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject fryingPan;

    public GameObject foodAlert;

    public GameObject[] foodImages;

    public GameObject activeImage;
    public int cookedFoodIndex;

    public void placeFood()
    {
        if (playerObject.GetComponent<PlayerInventory>().holdingItem != false
                    && playerObject.GetComponent<PlayerInventory>().itemNumber < 7)
        //checks if player is holding item & that item is a food item
        {

            var itemIndex = playerObject.GetComponent<PlayerInventory>().itemNumber;
            //focusObject.GetComponent<fryingpanScript>().cookFood(itemIndex);
            Debug.Log(itemIndex);
            var foodIndex = itemIndex;
            cookedFoodIndex = foodIndex + 7; 

            foodImages[itemIndex].SetActive(true);
            activeImage = foodImages[itemIndex];

            fryingPan.GetComponent<fryingpanScript>().cookIndicator(itemIndex);
            playerObject.GetComponent<PlayerInventory>().placeonPan();

        } else if (playerObject.GetComponent<PlayerInventory>().holdingItem == false
            || playerObject.GetComponent<PlayerInventory>().itemNumber >= 7)
        {
            foodAlert.SetActive(true);
        }
    }

    public void takeFood()
    {
        if (fryingPan.GetComponent<fryingpanScript>().foodCooked == true)
        {
            activeImage.SetActive(false);
            fryingPan.GetComponent<fryingpanScript>().takeFood();
            playerObject.GetComponent<PlayerInventory>().holdItem(cookedFoodIndex);
        }
    }
}
