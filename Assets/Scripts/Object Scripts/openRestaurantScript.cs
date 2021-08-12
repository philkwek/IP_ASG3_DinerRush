using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openRestaurantScript : MonoBehaviour
{
    public GameObject gameController;
    public GameObject spawner;
    public GameObject ui;

    public GameObject warning; // for when player has not completed obj 1 & 2
    public GameObject warning2; // for when player tries to close restaurant when there are still customers
    public GameObject close; //for player intending to close restaurant in the end
    public GameObject roundEnd;

    public AudioSource sound;
    public AudioClip restaurantOpen;
    public AudioClip beforeOpen;


    public void openDoors()
    {
        if (gameController.GetComponent<RoundScript>().step1 == true && gameController.GetComponent<RoundScript>().step2 == true)
        {
            gameController.GetComponent<RoundScript>().objUpdate(3);
            spawner.SetActive(true);
            close.SetActive(true);
            ui.SetActive(false);
            Debug.Log(sound.name);
            sound.clip = restaurantOpen;
            Debug.Log(sound.clip.name);
            playAudio();

        } else
        {
            warning.SetActive(true);
        }
        
    }

    public void closeRestaurant()
    {
        if (gameController.GetComponent<RoundScript>().step4 == true)
        {
            ui.SetActive(false);
            roundEnd.SetActive(true);
        } else if (gameController.GetComponent<RoundScript>().step4 != true)
        {
            warning2.SetActive(true);
        }
    }

    public void playAudio()
    {
        sound.Play();
    }

    public void openUI()
    {
        ui.SetActive(true);
    }
}
