using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorOutdoorScript : MonoBehaviour
{
    public GameObject outdoor_wall;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");
        outdoor_wall.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exit");
        outdoor_wall.SetActive(true);
    }
}
