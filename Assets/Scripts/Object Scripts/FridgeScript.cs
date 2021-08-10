using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FridgeScript : MonoBehaviour
{
    private bool objective2 = false;

    public GameObject gameManager;
    public GameObject fridgeUI;
    public Animator fridge;
    public GameObject playerObject;
    public GameObject storeButton;
    public int[] inventoryArray;

    public string[] foodArray;

    public TextMeshProUGUI[] qty_text;
    public GameObject[] alert_gameobject;
    public TextMeshProUGUI[] alert_text;

    public int Beef_Qty = 0;
    public int Bread_Qty = 0;
    public int Corn_Qty = 0;
    public int Egg_Qty = 0;
    public int Potato_Qty = 0;
    public int Sausage_Qty = 0;
    public int Beans_Qty = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void enableFridgeUI()
    {
        fridgeUI.SetActive(true);
    }

    public void openFridge()
    {
        fridge.SetBool("fridge_open", true);
        Invoke("enableFridgeUI", 1.0f);
    }

    public void closeFridge()
    {
        fridge.SetBool("fridge_open", false);
    }

    public void placeFood()
    {
        if (objective2 == false && playerObject.GetComponent<PlayerInventory>().inventory != null
            && gameManager.GetComponent<RoundScript>().step1 == true)
        {
            objective2 = true;
            var gamecontroller = GameObject.Find("GameController");
            gamecontroller.GetComponent<RoundScript>().obj2_completion = true;
        } //obj2 update code

        if (playerObject.GetComponent<PlayerInventory>().holdingItem == true)
        {
            playerObject.GetComponent<PlayerInventory>().placeinFridge();
        } //for when player wants to put food back into fridge

        if (playerObject.GetComponent<PlayerInventory>().inventory != null)
        {
            inventoryArray = playerObject.GetComponent<PlayerInventory>().inventory;
            Beef_Qty += inventoryArray[0];
            Bread_Qty += inventoryArray[1];
            Corn_Qty += inventoryArray[2];
            Egg_Qty += inventoryArray[3];
            Potato_Qty += inventoryArray[4];
            Sausage_Qty += inventoryArray[5];
            Beans_Qty += inventoryArray[6];

            qty_text[0].text = "x" + Beef_Qty.ToString();
            qty_text[1].text = "x" + Bread_Qty.ToString();
            qty_text[2].text = "x" + Corn_Qty.ToString();
            qty_text[3].text = "x" + Egg_Qty.ToString();
            qty_text[4].text = "x" + Potato_Qty.ToString();
            qty_text[5].text = "x" + Sausage_Qty.ToString();
            qty_text[6].text = "x" + Beans_Qty.ToString();
        }
        
        //storeButton.SetActive(false);

        playerObject.GetComponent<PlayerInventory>().ResetInventory();
    }

    public void takeBeef()
    {
        int itemIndex = 0;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Beef_Qty > 0)
        {
            playerObject.GetComponent<PlayerInventory>().holdItem(itemIndex);
            Beef_Qty -= 1;
            qty_text[itemIndex].text = "x" + Beef_Qty.ToString();
            alert_text[itemIndex].text = "Took food!";
            alert_gameobject[itemIndex].SetActive(true);

        } else if (playerObject.GetComponent<PlayerInventory>().holdingItem == true)
        {
            alert_text[itemIndex].text = "Cannot hold onto more than 1 item!";
            alert_gameobject[itemIndex].SetActive(true);

        } else if (Beef_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
        
    }

    public void takeBread()
    {
        int itemIndex = 1;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Bread_Qty > 0)
        {
            playerObject.GetComponent<PlayerInventory>().holdItem(itemIndex);
            Bread_Qty -= 1;
            qty_text[itemIndex].text = "x" + Bread_Qty.ToString();
            alert_text[itemIndex].text = "Took food!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (playerObject.GetComponent<PlayerInventory>().holdingItem == true)
        {
            alert_text[itemIndex].text = "Cannot hold onto more than 1 item!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (Bread_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takeCorn()
    {
        int itemIndex = 2;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Corn_Qty > 0)
        {
            playerObject.GetComponent<PlayerInventory>().holdItem(itemIndex);
            Corn_Qty -= 1;
            qty_text[itemIndex].text = "x" + Corn_Qty.ToString();
            alert_text[itemIndex].text = "Took food!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (playerObject.GetComponent<PlayerInventory>().holdingItem == true)
        {
            alert_text[itemIndex].text = "Cannot hold onto more than 1 item!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (Corn_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takeEgg()
    {
        int itemIndex = 3;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Egg_Qty > 0)
        {
            playerObject.GetComponent<PlayerInventory>().holdItem(itemIndex);
            Egg_Qty -= 1;
            qty_text[itemIndex].text = "x" + Egg_Qty.ToString();
            alert_text[itemIndex].text = "Took food!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (playerObject.GetComponent<PlayerInventory>().holdingItem == true)
        {
            alert_text[itemIndex].text = "Cannot hold onto more than 1 item!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (Egg_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takePotato()
    {
        int itemIndex = 4;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Potato_Qty > 0)
        {
            playerObject.GetComponent<PlayerInventory>().holdItem(itemIndex);
            Potato_Qty -= 1;
            qty_text[itemIndex].text = "x" + Potato_Qty.ToString();
            alert_text[itemIndex].text = "Took food!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (playerObject.GetComponent<PlayerInventory>().holdingItem == true)
        {
            alert_text[itemIndex].text = "Cannot hold onto more than 1 item!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (Potato_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takeSausage()
    {
        int itemIndex = 5;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Sausage_Qty > 0)
        {
            playerObject.GetComponent<PlayerInventory>().holdItem(itemIndex);
            Sausage_Qty -= 1;
            qty_text[itemIndex].text = "x" + Sausage_Qty.ToString();
            alert_text[itemIndex].text = "Took food!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (playerObject.GetComponent<PlayerInventory>().holdingItem == true)
        {
            alert_text[itemIndex].text = "Cannot hold onto more than 1 item!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (Sausage_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takeBeans()
    {
        int itemIndex = 6;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Beans_Qty > 0)
        {
            playerObject.GetComponent<PlayerInventory>().holdItem(itemIndex);
            Beans_Qty -= 1;
            qty_text[itemIndex].text = "x" + Beans_Qty.ToString();
            alert_text[itemIndex].text = "Took food!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (playerObject.GetComponent<PlayerInventory>().holdingItem == true)
        {
            alert_text[itemIndex].text = "Cannot hold onto more than 1 item!";
            alert_gameobject[itemIndex].SetActive(true);

        }
        else if (Beans_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

}
