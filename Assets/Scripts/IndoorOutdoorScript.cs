using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorOutdoorScript : MonoBehaviour
{
    public GameObject outdoor_wall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger enter");
            outdoor_wall.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger exit");
            outdoor_wall.SetActive(true);
        }
    }
}
