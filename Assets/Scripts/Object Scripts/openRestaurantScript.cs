using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openRestaurantScript : MonoBehaviour
{
    public GameObject gameController;
    public GameObject spawner;

    public void openDoors()
    {
        if (gameController.GetComponent<RoundScript>().step1 == true && gameController.GetComponent<RoundScript>().step2 == true)
        {
            gameController.GetComponent<RoundScript>().obj3_completion = true;
            spawner.SetActive(true);
        }
        
    }
}
