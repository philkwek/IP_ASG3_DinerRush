using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookUIScript : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject fryingPan;

    public GameObject[] foodImages;

    public void placeFood()
    {
        if (playerObject.GetComponent<PlayerInventory>().holdingItem != false
                    && playerObject.GetComponent<PlayerInventory>().itemNumber < 7)
        //checks if player is holding item & that item is a food item
        {

            var itemIndex = playerObject.GetComponent<PlayerInventory>().itemNumber;
            //focusObject.GetComponent<fryingpanScript>().cookFood(itemIndex);
            Debug.Log(itemIndex);

            foodImages[itemIndex].SetActive(true);
            fryingPan.GetComponent<fryingpanScript>().cookIndicator(itemIndex);
            playerObject.GetComponent<PlayerInventory>().placeonPan();
        }
    }
}
