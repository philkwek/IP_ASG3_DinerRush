using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class orderScript : MonoBehaviour
{
    //this script is to retrieve order data from NPC
    public int[] assignedOrder;
    public string orderText;

    public GameObject npcMood;

    public TextMeshProUGUI customer1;
    public TextMeshProUGUI customer2;
    public TextMeshProUGUI customer3;
    public TextMeshProUGUI customer4;
    public TextMeshProUGUI customer5;
    public TextMeshProUGUI customer6;

    public bool customer1_text = false;
    public bool customer2_text = false;
    public bool customer3_text = false;
    public bool customer4_text = false;
    public bool customer5_text = false;
    public bool customer6_text = false;

    public TextMeshProUGUI orderUI_text;

    public GameObject orderMenu;
    public GameObject playerObject;
    public GameObject npc;

    public GameObject correctOrder;
    public GameObject wrongOrder;
    public GameObject noPlate;

    public void orderMenuOpen()
    {
        orderUI_text.text = orderText;
        orderMenu.SetActive(true);
    }

    public void giveOrder() // Function for passing plate from player to AI
    {
        if (playerObject.GetComponent<PlayerInventory>().currentDish != null)
        { // ensures player is holding a plate with food to give order
            Debug.Log("Order script check running");
            int[] dish;
            dish = playerObject.GetComponent<PlayerInventory>().currentDish;
            Debug.Log(dish);

            if (npc.gameObject.transform.tag == "CustomerNPC")
            {
                npc.GetComponent<customer_npc>().checkOrder(dish);

            }
            else if (npc.gameObject.transform.tag == "GordonRamsey")
            {
                npc.GetComponent<GordonRamseyScript>().checkOrder(dish);
            }

            
        } else
        {
            noPlate.SetActive(true);
        }
        
    }

    public void placeFood()
    {
        if (playerObject.GetComponent<PlayerController>().focusObject.transform.tag == "Plate")
        {
            GameObject plate = playerObject.GetComponent<PlayerController>().focusObject;
            plate.GetComponent<plateScript>().placeFood();
        }
    }

    public void toggleOrderAlert(bool status) //for telling player if order is right or wrong
    {
        if (status == true)
        {
            correctOrder.SetActive(true);
        } else
        {
            wrongOrder.SetActive(true);
        }
    }

    public void takeOrder()
    {
        if (customer1_text == false)
        {
            customer1_text = true;
            customer1.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();

            if (npcMood.gameObject.transform.tag == "GordonRamsey")
            {
                npcMood.gameObject.GetComponent<GordonRamseyScript>().timerStart = true;
            } else
            {
                npcMood.gameObject.GetComponent<customer_npc>().timerStart = true;
            }
            

        } else if (customer2_text == false)
        {
            customer2_text = true;
            customer2.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();
            if (npcMood.gameObject.transform.tag == "GordonRamsey")
            {
                npcMood.gameObject.GetComponent<GordonRamseyScript>().timerStart = true;
            }
            else
            {
                npcMood.gameObject.GetComponent<customer_npc>().timerStart = true;
            }

        } else if (customer3_text == false)
        {
            customer3_text = true;
            customer3.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();
            if (npcMood.gameObject.transform.tag == "GordonRamsey")
            {
                npcMood.gameObject.GetComponent<GordonRamseyScript>().timerStart = true;
            }
            else
            {
                npcMood.gameObject.GetComponent<customer_npc>().timerStart = true;
            }

        } else if (customer4_text == false)
        {
            customer4_text = true;
            customer4.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();
            if (npcMood.gameObject.transform.tag == "GordonRamsey")
            {
                npcMood.gameObject.GetComponent<GordonRamseyScript>().timerStart = true;
            }
            else
            {
                npcMood.gameObject.GetComponent<customer_npc>().timerStart = true;
            }

        } else if (customer5_text == false)
        {
            customer5_text = true;
            customer5.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();
            if (npcMood.gameObject.transform.tag == "GordonRamsey")
            {
                npcMood.gameObject.GetComponent<GordonRamseyScript>().timerStart = true;
            }
            else
            {
                npcMood.gameObject.GetComponent<customer_npc>().timerStart = true;
            }

        } else if (customer6_text == false)
        {
            customer6_text = true;
            customer6.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();
            if (npcMood.gameObject.transform.tag == "GordonRamsey")
            {
                npcMood.gameObject.GetComponent<GordonRamseyScript>().timerStart = true;
            }
            else
            {
                npcMood.gameObject.GetComponent<customer_npc>().timerStart = true;
            }

        }
    }
}
