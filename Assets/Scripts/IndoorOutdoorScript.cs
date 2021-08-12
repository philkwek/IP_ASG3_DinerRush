using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorOutdoorScript : MonoBehaviour
{
    public GameObject outdoor_wall;
    private bool wall = true;

    //public AudioSource bell;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger enter");

            if (wall == true)
            {
                outdoor_wall.SetActive(false);
                wall = false;
            } else if (wall == false)
            {
                outdoor_wall.SetActive(true);
                wall = true;
            }
            
        }
    }
}
