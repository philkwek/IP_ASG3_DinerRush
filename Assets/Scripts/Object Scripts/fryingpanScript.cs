using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fryingpanScript : MonoBehaviour
{
    public GameObject cookUI;
    public GameObject playerObject;

    public GameObject[] gameItems;
    public GameObject currentFood;

    //transform locations for the food on frying pan
    public Transform foodSpawn1;

    public float cookTime = 8.0f;
    public float cookingTimer = 0f;
    public bool foodCooked;

    public Image[] itemIndicators;
    private Image uiUse;
    public GameObject alertParent;
    public Transform indicatorSpawn;

    public GameObject takeFoodButton;


    public void Start()
    {
        cookingTimer = cookTime;
        foodCooked = false;
    }

    public void Update()
    {
        if (uiUse != null)
        {
            uiUse.transform.position = Camera.main.WorldToScreenPoint(indicatorSpawn.position);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (foodCooked == false && currentFood != null)
            {
                Cooking();
            }

        }
    }

    public void openCookUI()
    {
        Debug.Log("Opening Cooking UI");
        cookUI.SetActive(true);
    }


    public void Cooking()
    {
        if (cookTime > 0)
        {
            Debug.Log(cookTime);
            cookTime -= 1 * Time.deltaTime;

        } else
        {
            foodCooked = true;
            takeFoodButton.SetActive(true);
        }
    }

    public void takeFood()
    {
        Destroy(uiUse);
    }


    public void cookIndicator(int itemIndex)
        //indicator to show what food is currently on the frying pan if player closes menu
    {
        if (itemIndex == 0) //beef indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            currentFood = gameItems[itemIndex];
            playerObject.GetComponent<PlayerInventory>().ResetInventory();

            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        }
        else if (itemIndex == 1) //bread indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            currentFood = gameItems[itemIndex];
            playerObject.GetComponent<PlayerInventory>().ResetInventory();

            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        }
        else if (itemIndex == 2) //corn indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            currentFood = gameItems[itemIndex];
            playerObject.GetComponent<PlayerInventory>().ResetInventory();

            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        }
        else if (itemIndex == 3) //Egg indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            currentFood = gameItems[itemIndex];
            playerObject.GetComponent<PlayerInventory>().ResetInventory();

            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        }
        else if (itemIndex == 4) //Potato indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            currentFood = gameItems[itemIndex];
            playerObject.GetComponent<PlayerInventory>().ResetInventory();

            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        }
        else if (itemIndex == 5) //Sausage indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            currentFood = gameItems[itemIndex];
            playerObject.GetComponent<PlayerInventory>().ResetInventory();

            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        }
        else if (itemIndex == 6) //Beans indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            currentFood = gameItems[itemIndex];
            playerObject.GetComponent<PlayerInventory>().ResetInventory();

            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        }


    }
    


}
