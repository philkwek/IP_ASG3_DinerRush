using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openRestaurantScript : MonoBehaviour
{
    public GameObject gameController;
    public GameObject spawner;

    public void openDoors()
    {
        gameController.GetComponent<RoundScript>().obj3_completion = true;
        spawner.SetActive(true);
    }
}
