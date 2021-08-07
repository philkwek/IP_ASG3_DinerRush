using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    public GameObject playerObject;

    public Animator clipboard;
    public bool clipboard_toggle = false;

    public Animator order;
    public bool order_toggle = false;

    public int RoundIndex;
    public GameObject parentObject;
    public GameObject obj1_done;
    public GameObject obj2_done;
    public GameObject obj3_done;
    public GameObject obj4_done;
    public GameObject obj5_done;

    public Image[] itemIndicators;
    [SerializeField] private Image uiUse;
    public GameObject alertParent;
    public Transform indicatorSpawn;


    private void Awake()
    {
        
        
    }

    // Start is called before the first frame update
    void Start()
    {

        if (RoundIndex == 1 || RoundIndex == 2 || RoundIndex == 3)
        {
            if (RoundIndex == 1)
            {
                parentObject = GameObject.Find("day1_morning");
            }
            else if (RoundIndex == 2)
            {
                parentObject = GameObject.Find("day2_morning");
            }
            else if (RoundIndex == 3)
            {
                parentObject = GameObject.Find("day3_morning");
            }

            obj1_done = parentObject.transform.Find("obj1_done").gameObject;
            obj2_done = parentObject.transform.Find("obj2_done").gameObject;
            obj3_done = parentObject.transform.Find("obj3_done").gameObject;
            obj4_done = parentObject.transform.Find("obj4_done").gameObject;
            obj5_done = parentObject.transform.Find("obj5_done").gameObject;

            obj1_done.SetActive(false);
            obj2_done.SetActive(false);
            obj3_done.SetActive(false);
            obj4_done.SetActive(false);
            obj5_done.SetActive(false);

        }
        else if (RoundIndex == 4)
        {
            parentObject = GameObject.Find("day4_morning");

            obj1_done = parentObject.transform.Find("obj1_done").gameObject;
            obj2_done = parentObject.transform.Find("obj2_done").gameObject;
            obj3_done = parentObject.transform.Find("obj3_done").gameObject;
            obj4_done = parentObject.transform.Find("obj4_done").gameObject;

            obj1_done.SetActive(false);
            obj2_done.SetActive(false);
            obj3_done.SetActive(false);
            obj4_done.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetAsLastSibling();

        if (uiUse != null)
        {
            uiUse.transform.position = Camera.main.WorldToScreenPoint(indicatorSpawn.position);
        }
    }

    public void holdIndicator(int itemIndex)
    {
        if (itemIndex == 0) //beef indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 1) //bread indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 2) //corn indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 3) //Egg indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 4) //Potato indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 5) //Sausage indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 6) //Beans indicator code
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 8) //Cooked Beef Indicator
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 9) // Toast indicator
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 10) // cooked egg indicator
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 11) // cooked potato (mashed)
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 12) // cooked sausage 
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        } else if (itemIndex == 13) // cooked beans
        {
            if (uiUse != null)
            {
                Destroy(uiUse);
            }
            Debug.Log("Spawning indicator");
            uiUse = Instantiate(itemIndicators[itemIndex], FindObjectOfType<Canvas>().transform).GetComponent<Image>();
            uiUse.transform.parent = alertParent.transform;

        }
    }

    public void destroyIndicator()
    {
        Destroy(uiUse);
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

    public void orderToggle()
    {
        if (order_toggle == false)
        {
            order.SetBool("toggle_orders", true);
            order_toggle = true;
        } else
        {
            order.SetBool("toggle_orders", false);
            order_toggle = false;
        }
    }

    public void objectiveComplete(int objective)
    {
        if (objective == 1)
        {
            obj1_done.SetActive(true);
        }
        else if (objective == 2)
        {
            obj2_done.SetActive(true);
        }
        else if (objective == 3)
        {
            obj3_done.SetActive(true);
        }
        else if (objective == 4)
        {
            obj4_done.SetActive(true);
        }
        else if (objective == 5)
        {
            obj5_done.SetActive(true);
        }




    }
}
