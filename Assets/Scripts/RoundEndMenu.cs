using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RoundEndMenu : MonoBehaviour
{
    private int correctOrder = 0;
    private int missOrder = 0;

    public TMPro.TextMeshProUGUI correctOrderText;
    public TMPro.TextMeshProUGUI missOrderText;
    public GameObject endRoundMenu;
    private bool endRound = false;
    private void Update()
    {
        correctOrderText.text = correctOrder.ToString();
        missOrderText.text = missOrder.ToString();

        if (endRound == true)
        {
            endRoundMenu.SetActive(true);
        }
    }

    public void dayEnded()
    {
        endRound = true;
    }
    public void increaseCorrectOrder()
    {
        correctOrder += 1;
    }
    public void increaseMissOrder()
    {
        missOrder += 1;
    }
}
