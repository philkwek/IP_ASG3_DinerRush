using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcMoodScript : MonoBehaviour
{
    public Image order;
    public Image happy;
    public Image disappointed;
    public Image angry;

    public Transform reactionSpawn; //spawn point for the image

    private Image uiUse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (uiUse != null)
        {
            uiUse.transform.position = Camera.main.WorldToScreenPoint(reactionSpawn.position);
        }
    }

    public void orderAlert()
    {
        if (uiUse != null) //ensures that previous reactions are cleared before initating code
        {
            Destroy(uiUse);
        }
        Debug.Log("Spawning UI");
        uiUse = Instantiate(order, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }

    public void happyAlert()
    {
        if (uiUse != null) //ensures that previous reactions are cleared before initating code
        {
            Destroy(uiUse);
        }

        uiUse = Instantiate(happy, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }

    public void disappointedAlert()
    {
        if (uiUse != null) //ensures that previous reactions are cleared before initating code
        {
            Destroy(uiUse);
        }

        uiUse = Instantiate(disappointed, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }

    public void angryAlert()
    {
        if (uiUse != null) //ensures that previous reactions are cleared before initating code
        {
            Destroy(uiUse);
        }

        uiUse = Instantiate(angry, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
    }
}
