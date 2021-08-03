using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIScript : MonoBehaviour
{
    public GameObject playerObject;

    public Animator clipboard;
    public bool clipboard_toggle = false;

    public int RoundIndex;
    public GameObject parentObject;
    public GameObject obj1_done;
    public GameObject obj2_done;
    public GameObject obj3_done;
    public GameObject obj4_done;


    // Start is called before the first frame update
    void Start()
    {
        if (RoundIndex == 1)
        {
            parentObject = GameObject.Find("day1_morning");
            obj1_done = parentObject.transform.Find("obj1_done").gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clipboardToggle()
    {
        if (clipboard_toggle == false)
        {
            clipboard.SetBool("Toggled", true);
            clipboard_toggle = true;
        } else
        {
            clipboard_toggle = false;
            clipboard.SetBool("Toggled", false);
        }
    }
}
