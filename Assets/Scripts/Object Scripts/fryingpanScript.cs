using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fryingpanScript : MonoBehaviour
{

    public Animator cookUIprogress;
    public GameObject foodCookedAlert;
    public GameObject isCookingAlert;
    public bool cookingAnimation = false;

    public GameObject cookUI;
    public GameObject playerObject;

    public GameObject[] gameItems;
    public GameObject currentFood;

    //transform locations for the food on frying pan
    public Transform foodSpawn1;

    public float cookTime = 0f;
    public float cookingTimer = 8.0f;
    public bool foodCooked;
    public bool isCooking = false;

    public Image[] itemIndicators;
    private Image uiUse;
    public GameObject alertParent;
    public Transform indicatorSpawn;

    public GameObject takeFoodButton;

    public bool cookingSound = false;
    public AudioSource sound;

    public void Start()
    {
        cookTime = cookingTimer;
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
            if (foodCooked == false && currentFood != null && cookUI.activeSelf == true)
            {
                Cooking();
            }

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (foodCooked == false && currentFood != null && cookUI.activeSelf == true)
            {
                stopAnimation();
            }
        }
    }

    public void openCookUI()
    {
        Debug.Log("Opening Cooking UI");
        cookUI.SetActive(true);
    }

    public void closeCookUI()
    {
        if (isCooking == false)
        {
            cookUI.SetActive(false);
        } else
        {
            isCookingAlert.SetActive(true);
        }
    }

    public void stopAnimation()
    {
        cookUIprogress.speed = 0;
    }

    public void playSound()
    {
        if (cookingSound == false)
        {
            sound.Play();
            cookingSound = true;
        }
    }


    public void Cooking()
    {
        if (cookTime > 0)
        {
            if (cookingAnimation == false)
            {
                cookUIprogress.SetBool("triggerCook", true);
                cookingAnimation = true;
            }

            Debug.Log(cookTime);
            cookTime -= 1 * Time.deltaTime;
            cookUIprogress.speed = 1;
            playSound();

        } else if (cookTime <= 0)
        {
            cookingSound = false;
            sound.Stop();

            foodCooked = true;
            foodCookedAlert.SetActive(true);
            takeFoodButton.SetActive(true);
            cookUIprogress.SetBool("triggerCook", false);
            cookingAnimation = false;
            cookUIprogress.speed = 1;
        }
    }

    public void takeFood()
    {
        Debug.Log("Running fryingpan script");
        Destroy(uiUse);

        takeFoodButton.SetActive(false);
        foodCooked = false;
        cookTime = cookingTimer;
        currentFood = null;
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
