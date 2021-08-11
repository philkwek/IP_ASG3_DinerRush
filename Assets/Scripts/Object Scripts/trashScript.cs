using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashScript : MonoBehaviour
{
    public GameObject trashUI;
    public GameObject playerObject;
    public GameObject ramseyAI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openUI()
    {
        trashUI.SetActive(true);
    }

    public void throwFood()
    {
        GameObject plate = playerObject.GetComponent<PlayerInventory>().plateObject;
        plate.transform.parent = gameObject.transform;
        Destroy(plate);

        if (ramseyAI.gameObject.activeSelf == true)
        {
            ramseyAI.GetComponent<GordonRamseyScript>().threwFoodAway();
        }
    }
}
