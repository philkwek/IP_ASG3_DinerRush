using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FridgeScript : MonoBehaviour
{
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

    public void placeFood()
    {
        playerObject.GetComponent<PlayerInventory>().holdingItem = false;

        inventoryArray = playerObject.GetComponent<PlayerInventory>().inventory;
        Beef_Qty += inventoryArray[0];
        Bread_Qty += inventoryArray[1];
        Corn_Qty += inventoryArray[2];
        Egg_Qty += inventoryArray[3];
        Potato_Qty += inventoryArray[4];
        Sausage_Qty += inventoryArray[5];
        Beans_Qty += inventoryArray[6];
        //storeButton.SetActive(false);

        playerObject.GetComponent<PlayerInventory>().ResetInventory();

        qty_text[0].text = "x" + Beef_Qty.ToString();
        qty_text[1].text = "x" + Bread_Qty.ToString();
        qty_text[2].text = "x" + Corn_Qty.ToString();
        qty_text[3].text = "x" + Egg_Qty.ToString();
        qty_text[4].text = "x" + Potato_Qty.ToString();
        qty_text[5].text = "x" + Sausage_Qty.ToString();
        qty_text[6].text = "x" + Beans_Qty.ToString();
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
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Beef_Qty > 0)
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
        else if (Beef_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takeCorn()
    {
        int itemIndex = 2;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Beef_Qty > 0)
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
        else if (Beef_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takeEgg()
    {
        int itemIndex = 3;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Beef_Qty > 0)
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
        else if (Beef_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takePotato()
    {
        int itemIndex = 4;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Beef_Qty > 0)
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
        else if (Beef_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takeSausage()
    {
        int itemIndex = 5;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Beef_Qty > 0)
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
        else if (Beef_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

    public void takeBeans()
    {
        int itemIndex = 6;
        if (playerObject.GetComponent<PlayerInventory>().holdingItem == false && Beef_Qty > 0)
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
        else if (Beef_Qty <= 0)
        {
            alert_text[itemIndex].text = "No more of selected food!";
            alert_gameobject[itemIndex].SetActive(true);
        }
    }

}
