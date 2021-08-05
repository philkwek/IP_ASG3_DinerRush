using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int RoundIndex;
    public bool objective_completion = false;

    //inventory quantity
    public int Beef_Qty = 0;
    public int Bread_Qty = 0;
    public int Corn_Qty = 0;
    public int Egg_Qty = 0;
    public int Potato_Qty = 0;
    public int Sausage_Qty = 0;
    public int Beans_Qty = 0;

    public int[] inventory;
    public GameObject[] itemArray; //this array contains gameobjects of all possible items that can be held
    public bool holdingItem = false; //this ensures player can hold 1 item at a time
    public GameObject selectedItem; //selected item to be held

    public Transform itemSpawn; //location for item to be instantiated in player's hands 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objective_completion == false)
        {
            if (RoundIndex == 1)
            {
                if (Beef_Qty >= 1 && Egg_Qty >= 2 && Bread_Qty >= 1 && Sausage_Qty >= 1) 
                {
                    int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

                    inventory = tempInventory;

                    objective_completion = true;
                }
            }

            else if (RoundIndex == 2)
            {
                if (Beef_Qty >= 2 && Egg_Qty >= 4 && Bread_Qty >= 2 && Corn_Qty >= 1 && Sausage_Qty >= 2)
                {
                    int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

                    inventory = tempInventory;

                    objective_completion = true;
                }
            }

            else if (RoundIndex == 3)
            {
                if (Beef_Qty >= 3 && Egg_Qty >= 3 && Bread_Qty >= 1 && Corn_Qty >= 1 && Sausage_Qty >= 3 && Beans_Qty >= 1)
                {
                    int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

                    inventory = tempInventory;

                    objective_completion = true;
                }
            }

            else if (RoundIndex == 4)
            {
                if (Beef_Qty >= 1 && Egg_Qty >= 1 && Bread_Qty >= 1 && Beans_Qty >= 1)
                {
                    int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

                    inventory = tempInventory;

                    objective_completion = true;
                }
            }
        } 
    }

    public void ResetInventory()
    {
        Beef_Qty = 0;
        Bread_Qty = 0;
        Corn_Qty = 0;
        Egg_Qty = 0;
        Potato_Qty = 0;
        Sausage_Qty = 0;
        Beans_Qty = 0;

        int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

        inventory = tempInventory;
    }

    public void holdItem(int itemIndex)
        //this functions gets the index of item that should be held 
    {
        holdingItem = true;

        if (itemIndex == 0) //checks for what item is being requested to be held
        {
            Beef_Qty += 1;
            selectedItem = itemArray[itemIndex];
            int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

            inventory = tempInventory;

            selectedItem = Instantiate(selectedItem, itemSpawn.position, itemSpawn.rotation); //spawns object into hands of player
            selectedItem.transform.parent = GameObject.Find("player_model").transform; //this ensures item is a child of playerobject


        } else if (itemIndex == 1)
        {
            Bread_Qty += 1;
            selectedItem = itemArray[itemIndex];
            inventory[itemIndex] = Bread_Qty;

        } else if (itemIndex == 2)
        {
            Corn_Qty += 1;
            selectedItem = itemArray[itemIndex];
            inventory[itemIndex] = Corn_Qty;

        } else if (itemIndex == 3)
        {
            Egg_Qty += 1;
            selectedItem = itemArray[itemIndex];
            inventory[itemIndex] = Egg_Qty;

        } else if (itemIndex == 4)
        {
            Potato_Qty += 1;
            selectedItem = itemArray[itemIndex];
            inventory[itemIndex] = Potato_Qty;

        } else if (itemIndex == 5)
        {
            Sausage_Qty += 1;
            selectedItem = itemArray[itemIndex];
            inventory[itemIndex] = Sausage_Qty;

        } else if (itemIndex == 6)
        {
            Beans_Qty += 1;
            selectedItem = itemArray[itemIndex];
            inventory[itemIndex] = Beans_Qty;

        } 
    }

    public void placeinFridge()
    {
        holdingItem = false;
        Destroy(selectedItem);
    }
}
