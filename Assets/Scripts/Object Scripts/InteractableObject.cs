using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public float radius = 4f;

    bool isFocus = false;
    Transform player;



    private void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius) // if true, player is within radius for interaction
            {
                //Debug.Log("In radius");
                if (Input.GetKeyDown(KeyCode.E)) //for when player hits E to interact with Object
                {
                    Debug.Log("Interacted with Object");
                }
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDeFocused()
    {
        isFocus = false;
        player = null;
    }
    
    private void OnDrawGizmosSelected() //shows interaction area
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
