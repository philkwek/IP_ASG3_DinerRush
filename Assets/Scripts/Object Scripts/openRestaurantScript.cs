using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openRestaurantScript : MonoBehaviour
{
    public GameObject gameController;
    public GameObject spawner;
    public GameObject ui;

    public GameObject warning; // for when player has not completed obj 1 & 2
    public GameObject close; //for player intending to close restaurant in the end
    public GameObject roundEnd;

    public void openDoors()
    {
        if (gameController.GetComponent<RoundScript>().step1 == true && gameController.GetComponent<RoundScript>().step2 == true)
        {
            gameController.GetComponent<RoundScript>().objUpdate(3);
            spawner.SetActive(true);
            close.SetActive(true);
        } else
        {
            warning.SetActive(true);
        }
        
    }

    public void closeRestaurant()
    {
        if (gameController.GetComponent<RoundScript>().step5 == true)
        {
            roundEnd.SetActive(true);
        }
    }

    public void openUI()
    {
        ui.SetActive(true);
    }
}
