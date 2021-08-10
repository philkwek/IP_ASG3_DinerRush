using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateUIScript : MonoBehaviour
{
    //Food Icons (according to slot)
    public GameObject[] foodSlot_1;
    public GameObject[] foodSlot_2;
    public GameObject[] foodSlot_3;

    public void foodImageOn(int slot, int foodIndex)
    {
        if (slot == 1)
        {
            foodSlot_1[foodIndex].SetActive(true);
        } else if (slot == 2)
        {
            foodSlot_2[foodIndex].SetActive(true);
        } else if (slot == 3)
        {
            foodSlot_3[foodIndex].SetActive(true);
        }
    }
}
