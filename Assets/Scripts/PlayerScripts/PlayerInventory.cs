using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int RoundIndex;
    public bool objective_completion = false;
    public GameObject gameController;

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
    public int itemNumber;

    public int[] currentDish;

    public Transform itemSpawn;

    public GameObject canvas;

    public GameObject plateObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

        inventory = tempInventory;

        if (objective_completion == false)
        {
            if (RoundIndex == 1)
            {
                if (Beef_Qty >= 1 && Egg_Qty >= 2 && Bread_Qty >= 1 && Sausage_Qty >= 1) 
                {
                    objective_completion = true;
                    gameController.GetComponent<RoundScript>().objUpdate(1);
                }
            }

            else if (RoundIndex == 2)
            {
                if (Beef_Qty >= 2 && Egg_Qty >= 4 && Bread_Qty >= 2 && Corn_Qty >= 1 && Sausage_Qty >= 2)
                {
                    objective_completion = true;
                    gameController.GetComponent<RoundScript>().objUpdate(1);
                }
            }

            else if (RoundIndex == 3)
            {
                if (Beef_Qty >= 3 && Egg_Qty >= 3 && Bread_Qty >= 1 && Corn_Qty >= 1 && Sausage_Qty >= 3 && Beans_Qty >= 1)
                {
                    objective_completion = true;
                    gameController.GetComponent<RoundScript>().objUpdate(1);
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
        itemNumber = itemIndex;

        if (itemIndex == 0) //checks for what item is being requested to be held
        {
            Beef_Qty += 1;

            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;
            int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

            inventory = tempInventory;
            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);


        } else if (itemIndex == 1)
        {
            Bread_Qty += 1;

            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;
            int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

            inventory = tempInventory;
            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 2)
        {
            Corn_Qty += 1;

            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;
            int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

            inventory = tempInventory;
            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 3)
        {
            Egg_Qty += 1;

            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;
            int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

            inventory = tempInventory;
            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 4)
        {
            Potato_Qty += 1;

            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;
            int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

            inventory = tempInventory;
            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 5)
        {
            Sausage_Qty += 1;

            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;
            int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

            inventory = tempInventory;
            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 6)
        {
            Beans_Qty += 1;

            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;
            int[] tempInventory = {Beef_Qty, Bread_Qty, Corn_Qty, Egg_Qty, Potato_Qty,
                    Sausage_Qty, Beans_Qty};

            inventory = tempInventory;
            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        }  else if (itemIndex == 7) //cooked beef
        {
            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;

            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 8) //cooked bread (toast)
        {
            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;

            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 9) //cooked corn
        {
            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;

            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 10) //cooked egg
        {
            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;

            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 11) //cooked potato (mashed)
        {
            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;

            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 12) //cooked sausage
        {
            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;

            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } else if (itemIndex == 13) //cooked beans
        {
            selectedItem = Instantiate(itemArray[itemIndex], itemSpawn.position, itemSpawn.rotation);
            selectedItem.transform.parent = itemSpawn.transform;

            canvas.GetComponent<PlayerUIScript>().holdIndicator(itemIndex);

        } 
    }

    public void placeinFridge()
    {
        holdingItem = false;
        Destroy(selectedItem);
        canvas.GetComponent<PlayerUIScript>().destroyIndicator();
    }

    public void placeonPan()
    {
        holdingItem = false;
        Destroy(selectedItem);
        canvas.GetComponent<PlayerUIScript>().destroyIndicator();
    }

    public void orderHold(int food1, int food2, int food3)
    {
        int[] dishIngredients;

        if (food2 == 20 && food3 == 20)
        {
            dishIngredients = new int[]
            {
                food1,
            };
        } else if (food3 == 20)
        {
            dishIngredients = new int[]
            {
                food1,
                food2,
            };
        } else
        {
            dishIngredients = new int[]
            {
                food1,
                food2,
                food3
            };
        }

        currentDish = dishIngredients;
    }

    public void takePlate()
    {
        plateObject = gameObject.GetComponent<PlayerController>().focusObject;
        plateObject.GetComponent<plateScript>().takePlate();
    }

}
