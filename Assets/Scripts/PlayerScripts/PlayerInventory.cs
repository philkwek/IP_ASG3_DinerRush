using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int RoundIndex;
    public bool objective_completion = false;

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
        if (objective_completion == false)
        {
            if (RoundIndex == 1)
            {
                if (Beef_Qty >= 1 && Egg_Qty >= 2 && Bread_Qty >= 1)
                {
                    objective_completion = true;
                }
            }

            else if (RoundIndex == 2)
            {
                if (Beef_Qty >= 2 && Egg_Qty >= 4 && Bread_Qty >= 2 && Corn_Qty >= 1 && Sausage_Qty >= 2)
                {
                    objective_completion = true;
                }
            }

            else if (RoundIndex == 3)
            {
                if (Beef_Qty >= 3 && Egg_Qty >= 3 && Bread_Qty >= 1 && Corn_Qty >= 1 && Sausage_Qty >= 3 && Beans_Qty >= 1)
                {
                    objective_completion = true;
                }
            }

            else if (RoundIndex == 4)
            {
                if (Beef_Qty >= 1 && Egg_Qty >= 1 && Bread_Qty >= 1 && Beans_Qty >= 1)
                {
                    objective_completion = true;
                }
            }
        } 
    }
}
