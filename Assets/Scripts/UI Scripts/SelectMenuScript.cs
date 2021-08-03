using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectMenuScript : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    [SerializeField]
    private int quantity = 0;

    public GameObject PlayerInventory;
    public GameObject buybutton;
    public GameObject Confirm;
    public TextMeshProUGUI Confirm_Message;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseMenu()
    {
        //Time.timeScale = 1;
    }

    public void IncreaseQty() //functions for UI buttons
    {
        quantity += 1;
        textMesh.text = quantity.ToString();
    }

    public void DecreaseQty() // functions for UI buttons
    {
        if (quantity > 0)
        {
            quantity -= 1;
        }
        textMesh.text = quantity.ToString();
    }

    private void ResetQty()
    {
        quantity = 0;
        textMesh.text = quantity.ToString();
    }

    public void BuyItem() //function for buy button, checks to see button belongs to where
    {
        if (buybutton.name == "Corn_Buy")
        {
            PlayerInventory.GetComponent<PlayerInventory>().Corn_Qty += quantity;
            string message = "Bought " + quantity + " Corn!";
            Confirm_Message.text = message;
            Confirm.SetActive(true);
            ResetQty();

        } else if (buybutton.name == "Beef_Buy")
        {
            PlayerInventory.GetComponent<PlayerInventory>().Beef_Qty += quantity;
            string message = "Bought " + quantity + " Beef!";
            Confirm_Message.text = message;
            Confirm.SetActive(true);
            ResetQty();

        } else if (buybutton.name == "Potato_Buy")
        {
            PlayerInventory.GetComponent<PlayerInventory>().Potato_Qty += quantity;
            string message = "Bought " + quantity + " Potatos!";
            Confirm_Message.text = message;
            Confirm.SetActive(true);
            ResetQty();

        } else if (buybutton.name == "Sausage_Buy")
        {
            PlayerInventory.GetComponent<PlayerInventory>().Sausage_Qty += quantity;
            string message = "Bought " + quantity + " Sausages!";
            Confirm_Message.text = message;
            Confirm.SetActive(true);
            ResetQty();

        } else if (buybutton.name == "Egg_Buy")
        {
            PlayerInventory.GetComponent<PlayerInventory>().Egg_Qty += quantity;
            string message = "Bought " + quantity + " Eggs!";
            Confirm_Message.text = message;
            Confirm.SetActive(true);
            ResetQty();

        } else if (buybutton.name == "Bread_Buy")
        {
            PlayerInventory.GetComponent<PlayerInventory>().Bread_Qty += quantity;
            string message = "Bought " + quantity + " Bread!";
            Confirm_Message.text = message;
            Confirm.SetActive(true);
            ResetQty();

        } else if (buybutton.name == "Beans_Buy")
        {
            PlayerInventory.GetComponent<PlayerInventory>().Beans_Qty += quantity;
            string message = "Bought " + quantity + " cans of Beans!";
            Confirm_Message.text = message;
            Confirm.SetActive(true);
            ResetQty();

        }
    }
}
