using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIScript : MonoBehaviour
{
    public GameObject playerObject;

    public Animator clipboard;
    public bool clipboard_toggle = false;


    // Start is called before the first frame update
    void Start()
    {
        
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
