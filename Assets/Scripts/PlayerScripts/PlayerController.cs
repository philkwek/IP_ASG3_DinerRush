using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    PlayerMotor motor;
    public Camera cam;
    public LayerMask movement;
    public LayerMask interact;
    public GameObject playerObject;

    public InteractableObject focus;
    public GameObject focusObject;

    public bool UI_enable = false;

    public bool minimart = false;
    public GameObject canvas;
    public GameObject MerchantUI;
    public GameObject FridgeUI;
    public GameObject CookUI;
    public GameObject CustomerUI;
    public GameObject GiveOrderUI;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MerchantUI.gameObject.activeSelf == true) //this check is for ray, to ensure it does not cast when menu is open
        {
            UI_enable = true;
        } else
        {
            UI_enable = false;
        }

        //move script for character, when player left clicks on area, player will move towards area
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 300, movement) && UI_enable == false)
            { 
                Debug.Log("Hit ground & moving");
                //Move player to clicked position
                motor.MoveToPoint(hit.point);

                // Stop focusing object
                RemoveFocus();
                focusObject = null;
            }
        }

        //interaction script, this will move character towards the interactable object defined by it's layer.
        //Interaction begins when player model is in radius of the interaction distance set.
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 300, interact) && UI_enable == false)
            {
                focusObject = hit.collider.gameObject;
                InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && focusObject != null) //interaction w object codes
        {

            if(focusObject.transform.tag == "Merchant_AI" && minimart == true)
            {
                MerchantUI.SetActive(true);
                //Time.timeScale = 0;
            }

            else if (focusObject.transform.tag == "Fridge")
            {
                //int[] tempInventory = gameObject.GetComponent<PlayerInventory>().inventory;
                //focusObject.GetComponent<FridgeScript>().inventoryArray = tempInventory;
                FridgeUI.GetComponent<FridgeScript>().openFridge();
                //FridgeUI.SetActive(true);
            }

            else if (focusObject.transform.tag == "RestaurantOpen")
            {
                focusObject.GetComponent<openRestaurantScript>().openUI();
            }

            else if (focusObject.transform.tag == "CustomerNPC")
            {
                if(focusObject.GetComponent<customer_npc>().ordered == false)
                {
                    focusObject.GetComponent<customer_npc>().interactOrder();
                    canvas.GetComponent<orderScript>().npcMood = focusObject;
                    focusObject = null;
                } else
                {
                    GiveOrderUI.SetActive(true);
                    canvas.GetComponent<orderScript>().npc = focusObject;
                    focusObject = null;
                }
                
            }

            else if (focusObject.transform.tag == "FryingPan")
            {
                Debug.Log("Frying Pan script running");
                focusObject.GetComponent<fryingpanScript>().openCookUI();
            }

            else if (focusObject.transform.tag == "Plate")
            {
                focusObject.GetComponent<plateScript>().openPlateUI();
            }

            else if (focusObject.transform.tag == "trashBin")
            {
                focusObject.GetComponent<trashScript>().openUI();
            }
        }

    }

    void SetFocus(InteractableObject newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDeFocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        
        newFocus.OnFocused(transform);
        
       
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDeFocused();
        }
        focus = null;
        motor.StopFollowTarget();
    }

}
