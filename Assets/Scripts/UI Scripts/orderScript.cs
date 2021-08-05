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

    public void orderMenuOpen()
    {
        orderUI_text.text = orderText;
        orderMenu.SetActive(true);
    }

    public void takeOrder()
    {
        if (customer1_text == false)
        {
            customer1_text = true;
            customer1.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();
            //put code here to start NPC's timer

        } else if (customer2_text == false)
        {
            customer2_text = true;
            customer2.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();

        } else if (customer3_text == false)
        {
            customer3_text = true;
            customer3.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();

        } else if (customer4_text == false)
        {
            customer4_text = true;
            customer4.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();

        } else if (customer5_text == false)
        {
            customer5_text = true;
            customer5.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();

        } else if (customer6_text == false)
        {
            customer6_text = true;
            customer6.text = orderText;
            npcMood.gameObject.GetComponent<npcMoodScript>().offAlert();

        }
    }
}
